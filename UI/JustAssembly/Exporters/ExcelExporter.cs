using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustAssembly.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;

namespace JustAssembly.Exporters
{
	class ExcelExporter: IExporter
	{
		private readonly ITabSourceItem _tab;
		private List<string> _assemblies;
		private IExportData _data;

		public ExcelExporter(ITabSourceItem tab)
		{
			_tab = tab;
			_assemblies = new List<string>();
			LoadNodes();
		}

		private void LoadNodes()
		{
			_tab.ExportContent(out _data);
		}

		public void SaveTo(string path)
		{
			
			using (SpreadsheetDocument document = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook))
			{
				WorkbookPart workbookPart = document.AddWorkbookPart();
				workbookPart.Workbook = new Workbook();

				WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
				worksheetPart.Worksheet = new Worksheet(new SheetData());

				Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

				Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Test Sheet" };

				SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
				sheetData.Append(new Row() {RowIndex = 1});
				sheet.a
				var row = new Row();

				sheets.Append(sheet);

				workbookPart.Workbook.Save();
			}
		}
	}
}
