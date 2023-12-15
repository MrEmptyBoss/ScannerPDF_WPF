using OfficeOpenXml;
using ScannerFinalPDF.Model.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerFinalPDF.Model.Documents
{
    class Report_Excel
    {
        public void CreateReportDoc(string filePath, List<Zayvka> zayvkas)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo fileInfo = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Накладная");
                worksheet.Cells["A1"].Value = "РЦ";
                worksheet.Cells["B1"].Value = "ФИО";
                worksheet.Cells["C1"].Value = "Номер заявки";
                worksheet.Cells["D1"].Value = "Тип срочности";
                worksheet.Cells["E1"].Value = "Номер магазина";
                worksheet.Cells["F1"].Value = "Дата и время приема заявки";
                worksheet.Cells["G1"].Value = "Дата и время доставки заявки на РЦ";
                worksheet.Cells["H1"].Value = "Дата и время закрытия заявки";
                worksheet.Cells["I1"].Value = "% заливки";
                worksheet.Cells["J1"].Value = "Длина";
                worksheet.Cells["K1"].Value = "Ширина";
                worksheet.Cells["L1"].Value = "Кол-во отпечатков";
                worksheet.Cells["M1"].Value = "Кол во квадратных метров всех отпечатков";
                worksheet.Cells["N1"].Value = "Плановая дата поставки";
                worksheet.Cells["O1"].Value = "Трек-номер доставки";

                for (int i = 0; i < zayvkas.Count; i++)
                {
                    List<Maket> makets = DataWorker.GetMaketsId(zayvkas[i].Id);
                    for (int j = 0; j < makets.Count; j++)
                    {
                        worksheet.Cells["A" + (i + j  + 2)].Value = DataWorker.GetRSid(zayvkas[i].RsId).Name;
                        worksheet.Cells["B" + (i + j  + 2)].Value = DataWorker.GetSotrId(zayvkas[i].SotrId).Fio;
                        worksheet.Cells["C" + (i + j + 2)].Value = zayvkas[i].NameRequest;
                        worksheet.Cells["D" + (i + j + 2)].Value = DataWorker.GetSrokiId(zayvkas[i].SrokiId).Name;
                        worksheet.Cells["E" + (i + j + 2)].Value = zayvkas[i].NShop;
                        worksheet.Cells["F" + (i + j + 2)].Value = zayvkas[i].DatePriem;
                        worksheet.Cells["G" + (i + j + 2)].Value = zayvkas[i].DateDostav;
                        worksheet.Cells["H" + (i + j + 2)].Value = zayvkas[i].DateClose;
                        worksheet.Cells["F" + (i + j + 2)].Style.Numberformat.Format = "dd.mm.yyyy hh:mm";
                        worksheet.Cells["G" + (i + j + 2)].Style.Numberformat.Format = "dd.mm.yyyy hh:mm";
                        worksheet.Cells["H" + (i + j + 2)].Style.Numberformat.Format = "dd.mm.yyyy hh:mm";
                        worksheet.Cells["I" + (i + j + 2)].Value = makets[j].Fill;
                        worksheet.Cells["J" + (i + j + 2)].Value = makets[j].Length;
                        worksheet.Cells["K" + (i + j + 2)].Value = makets[j].Width;
                        worksheet.Cells["L" + (i + j + 2)].Value = makets[j].Count;
                        worksheet.Cells["M" + (i + j + 2)].Value = makets[j].Kvadr;
                        worksheet.Cells["N" + (i + j + 2)].Value = zayvkas[i].DatePlanov;
                        worksheet.Cells["N" + (i + j + 2)].Style.Numberformat.Format = "dd.mm.yyyy";
                        worksheet.Cells["O" + (i + j + 2)].Value = zayvkas[i].NumberTruck;
                    }
                }
                package.Save();
            }
        }
    }
}
