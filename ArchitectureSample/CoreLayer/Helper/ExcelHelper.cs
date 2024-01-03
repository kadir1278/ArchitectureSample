using CoreLayer.Entity.ViewModel.FileViewModel;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helper
{
    public static class ExcelHelper
    {
        private const string _excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public static IDataResult<DownloadFileViewModel> Create<T>(IEnumerable<T> excelDatas)
        {
            try
            {
                if (excelDatas.Count() == 0)
                    return new ErrorDataResult<DownloadFileViewModel>("Model is empty");
                var listProperties = typeof(T).GetProperties();
                MemoryStream memoryStream;

                using (var workBook = new XSSFWorkbook())
                {
                    ISheet sheet = workBook.CreateSheet("Main");
                    IRow rowHeader = sheet.CreateRow(0);

                    int columIndex = 0;

                    foreach (var prop in listProperties)
                    {
                        var cell = rowHeader.CreateCell(columIndex);
                        cell.SetCellValue(prop.Name);
                        columIndex++;
                    }
                    int rowIndex = 1;
                    foreach (var item in excelDatas)
                    {
                        IRow rowContent = sheet.CreateRow(rowIndex);
                        int colContentIndex = 0;
                        foreach (var property in listProperties)
                        {
                            var cellContent = rowContent.CreateCell(colContentIndex);
                            var value = property.GetValue(item, null);

                            if (value is null)
                                cellContent.SetCellValue("");
                            else if (property.PropertyType == typeof(string))
                                cellContent.SetCellValue(value.ToString());
                            else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                                cellContent.SetCellValue(Convert.ToInt32(value));
                            else if (property.PropertyType == typeof(decimal) || property.PropertyType == typeof(decimal?))
                                cellContent.SetCellValue(Convert.ToDouble(value));
                            else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                            {
                                var dateValue = (DateTime)value;
                                cellContent.SetCellValue(dateValue.ToString("yyyy-MM-dd"));
                            }
                            else cellContent.SetCellValue(value.ToString());

                            colContentIndex++;
                        }

                        rowIndex++;
                    }

                    memoryStream = new MemoryStream();
                    workBook.Write(memoryStream, true);
                    memoryStream.Position = 0;
                }
                return new SuccessDataResult<DownloadFileViewModel>(new DownloadFileViewModel()
                {
                    File = memoryStream,
                    FileName = $"Output_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx",
                    ContentType = _excelContentType
                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<DownloadFileViewModel>(ex);
            }
        }
        public static IDataResult<DownloadFileViewModel> Create<T>(List<string[]> headerRows, IEnumerable<T> excelDatas)
        {
            try
            {
                if (excelDatas.Count() == 0)
                    return new ErrorDataResult<DownloadFileViewModel>("Model is empty");

                if (headerRows.Count() == 0)
                    return new ErrorDataResult<DownloadFileViewModel>("Headers is empty");

                var listProperties = typeof(T).GetProperties();
                XSSFWorkbook workBook = new XSSFWorkbook();
                MemoryStream memoryStream;
                ISheet sheet = workBook.CreateSheet("Main");

                foreach (var prop in headerRows)
                {
                    IRow rowHeader = sheet.CreateRow(headerRows.IndexOf(prop));
                    int columIndex = 0;
                    foreach (var value in prop)
                    {
                        var cell = rowHeader.CreateCell(columIndex);
                        cell.SetCellValue(value);
                        columIndex++;
                    }
                }
                int rowIndex = headerRows.Count();
                foreach (var item in excelDatas)
                {
                    IRow rowContent = sheet.CreateRow(rowIndex);
                    int colContentIndex = 0;
                    foreach (var property in listProperties)
                    {
                        var cellContent = rowContent.CreateCell(colContentIndex);
                        var value = property.GetValue(item, null);

                        if (value is null)
                            cellContent.SetCellValue("");
                        else if (property.PropertyType == typeof(string))
                            cellContent.SetCellValue(value.ToString());
                        else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                            cellContent.SetCellValue(Convert.ToInt32(value));
                        else if (property.PropertyType == typeof(decimal) || property.PropertyType == typeof(decimal?))
                            cellContent.SetCellValue(Convert.ToDouble(value));
                        else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                        {
                            var dateValue = (DateTime)value;
                            cellContent.SetCellValue(dateValue.ToString("yyyy-MM-dd"));
                        }
                        else cellContent.SetCellValue(value.ToString());

                        colContentIndex++;
                    }

                    rowIndex++;
                }
                memoryStream = new MemoryStream();
                workBook.Write(memoryStream, true);
                memoryStream.Position = 0;
                return new SuccessDataResult<DownloadFileViewModel>(new DownloadFileViewModel()
                {
                    File = memoryStream,
                    FileName = $"Output_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx",
                    ContentType = _excelContentType
                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<DownloadFileViewModel>(ex);
            }
        }

    }
}
