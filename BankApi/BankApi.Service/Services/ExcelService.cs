using ClosedXML.Excel;

namespace BankApi.Service.Services
{
    public static class ExcelService
    {
        /// <summary>
        /// Создает excel документ с указанным типом сущности
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="table">Все экземпляры сущности</param>
        /// <param name="filePath">Путь до файла</param>
        /// <param name="namePage">Название листа в Excel</param>
        public static void CreateExcelDoc<T>(IEnumerable<T> table, string filePath, string namePage)
        {
            if (!File.Exists(filePath))
                CreateAndWriteExcelDoc(table, filePath, namePage);
            else
                WriteExcelDoc(table, filePath, namePage);
        }

        /// <summary>
        /// Создает excel файл и записывает экземпляры сущности
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="table">Все экземпляры сущности</param>
        /// <param name="filePath">Путь до файла</param>
        /// <param name="namePage">Название листа в Excel</param>
        static void CreateAndWriteExcelDoc<T>(IEnumerable<T> table, string filePath, string namePage)
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
        static void WriteExcelDoc<T>(IEnumerable<T> table, string filePath, string namePage)
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
