using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_WindowsForms_
{
    public class clsOrderCartInfo
    {
        public static DataTable OrderCartItem { get; set; }
        public static int Quantity { get; set; }
        public static decimal TotalPrice { get; set; }

        static clsOrderCartInfo()
        {
            InitializeOrderCartItem();
        }

        private static void InitializeOrderCartItem()
        {
            OrderCartItem = new DataTable();

            // Add columns
            OrderCartItem.Columns.Add("ID", typeof(int));
            OrderCartItem.Columns.Add("ProductName", typeof(string));
            OrderCartItem.Columns.Add("Quantity", typeof(int));
            OrderCartItem.Columns.Add("Price", typeof(decimal));
            OrderCartItem.Columns.Add("IsDeleted", typeof(bool));

            // Make ID Column the primary key column
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = OrderCartItem.Columns["ID"];
            OrderCartItem.PrimaryKey = PrimaryKeyColumns;

            // Make the Primary key auto numbering
            OrderCartItem.Columns["ID"].AutoIncrement = true;
            OrderCartItem.Columns["ID"].AutoIncrementSeed = 1;
            OrderCartItem.Columns["ID"].AutoIncrementStep = 1;
        }

    }
}
