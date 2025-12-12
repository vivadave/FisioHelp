using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;

namespace FisioHelp.Helper
{
  public class ExcelManagement
  {
    public static void CreateExel(string path, List<DataModels.ProformaInvoice> proformaInvoices)
    {
      var excelApp = new Application();

      Workbook wbook = excelApp.Workbooks.Add();
      Worksheet worksheet = wbook.ActiveSheet;
      int i = 1;
      //Header
      worksheet.Cells[i, 1] =  "N° fattura";
      worksheet.Cells[i, 2] = "Nome cliente";
      worksheet.Cells[i, 3] = "Data fatturazione";
      worksheet.Cells[i, 4] = "Data pagamento";
      worksheet.Cells[i, 5] = "Fatturato";

      i = 3;

      proformaInvoices = proformaInvoices.Where(x => x.Invoice != null).OrderBy(x => x.Invoice.Title).ToList();
      double total = 0;
      foreach (var proformaInvoice in proformaInvoices)
      {
        worksheet.Cells[i, 1] = proformaInvoice.Invoice.Title;
        worksheet.Cells[i, 2] = proformaInvoice.CustomerName;
        worksheet.Cells[i, 3] = ((DateTime)proformaInvoice.Invoice.Date).ToShortDateString();
        worksheet.Cells[i, 4] = proformaInvoice.PayedDate != null ? ((DateTime)proformaInvoice.PayedDate).ToShortDateString() : "";
        worksheet.Cells[i, 5] = proformaInvoice.Total;
        worksheet.Cells[i, 5].NumberFormat = "#.##0,00 €";
        total += proformaInvoice.Total;
        i++;
      }
      var range = worksheet.get_Range("A1", $"E{i}");
      range.Columns.AutoFit();
      try
      {
        wbook.SaveAs(path);
      }
      catch (Exception)
      {
        //do something
      }
      finally
      {
        wbook.Close();
      }
    }
  }
}
