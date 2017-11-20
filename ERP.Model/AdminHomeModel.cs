using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.ServiceInterfaces;
using ERP.Common.Enums;
using ERP.Common.FactoryInterfaces;
using ERP.DataTables.Tables;
using ERP.Model.Utilites;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;



namespace ERP.Model
{
    public class AdminHomeModel : IAdminHomeModel
    {

        private readonly ISessionService _session;

        private readonly IFetchDataFactory _factory;

        DataTable _dataTable;


        public AdminHomeModel(ISessionService session, IFetchDataFactory factory)
        {

            _session = session;

            _factory = factory;

        }

        public string GetCurrentClientName()
        {

            return _session.CurrentClientName;

        }

        public bool CheckLoggedInStatus()
        {

            return (bool)_session.LoggedInStatus;

        }

        public void ResetSession()
        {

            _session.CurrentClientEmail = string.Empty;

            _session.CurrentClientName = string.Empty;

            _session.LoggedInStatus = false;

        }

        public void SetSelectedOrderIdToSession(int orderId)
        {

            _session.SelectedOrderId = orderId;

        }

        public int GetSelectedOrderIdFromSession()
        {

            int? orderId = _session.SelectedOrderId;

            return (int)orderId;

        }

        public IEnumerable<object> FetchOrderData(OrdersToFetch ordersToFetch)
        {

            SetLastButtonPressed((int)ordersToFetch);

            var data = _factory.FetchDataForAdmin(ordersToFetch);

            return data;

        }

        public string FetchOrderDataInfoMessage(OrdersToFetch ordersToFetch)
        {

            var info = _factory.FetchAdminOrderDataInfoMessage(ordersToFetch);

            return info;

        }

        public IEnumerable<object> FetchItemsData(ItemsToFetch itemsToFetch)
        {

            SetLastButtonPressed((int)itemsToFetch + 10);

            int orderId = GetSelectedOrderIdFromSession();

            var data = _factory.FetchOrderItemData(itemsToFetch, orderId);

            return data;

        }

        public string FetchItemDataInfoMessage(ItemsToFetch itemsToFetch)
        {

            var info = _factory.FetchItemDataInfoMessage(itemsToFetch);

            return info;

        }

        public string GetNumberOfFailedItems()
        {

            var data = _factory.FetchProductionData(DataToFetch.NumberOfItemsFailed);

            return data;

        }

        public string GetNumberOfCompleteItems()
        {

            var data = _factory.FetchProductionData(DataToFetch.NumberOfItemsCompleted);

            return data;

        }

        public string GetNumberOfCompleteOrders()
        {

            var data = _factory.FetchProductionData(DataToFetch.NumberOfOrdersCompleted);

            return data;

        }

        public string GetAvgTimeToProduceAnItem()
        {

            var data = _factory.FetchProductionData(DataToFetch.AvgTimeToProduceAnItem);

            return  data;

        }


        public void GetPDF()
        {

            GenerateDataAccordingToLastButtonPressed();

            if(_dataTable.Rows.Count != 0)
            {

                ConvertPdfToByteArray();
            }        

        }

        public void GenerateDataAccordingToLastButtonPressed()
        {

            int buttonPressed = GetLastButtonPressed();

            if (buttonPressed >= 10)
            {

                buttonPressed = buttonPressed - 10;

                ItemsToFetch itemsToFetch = (ItemsToFetch)buttonPressed;

                int orderId = GetSelectedOrderIdFromSession();

                var data = _factory.FetchOrderItemData(itemsToFetch, orderId);

                _dataTable = DataTableCreator.ToDataTable(data.Cast<ITEM>().ToList());

            }
            else
            {

                OrdersToFetch ordersToFetch = (OrdersToFetch)buttonPressed;

                var data = _factory.FetchDataForAdmin(ordersToFetch);

                _dataTable = DataTableCreator.ToDataTable(data.Cast<ORDERS>().ToList());

            }

        }


        public void SetLastButtonPressed(int buttonNumber)
        {

            _session.ButtonLastPressed = buttonNumber;

        }

        public int GetLastButtonPressed()
        {

            return _session.ButtonLastPressed;

        }

        public void SetFile(byte[] file)
        {

            _session.file = file;

        }

        private void ConvertPdfToByteArray()
        {

            using (MemoryStream memoryStream = new MemoryStream())
            {

                Document document = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);

                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                PdfPTable pdfTable = new PdfPTable((_dataTable.Columns.Count - 3));

                pdfTable = AddHeaders(pdfTable, _dataTable);

                pdfTable = AddRowData(pdfTable, _dataTable);

                document = FormatInvoice(document, pdfTable);

                writer.CloseStream = false;
                document.Close();

                byte[] fileAsBytes = memoryStream.ToArray();

                SetFile(fileAsBytes);

            }       
        }

        private PdfPTable AddHeaders(PdfPTable pdfTable, DataTable dataTable)
        {

            for (int i = 0; i < (dataTable.Columns.Count - 3); i++)
            {

                  DataColumn col = _dataTable.Columns[i];
                  PdfPCell pdfCell = new PdfPCell(new Phrase(col.ColumnName));
                  pdfCell.BackgroundColor = CMYKColor.GRAY;
                  pdfTable.AddCell(pdfCell);

            }
            return pdfTable;

        }

        private PdfPTable AddRowData(PdfPTable pdfTable, DataTable dataTable)
        {

            foreach (DataRow row in dataTable.Rows)
            {
                
                for (int i = 0; i < (dataTable.Columns.Count - 3); i++)
                {

                    PdfPCell pdfCell = new PdfPCell(new Phrase(row[i].ToString()));

                    pdfTable.AddCell(pdfCell);

                }

            }
            return pdfTable;

        }

        private Document FormatInvoice(Document document, PdfPTable pdfTable)
        {

            string date = Convert.ToString(DateTime.Now.AddHours(1));
            string customerName = GetCurrentClientName();

            Paragraph header = new Paragraph("Festo Production Data");
            header.Alignment = Element.ALIGN_CENTER;
            header.Font.Size = 21;
            Paragraph header2 = new Paragraph(" ");
            Paragraph footer = new Paragraph("" + date + "");
            footer.Alignment = Element.ALIGN_CENTER;
            footer.Font.Size = 16;

            document.Open();
            document.Add(header);
            document.Add(header2);
            document.Add(pdfTable);
            document.Add(header2);
            document.Add(footer);

            return document;

        }
    }
}
