using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.ServiceInterfaces;
using ERP.Model.CartObjects;
using ERP.DataTables.Tables;
using ERP.Model.DataMappers;
using ERP.Model.Utilites;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;

namespace ERP.Model
{
    public class ConfirmOrderModel : IConfirmOrderModel
    {

        private readonly ISessionService _session;

        private readonly IUnitOfWork _uOW;

        private IList<object> _cartList;


        public ConfirmOrderModel(ISessionService session, IUnitOfWork uOW)
        {

            _session = session;

            _uOW = uOW;

            _cartList = GetItemsInCart().ToList();

        }

        public string GetCurrentClientName()
        {

            return _session.CurrentClientName;

        }

        public bool CheckLoggedInStatus()
        {

            return (bool)_session.LoggedInStatus;

        }

        public bool CheckIsNavigationValid()
        {

            return (bool)_session.PreventNavigationToOrderConfirmationPage;

        }

        public void ResetSession()
        {

            _session.CurrentClientEmail = string.Empty;

            _session.CurrentClientName = string.Empty;

            _session.LoggedInStatus = false;

        }

        public void ClearOrder()
        {

            _session.ItemsInCart = null;

        }

        public IEnumerable<object> GetItemsInCart()
        {

            var itemsInCart = _session.ItemsInCart;

            return itemsInCart.ToList();

        }

        public string SaveConfirmedOrderToDB()
        {

            bool IsFirstSubmission = (bool)_session.OrderHasNotBeenSubmitted || CheckForEmptyOrder();
            if(IsFirstSubmission)
            {

                FlagOrderAsProcessed();

                int orderID = GetOrderID();

                List <ITEM> orderItems = ConvertCartToItems(orderID);

                decimal orderPrice = SumItemPrice(orderItems);

                AddOrderToDB(orderPrice, orderID);

                AddItemsToDB(orderItems);

                Attachment pdf = CreatePDF(orderItems);

                SendInvoice(pdf);

                ClearOrder();

                return "Thank you " + GetCurrentClientName() + " Your Order Has Been Placed!";

            }
            else
            {
                return "Failed To Submit! Order is Empty.";
            }    

        }

        private Attachment CreatePDF(List<ITEM> items)
        {

            DataTable table = DataTableCreator.ToDataTable(items);

            MemoryStream memoryStream = new MemoryStream();

            Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            //PdfWriter writer2 = PdfWriter.GetInstance(document, new FileStream(Path.GetTempPath() + "/myFile2.pdf", FileMode.OpenOrCreate));

            PdfPTable pdfTable = new PdfPTable(5);

            pdfTable = AddHeaders(pdfTable, table);

            pdfTable = AddRowData(pdfTable, table);

            int totalPrice = CalculateTotalPrice(table);

            document = FormatInvoice(document, pdfTable, totalPrice);

            //string path = Path.Combine(Path.GetTempPath(), "myFile.pdf");

            //StreamWriter sWriter = new StreamWriter(path);
            //sWriter.Write(memoryStream);
            //sWriter.Close();

            writer.CloseStream = false;
            //writer2.CloseStream = false;
            document.Close();
            memoryStream.Position = 0;

            Attachment attachment = new Attachment(memoryStream, "festo-invoice.pdf");

            return attachment;

        }

        private PdfPTable AddHeaders(PdfPTable pdfTable, DataTable dataTable)
        {

            List<PdfPCell> cells = new List<PdfPCell>();

            cells.Add(new PdfPCell(new Phrase("PRICE")));
            cells.Add(new PdfPCell(new Phrase("COLOUR")));
            cells.Add(new PdfPCell(new Phrase("ML's")));
            cells.Add(new PdfPCell(new Phrase("ORDERID")));
            cells.Add(new PdfPCell(new Phrase("SIZE")));

            foreach (PdfPCell cell in cells)
            {
                cell.BackgroundColor = CMYKColor.GRAY;
                pdfTable.AddCell(cell);
            }

            return pdfTable;

        }

        private PdfPTable AddRowData(PdfPTable pdfTable, DataTable dataTable)
        {

            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 1; i < dataTable.Columns.Count - 3; i++)
                {

                    PdfPCell pdfCell = new PdfPCell(new Phrase(row[i].ToString()));

                    pdfTable.AddCell(pdfCell);

                }

            }
            return pdfTable;

        }

        private int CalculateTotalPrice(DataTable datatable)
        {
            int totalPrice = 0;

            foreach (DataRow row in datatable.Rows)
            {

                totalPrice += Convert.ToInt32(row[1].ToString());

            }

            return totalPrice;
        }

        private Document FormatInvoice(Document document, PdfPTable pdfTable, int totalPrice)
        {

            string date = Convert.ToString(DateTime.Now.AddHours(1));
            string customerName = GetCurrentClientName();

            Paragraph header = new Paragraph("Festo Order Invoice");
            header.Alignment = Element.ALIGN_CENTER;
            header.Font.Size = 21;
            Paragraph header2 = new Paragraph(" ");
            Paragraph footer = new Paragraph("Total: " + totalPrice + "Kr  " + date + "");
            footer.Alignment = Element.ALIGN_CENTER;
            footer.Font.Size = 16;
            Paragraph thankyou = new Paragraph("Thank you " + customerName + " for your order!");
            thankyou.Alignment = Element.ALIGN_CENTER;
            thankyou.Font.Size = 18;
            Paragraph message = new Paragraph("Your order will be delivered shortly.");
            message.Alignment = Element.ALIGN_CENTER;
            message.Font.Size = 18;

            document.Open();
            document.Add(header);
            document.Add(header2);
            document.Add(pdfTable);
            document.Add(header2);
            document.Add(footer);
            document.Add(header2);
            document.Add(thankyou);
            document.Add(header2);
            document.Add(message);

            return document;

        }

        private void SendInvoice(Attachment attachment)
        {

            string fromAddress = "festo-orders@outlook.com";
            string toAddress = _session.CurrentClientEmail;
            string subject = "Festo Order Invoice";
            string body = "Thank you for your order! It will be delivered shortly.";

            MailMessage myMessage = new MailMessage();
            myMessage.From = new MailAddress(fromAddress);
            myMessage.To.Add(new MailAddress(toAddress));
            myMessage.Subject = subject;
            myMessage.Body = body;
            myMessage.Attachments.Add(attachment);

            SmtpClient client = new SmtpClient();
            client.Send(myMessage);

        }

        private void FlagOrderAsProcessed()
        {

            _session.OrderHasNotBeenSubmitted = false;

        }

        public bool CheckForEmptyOrder()
        {

            return _session.ItemsInCart.Count() == 0;

        }

        private int GetOrderID()
        {

            List<ORDERS> myOrders = _uOW.ORDERs.GetAllOrders().Cast<ORDERS>().ToList();

            if (myOrders.Count == 0)
            {
                return 1;
            }
            else
            {
                ORDERS lastOrder = myOrders.Last();

                return lastOrder.OrderID + 1;
            }

        }

        private List<ITEM> ConvertCartToItems(int orderID)
        {

            List<CartItem> cartItems = GetItemsInCart().Cast<CartItem>().ToList();

            return ConvertCartItemsToItems(cartItems, orderID);

        }


        private List<ITEM> ConvertCartItemsToItems(List<CartItem> cartItems, int orderID)
        {

            List<ITEM> myItems = new List<ITEM>();

            foreach (CartItem item in cartItems)
            {
                ITEM newItem = CartItemToItemMapper.ConvertCartItemToItemMapper(item, orderID);

                myItems.Add(newItem);
            }
            return myItems;

        }

        private decimal SumItemPrice(List<ITEM> orderItems)
        {
            decimal price = 0;

            foreach (ITEM item in orderItems)
            {
                price += (decimal)item.ItemPrice;
            }
            return price;
        }

        private void AddOrderToDB(decimal orderPrice, int orderID)
        {

            ORDERS myOrder = new ORDERS() { ClientID = (int)_session.CurrentClientID, OrderPrice = orderPrice };

            _uOW.ORDERs.Add(myOrder);

            _uOW.Complete();

            UpdateOrderTracker(orderID);

        }

        private void UpdateOrderTracker(int orderID)
        {

            ORDERTRACKER trackingInfo = new ORDERTRACKER()
            { OrderID = orderID, OrderStatus = 0, TimeStamp = DateTime.Now };

            _uOW.ORDERs.UpdateOrderTracker(trackingInfo);

            _uOW.Complete();

        }

        private void AddItemsToDB(List<ITEM> orderItems)
        {

            _uOW.ITEMs.InsertAllItemsToDB(orderItems);

            _uOW.Complete();

            UpdateItemTracker(orderItems);

        }


        private void UpdateItemTracker(List<ITEM> orderItems)
        {
            foreach(ITEM item in orderItems)
            {
                ITEMTRACKER trackingInfo = new ITEMTRACKER()
                { ItemID = item.ItemID, OrderID = item.OrderID, ItemStatus = 0, TimeStamp = DateTime.Now, MeasuredWeight= null};

                _uOW.ORDERs.UpdateItemTracker(trackingInfo);

                _uOW.Complete();
            }

        }

    }
}
