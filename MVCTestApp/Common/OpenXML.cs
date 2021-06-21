using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace MVCTestApp.Common
{
    public class OpenXML
    {

        public static void CreateOpenXMLExcelSheet()
        {
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(@"C:\Temp\OpenXMLWorkbook.xlsx", SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "mySheet" };
            sheets.Append(sheet);

            SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

            Row row;
            row = new Row() { RowIndex = 1 };
            sheetData.Append(row);

            // In the new row, find the column location to insert a cell in A1.  
            Cell refCell = null;
            foreach (Cell cell in row.Elements<Cell>())
            {
                if (string.Compare(cell.CellReference.Value, "A1", true) > 0)
                {
                    refCell = cell;
                    break;
                }
            }

            // Add the cell to the cell table at A1.
            Cell newCell = new Cell() { CellReference = "A1" };
            row.InsertBefore(newCell, refCell);

            // Set the cell value to be a numeric value of 100.
            newCell.CellValue = new CellValue("100");
            newCell.DataType = new EnumValue<CellValues>(CellValues.Number);

            workbookpart.Workbook.Save();

            // Close the document.
            spreadsheetDocument.Close();
        }

        public static void CreateOpenXMLExcelSheet2()
        {
            string filePath = @"C:\Temp\OpenXMLWorkbook2.xlsx";
            SpreadsheetDocument ssdoc = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook);

            WorkbookPart wbp = ssdoc.AddWorkbookPart();
            wbp.Workbook = new Workbook();

            WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
            wsp.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = ssdoc.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            Sheet sheet = new Sheet()
            {
                Id = ssdoc.WorkbookPart.GetIdOfPart(wsp),
                SheetId = 1,
                Name = "Sample Data"
            };

            sheets.Append(sheet);

            Worksheet ws = wsp.Worksheet;
            SheetData sheetData = ws.GetFirstChild<SheetData>();

            for(int i = 0;  i< 100; i++)
            {
                Row r = new Row();

                for (int c=0; c < 10; c++)
                {
                    Cell cl = new Cell()
                    {
                        CellValue = new CellValue(c.ToString()),
                        DataType = CellValues.String
                    };

                    r.Append(cl);
                }
                sheetData.Append(r);
            }

            wsp.Worksheet.Save();
            ssdoc.Close();            
        }
    
    }
}