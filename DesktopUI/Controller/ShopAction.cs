using DesktopUI.Models;
using DesktopUI.Views;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Controller
{
    public sealed class ShopAction
    {
        delegate void Save(string Cashier, string salesid);
        private ProductRepository repository => ProductRepository.instance;
        private static DataGridView gridView;
        private static BindingSource bindingsource;
        private static DataGridView shoppingCart;
        private ShopAction _shopAction;
        private static Button ResetButton;
        private SalesRepository salesRepository => SalesRepository.instance;
        public static Dictionary<string, string> ParameterList { get; set; } = new Dictionary<string, string>();
        public ShopAction(BindingSource bindingSource, DataGridView gridView, Button resetButton)
            : base()
        {
            ShopAction.gridView = gridView;
            bindingsource = bindingSource;
            _shopAction = this;
            ResetButton = resetButton;
        }
        public void ToggleAddToCart(OrderDetails shopping)
        {
            var index = default(int);
            if (isItemAdded(shopping.ProductName, ref index))
            {
                //var detail = bindingsource.List[gridView.DataSource(index)] as OrderDetails;
                //var qty = detail.Quantity + shopping.Quantity;
                        return;
            }
            
            bindingsource.EndEdit();
        }
        private static async Task<DataTable> ExtractSalesData(GridView shoppingCart)
        {

            var Cart = shoppingCart;
            return await Task.Run(() =>
            {
                var data = new OrderSet().Tables[0];
                for (int i = 0; i < Cart.RowCount; i++)
                {
                    var row = data.NewRow();
                    row["Product Name"] = Cart.GetRowCellValue(i, "ProductName");
                    row["Unit Price"] = Cart.GetRowCellValue(i, "Price");
                    row["Qty"] = Cart.GetRowCellValue(i, "Quantity");
                    row["Sub Total"] = Cart.GetRowCellValue(i, "Total");
                    data.Rows.Add(row);
                }
                return data;
            });

        }
        public static async Task RunPrintWorker() => await Task.Run(() => Print());

        private static async void Print()
        {
            var parameter = new Parameters
            {
                AmountPaid = ParameterList["pPaid"],
                ShopName = ParameterList["pShopName"],
                Balance = ParameterList["pBal"],
                Cashier = ParameterList["pCashierId"],
                SalesId = ParameterList["pSalesId"]
            };
            var validator = new ParametersValidator();
            var result = validator.Validate(parameter);
            if (parameter != null)
            {
                var report = new Receipt();
               // report.DataSource = await ExtractSalesData(gridView);
                ReciptWrapper.Init(report, parameter);
                ReciptWrapper.InitPrint();
            }
            else
            {
               
                    MessageBox.Show("Error");
                
            }
        }
        private bool isItemAdded(string ProductName, ref int index)
        {
            var response = false;
            if (bindingsource.Count > 0)
            {
                foreach (OrderDetails item in bindingsource)
                {
                    if (item.ProductName == ProductName)
                    {
                        index = bindingsource.IndexOf(item);
                        response = true;
                        break;
                    }
                }
            }
            return response;
        }

        public void SaveShoppingDetails(string cashier, string salesid)
        {
            var saveDelegate = new Save(save);
            saveDelegate.BeginInvoke(cashier, salesid, Completed, null);
        }
        private void save(string Cashier, string salesid)
        {
            foreach (OrderDetails item in bindingsource.List)
            {
                salesRepository.Add(new OrderModel
                {
                    ProductName = item.ProductName,
                  //  Quantity = item.Quantity,
                    Price = item.Price,
                    SalesId = salesid,
                    SubTotal = item.SubTotal,
                   //ProductId = ID,
                    SalesDate = DateTime.Today,
                    Cashier = Cashier
                });
                //var product = repository.List.FirstOrDefault(p => p.Product_Name == item.ProductName);
                //if (product.Quantity == 0 && product.Cost_Price == 0)
                //    continue;
                //repository.UpdateQuantity(item.ProductName, item.Quantity);
            }
        }
        private void Completed(IAsyncResult asyncResult)
        {
            if (asyncResult.IsCompleted)
            {
                repository.SaveChanges();
                ResetButton.Invoke((MethodInvoker)delegate { ResetButton.PerformClick(); });
            }
        }

    }
}


