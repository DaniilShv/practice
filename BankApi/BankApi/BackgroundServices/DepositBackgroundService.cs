using BankApi.Service.Interfaces;

namespace BankApi.BackgroundServices
{
    public class DepositBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scope;

        private ParallelOptions _options;

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

            var dtUtc = DateTime.SpecifyKind(new DateTime(2025, 6, 10, 18, 23, 40), DateTimeKind.Utc);

            _options.CancellationToken = stoppingToken;

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(5000);
                var clients = await service.GetByDateAccuralAsync(dtUtc, stoppingToken);

                if (clients.Count != 0)
                {
                    await Parallel.ForAsync(0, clients.Count, _options, async (i, token) =>
                    {
                        if (clients[i].DateAccrualPercent <= clients[i].DateFinal)
                        {
                            clients[i].Total += clients[i].Total * 0.013m;
                            clients[i].DateAccrualPercent = clients[i].DateAccrualPercent.AddMinutes(1);
                            await service.UpdateTotalByKeyAsync(clients[i].ClientId,
                                clients[i].DepositId, clients[i].DateAccrualPercent, clients[i].Total, token);
                        }
                    });
                }

                dtUtc = dtUtc.AddMinutes(1);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }


    }
}
