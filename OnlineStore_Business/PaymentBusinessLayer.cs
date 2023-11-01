using OnlineStore_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_BusinessLayer_
{
    public class clsPayment
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime TransactionDate { get; set; }

        public clsPayment()
        {
            this.PaymentID = -1;
            this.OrderID = -1;
            this.Amount = 0;
            this.PaymentMethod = string.Empty;
            this.TransactionDate = new DateTime();

            this._Mode = enMode.AddNew;
        }

        private clsPayment(int paymentID, int orderID, decimal amount,
            string paymentMethod, DateTime transactionDate)
        {
            this.PaymentID = paymentID;
            this.OrderID = orderID;
            this.Amount = amount;
            this.PaymentMethod = paymentMethod;
            this.TransactionDate = transactionDate;

            this._Mode = enMode.Update;
        }


        private bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentDataAccessLayer.AddNewPayment(this.OrderID,
                             this.Amount, this.PaymentMethod, this.TransactionDate);

            return (this.PaymentID != -1);
        }
        private bool _UpdatePayment()
        {
            return clsPaymentDataAccessLayer.UpdatePayment(this.PaymentID, this.OrderID,
                                  this.Amount, this.PaymentMethod, this.TransactionDate);
        }

        public static clsPayment FindPayment(int PaymentID)
        {
            int OrderID = -1;
            decimal Amount = 0;
            string PaymentMethod = string.Empty;
            DateTime TransactionDate = new DateTime();

            if (clsPaymentDataAccessLayer.GetPaymentInfoByPaymentID(PaymentID,
                ref OrderID, ref Amount, ref PaymentMethod, ref TransactionDate))
            {
                return new clsPayment(PaymentID, OrderID, Amount, PaymentMethod, TransactionDate);
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
                    return _AddNewPayment();

                case enMode.Update:
                    return _UpdatePayment();

            }

            return false;
        }

        public static bool DeletePayment(int PaymentID)
        {
            return clsPaymentDataAccessLayer.DeletePayment(PaymentID);
        }

        public static bool IsPaymentExists(int PaymentID)
        {
            return clsPaymentDataAccessLayer.IsPaymentExists(PaymentID);
        }

        public static DataView GetAllPaymentsOfSpecificPaymentMethod(string PaymentMethod)
        {
            return clsPaymentDataAccessLayer.GetAllPaymentsOfSpecificPaymentMethod(PaymentMethod);
        }

        public static DataView GetAllPaymentsOfSpecificTransactionDate(DateTime TransactionDate)
        {
            return clsPaymentDataAccessLayer.GetAllPaymentsOfSpecificTransactionDate(TransactionDate);
        }

        public static DataView GetAllPaymentsOfSpecificCustomerID(int CustomerID)
        {
            return clsPaymentDataAccessLayer.GetAllPaymentsOfSpecificCustomerID(CustomerID);
        }

        public static DataView GetAllPayments()
        {
            return clsPaymentDataAccessLayer.GetAllPayments();
        }

        public static DataView GetAllPaymentMethod()
        {
            return clsPaymentDataAccessLayer.GetAllPaymentMethod();
        }

        public static DataView SearchPaymentContainsByPaymentID(string Contains)
        {
            return clsPaymentDataAccessLayer.SearchPaymentContainsByPaymentID(Contains);
        }

        public static DataView SearchPaymentContainsByOrderID(string Contains)
        {
            return clsPaymentDataAccessLayer.SearchPaymentContainsByOrderID(Contains);
        }

        public static DataView SearchPaymentContainsByPaymentIDOfSpecificCustomer(string Contains, int CustomerID)
        {
            return clsPaymentDataAccessLayer.SearchPaymentContainsByPaymentIDOfSpecificCustomer(Contains, CustomerID);
        }

        public static DataView SearchPaymentContainsByOrderIDOfSpecificCustomer(string Contains, int CustomerID)
        {
            return clsPaymentDataAccessLayer.SearchPaymentContainsByOrderIDOfSpecificCustomer(Contains, CustomerID);
        }

        public static DataView SearchPaymentContainsByPaymentMethod(string Contains)
        {
            return clsPaymentDataAccessLayer.SearchPaymentContainsByPaymentMethod(Contains);
        }

        public static DataView SearchPaymentContainsByTransactionDate(string Contains)
        {
            return clsPaymentDataAccessLayer.SearchPaymentContainsByTransactionDate(Contains);
        }

    }
}
