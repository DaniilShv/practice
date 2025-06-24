using BankApi.Service.Interfaces;

namespace BankApi.BackgroundServices
{
    public class DepositBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scope;

        private ParallelOptions _options;

        const int _depositDelay = 5000;

        public DepositBackgroundService(IServiceScopeFactory scope)
        {
            _scope = scope;
            _options = new ParallelOptions();
            _options.MaxDegreeOfParallelism = Environment.ProcessorCount - 1;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _scope.CreateScope();

            var service = scope.ServiceProvider.GetRequiredService<IClientDepositsService>();

            var dtUtc = DateTime.UtcNow;

            _options.CancellationToken = stoppingToken;

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(_depositDelay);
                var clients = await service.GetByDateAccuralAsync(dtUtc, stoppingToken);

                if (clients.Count != 0)
                {
                    await Parallel.ForAsync(0, clients.Count, _options, async (i, token) =>
                    {
                        if (clients[i].DateAccrualPercent <= clients[i].DateFinal)
                        {
                            double percent = clients[i].Percent / 12;
                            clients[i].Total += clients[i].Total * (decimal)percent;
                            clients[i].DateAccrualPercent = clients[i].DateAccrualPercent.AddMonths(1);
                            await service.UpdateTotalByKeyAsync(clients[i].ClientId,
                                clients[i].DepositId, clients[i].DateAccrualPercent, clients[i].Total, token);
                        }
                    });
                }

                dtUtc = dtUtc.AddMonths(1);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }


    }
}
