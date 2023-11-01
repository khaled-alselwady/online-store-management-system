using OnlineStore_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_BusinessLayer_
{
    public class clsOrder
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        public clsOrder()
        {
            this.OrderID = -1;
            this.CustomerID = -1;
            this.OrderDate = new DateTime();
            this.TotalAmount = 0;
            this.Status = string.Empty;

            this._Mode = enMode.AddNew;
        }

        private clsOrder(int OrderID, int CustomerID, DateTime OrderDate,
            decimal TotalAmount, string Status)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.TotalAmount = TotalAmount;
            this.Status = Status;

            this._Mode = enMode.Update;
        }

        private bool _AddNewOrder()
        {
            this.OrderID = clsOrderDataAccessLayer.AddNewOrder(this.CustomerID,
                this.OrderDate, this.TotalAmount, this.Status);

            return (this.OrderID != -1);
        }
        private bool _UpdateOrder()
        {
            return clsOrderDataAccessLayer.UpdateOrder(this.OrderID,
                this.CustomerID, this.OrderDate, this.TotalAmount, this.Status);
        }

        public static clsOrder FindOrder(int OrderID)
        {
            int CustomerID = -1;
            DateTime OrderDate = new DateTime();
            decimal TotalAmount = 0;
            string Status = string.Empty;

            if (clsOrderDataAccessLayer.GetOrderInfoByOrderID(OrderID,
                ref CustomerID, ref OrderDate, ref TotalAmount, ref Status))
            {
                return new clsOrder(OrderID, CustomerID, OrderDate, TotalAmount, Status);
            }
            else
            {
                return null;
            }

        }

        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.AddNew:
                    return _AddNewOrder();
                case enMode.Update:
                    return _UpdateOrder();

            }

            return false;

        }

        public static bool DeleteOrder(int OrderID)
        {
            return clsOrderDataAccessLayer.DeleteOrder(OrderID);
        }

        public static bool IsOrderExistsByOrderID(int OrderID)
        {
            return clsOrderDataAccessLayer.IsOrderExistsByOrderID(OrderID);
        }

        public static bool IsOrderExistsByCustomerID(int CustomerID)
        {
            return clsOrderDataAccessLayer.IsOrderExistsByCustomerID(CustomerID);
        }

        public static DataView GetAllOrdersOfSpecificCustomer(int CustomerID)
        {
            return clsOrderDataAccessLayer.GetAllOrdersOfSpecificCustomer(CustomerID);
        }

        public static DataView GetAllOrdersWithSpecificStatus(string Status, int CustomerID)
        {
            return clsOrderDataAccessLayer.GetAllOrdersWithSpecificStatus(Status, CustomerID);
        }

        public static DataView GetAllOrders()
        {
            return clsOrderDataAccessLayer.GetAllOrders();
        }

        public static DataView GetOrdersOfSpecificCustomerForPayment(int CustomerID)
        {
            return clsOrderDataAccessLayer.GetOrdersOfSpecificCustomerForPayment(CustomerID);
        }

        public static DataView GetAllStatusOrder()
        {
            return clsOrderDataAccessLayer.GetAllStatusOrder();
        }

        public static DataView SearchOrderContainsByOrderID(string Contains)
        {
            return clsOrderDataAccessLayer.SearchOrderContainsByOrderID(Contains);
        }

        public static DataView SearchOrderContainsByCustomerID(string Contains)
        {
            return clsOrderDataAccessLayer.SearchOrderContainsByCustomerID(Contains);
        }

        public static DataView SearchOrderContainsByStatus(string Contains)
        {
            return clsOrderDataAccessLayer.SearchOrderContainsByStatus(Contains);
        }

        public static DataView SearchOrderContainsByOrderIDWithoutCustomerIDColumn(string Contains, int CustomerID, string StatusName)
        {
            return clsOrderDataAccessLayer.SearchOrderContainsByOrderIDWithoutCustomerIDColumn(Contains, CustomerID, StatusName);
        }

        public static DataView SearchOrderContainsByOrderDateWithoutCustomerIDColumn(string Contains, int CustomerID, string StatusName)
        {
            return clsOrderDataAccessLayer.SearchOrderContainsByOrderDateWithoutCustomerIDColumn(Contains, CustomerID, StatusName);
        }

        public static DataView SearchOrdersOfSpecificCustomerForPayment(string Contains, int CustomerID)
        {
            return clsOrderDataAccessLayer.SearchOrdersOfSpecificCustomerForPayment(Contains, CustomerID);
        }
    }
}
