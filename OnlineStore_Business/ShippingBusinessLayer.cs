using OnlineStore_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_BusinessLayer_
{
    public class clsShipping
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode = enMode.AddNew;

        public int ShippingID { get; set; }
        public int OrderID { get; set; }
        public string CarrierName { get; set; }
        public string TrackingNumber { get; set; }
        public string ShippingStatus { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public DateTime ActualDeliveryDate { get; set; }

        public clsShipping()
        {
            this.ShippingID = -1;
            this.OrderID = -1;
            this.CarrierName = string.Empty;
            this.TrackingNumber = string.Empty;
            this.ShippingStatus = string.Empty;
            this.EstimatedDeliveryDate = new DateTime();
            this.ActualDeliveryDate = new DateTime();

            this._Mode = enMode.AddNew;
        }

        private clsShipping(int ShippingID, int OrderID, string CarrierName,
             string TrackingNumber, string ShippingStatus,
            DateTime EstimatedDeliveryDate, DateTime ActualDeliveryDate)
        {
            this.ShippingID = ShippingID;
            this.OrderID = OrderID;
            this.CarrierName = CarrierName;
            this.TrackingNumber = TrackingNumber;
            this.ShippingStatus = ShippingStatus;
            this.EstimatedDeliveryDate = EstimatedDeliveryDate;
            this.ActualDeliveryDate = ActualDeliveryDate;

            this._Mode = enMode.Update;
        }

        private bool _AddNewShipping()
        {
            this.ShippingID = clsShippingDataAccessLayer.AddNewShipping(this.OrderID,
                this.CarrierName, this.TrackingNumber, this.ShippingStatus,
                this.EstimatedDeliveryDate, this.ActualDeliveryDate);

            return (this.ShippingID != -1);
        }

        private bool _UpdateShipping()
        {
            return clsShippingDataAccessLayer.UpdateShipping(this.ShippingID, this.OrderID,
                this.CarrierName, this.TrackingNumber, this.ShippingStatus,
                this.EstimatedDeliveryDate, this.ActualDeliveryDate);
        }


        public static clsShipping FindShipping(int ShippingID)
        {
            int OrderID = -1;

            string CarrierName = string.Empty;
            string TrackingNumber = string.Empty;
            string ShippingStatus = string.Empty;

            DateTime EstimatedDeliveryDate = new DateTime();
            DateTime ActualDeliveryDate = new DateTime();

            if (clsShippingDataAccessLayer.GetShippingInfoByShippingID(ShippingID,
                ref OrderID, ref CarrierName, ref TrackingNumber, ref ShippingStatus,
                ref EstimatedDeliveryDate, ref ActualDeliveryDate))
            {
                return new clsShipping(ShippingID, OrderID, CarrierName, TrackingNumber,
                    ShippingStatus, EstimatedDeliveryDate, ActualDeliveryDate);
            }
            else
            {
                return null;
            }
        }

        public static clsShipping FindShipping(string TrackingNumber)
        {
            int ShippingID = -1;
            int OrderID = -1;

            string CarrierName = string.Empty;
            string ShippingStatus = string.Empty;

            DateTime EstimatedDeliveryDate = new DateTime();
            DateTime ActualDeliveryDate = new DateTime();

            if (clsShippingDataAccessLayer.GetShippingInfoByTrackingNumber(TrackingNumber,
                ref ShippingID, ref OrderID, ref CarrierName, ref ShippingStatus,
                ref EstimatedDeliveryDate, ref ActualDeliveryDate))
            {
                return new clsShipping(ShippingID, OrderID, CarrierName, TrackingNumber,
                    ShippingStatus, EstimatedDeliveryDate, ActualDeliveryDate);
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
                    return _AddNewShipping();

                case enMode.Update:
                    return _UpdateShipping();

            }

            return false;
        }

        public static bool DeleteShipping(int ShippingID)
        {
            return clsShippingDataAccessLayer.DeleteShipping(ShippingID);
        }

        public static bool IsShippingExists(int ShippingID)
        {
            return clsShippingDataAccessLayer.IsShippingExists(ShippingID);
        }

        public static bool IsShippingExists(string TrackingNumber)
        {
            return clsShippingDataAccessLayer.IsShippingExists(TrackingNumber);
        }

        public static DataView GetAllShippingsFromSpecificCompany(string CarrierName)
        {
            return clsShippingDataAccessLayer.GetAllShippingsFromSpecificCompany(CarrierName);
        }

        public static DataView GetAllShippingsOfSpecificCustomer(int CustomerID)
        {
            return clsShippingDataAccessLayer.GetAllShippingsOfSpecificCustomer(CustomerID);
        }

        public static DataView GetAllShippings()
        {
            return clsShippingDataAccessLayer.GetAllShippings();
        }

        public static DataView GetAllShippingsStatus()
        {
            return clsShippingDataAccessLayer.GetAllShippingStatus();
        }

        public static DataView SearchShippingContainsByShippingID(string Contains)
        {
            return clsShippingDataAccessLayer.SearchShippingContainsByShippingID(Contains);
        }

        public static DataView GetAllOderIDThatDoNotHaveAShippng()
        {
            return clsShippingDataAccessLayer.GetAllOderIDThatDoNotHaveAShippng();
        }

        public static DataView SearchShippingContainsByOrderID(string Contains)
        {
            return clsShippingDataAccessLayer.SearchShippingContainsByOrderID(Contains);
        }

        public static DataView SearchShippingContainsByTrackingNumber(string Contains)
        {
            return clsShippingDataAccessLayer.SearchShippingContainsByTrackingNumber(Contains);
        }

        public static DataView SearchShippingContainsByShippingIDOfSpecificCustomer(string Contains, int CustomerID, string ShippingStatus)
        {
            return clsShippingDataAccessLayer.SearchShippingContainsByShippingIDOfSpecificCustomer(Contains, CustomerID, ShippingStatus);
        }

        public static DataView SearchShippingContainsByOrderIDOfSpecificCustomer(string Contains, int CustomerID, string ShippingStatus)
        {
            return clsShippingDataAccessLayer.SearchShippingContainsByOrderIDOfSpecificCustomer(Contains, CustomerID, ShippingStatus);
        }

        public static DataView SearchShippingContainsByTrackingNumberOfSpecificCustomer(string Contains, int CustomerID, string ShippingStatus)
        {
            return clsShippingDataAccessLayer.SearchShippingContainsByTrackingNumberOfSpecificCustomer(Contains, CustomerID, ShippingStatus);
        }

        public static DataView SearchShippingContainsByShippingStatusOfSpecificCustomer(string Contains, int CustomerID)
        {
            return clsShippingDataAccessLayer.SearchShippingContainsByShippingStatusOfSpecificCustomer(Contains, CustomerID);
        }

        public static DataView SearchShippingContainsByShippingStatus(string Contains)
        {
            return clsShippingDataAccessLayer.SearchShippingContainsByShippingStatus(Contains);
        }

    }
}
