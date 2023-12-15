using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using ScannerFinalPDF.Model.Data;

namespace ScannerFinalPDF.Model.Documents
{
    class Nakladnay_Excel
    {
        public void CreateNakladnDoc(string filePath, List<Zayvka> zayvkas)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo fileInfo = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Накладная");
                worksheet.Cells["A1"].Value = "Номер заявки";
                worksheet.Cells["B1"].Value = "Трек-номер";
                for(int i = 0; i < zayvkas.Count; i++)
                {
                    worksheet.Cells["A" + (i + 2)].Value = zayvkas[i].NameRequest; // Предположим, что у вас есть свойство NomZayvki для номера заявки
                    worksheet.Cells["B" + (i + 2)].Value = zayvkas[i].NumberTruck; // Предположим, что у вас есть свойство TrackNumber для трек-номера
                }
                package.Save();
            }
        }
    }
}
