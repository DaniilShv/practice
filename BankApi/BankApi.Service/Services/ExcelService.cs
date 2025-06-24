using BankApi.Domain.Interfaces;
using ClosedXML.Excel;
using System.Data;

namespace BankApi.Service.Services
{
    public static class ExcelService
    {
        /// <summary>
        /// Создает excel документ с данными всех сущностей базы данных
        /// </summary>
        /// <param name="services">Все репозитории реализующие IExcelRepository</param>
        /// <param name="filePath">Путь до файла</param>
        public static void CreateExcelDoc(IEnumerable<IExcelRepository> services, string filePath)
        {
            foreach (var item in services)
            {
                var dataTable = item.GetDataTable();

                var namePage = item.GetTableName();

                if (!File.Exists(filePath))
                    CreateAndWriteExcelDoc(dataTable, filePath, namePage);
                else
                    WriteExcelDoc(dataTable, filePath, namePage);
            }
        }

        /// <summary>
        /// Создает excel файл и записывает экземпляры сущности
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="table">Все экземпляры сущности</param>
        /// <param name="filePath">Путь до файла</param>
        /// <param name="namePage">Название листа в Excel</param>
        static void CreateAndWriteExcelDoc(DataTable table, string filePath, string namePage)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(namePage);

                worksheet.Cell(1, 1).InsertTable(table, false);

                workbook.SaveAs(filePath);
            }
        }

        /// <summary>
        /// Записывает в созданный Excel файл экземпляры сущности
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="table">Все экземпляры сущности</param>
        /// <param name="filePath">Путь до файла</param>
        /// <param name="namePage">Название листа в Excel</param>
        static void WriteExcelDoc(DataTable table, string filePath, string namePage)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheets.Add(namePage);

                worksheet.Cell(1, 1).InsertTable(table, false);

                workbook.Save();
            }
        }
    }
}
