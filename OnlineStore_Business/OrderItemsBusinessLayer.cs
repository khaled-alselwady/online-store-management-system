using OnlineStore_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_BusinessLayer_
{
    public class clsOrderItem
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal TotalItemsPrice { get; set; }

        public clsOrderItem()
        {
            this.OrderItemID = -1;
            this.OrderID = -1;
            this.ProductID = -1;
            this.Quantity = 0;
            this.PricePerItem = 0;
            this.TotalItemsPrice = 0;


            this._Mode = enMode.AddNew;
        }

        private clsOrderItem(int OrderItemID, int OrderID, int ProductID, int Quantity, decimal PricePerItem, decimal TotalItemsPrice)
        {
            this.OrderItemID = OrderItemID;
            this.OrderID = OrderID;
            this.ProductID = ProductID;
            this.Quantity = Quantity;
            this.PricePerItem = PricePerItem;
            this.TotalItemsPrice = TotalItemsPrice;

            this._Mode = enMode.Update;
        }

        private bool _AddNewOrderItem()
        {
            this.OrderItemID = clsOrderItemsDataAccessLayer.AddNewOrderItem(this.OrderID,
                this.ProductID, this.Quantity, this.PricePerItem, this.TotalItemsPrice);

            return (this.OrderItemID != -1);
        }
        private bool _UpdateOrderItem()
        {
            return clsOrderItemsDataAccessLayer.UpdateOrderItem(this.OrderItemID, this.OrderID,
                this.ProductID, this.Quantity, this.PricePerItem, this.TotalItemsPrice);
        }

        public static clsOrderItem FindOrderItem(int OrderItemID)
        {
            int OrderID = -1, ProductID = -1, Quantity = 0;
            decimal PricePerItem = 0, TotalItemsPrice = 0;

            if (clsOrderItemsDataAccessLayer.GetOrderItemsInfoByOrderItemID(OrderItemID,
                ref OrderID, ref ProductID, ref Quantity, ref PricePerItem, ref TotalItemsPrice))
            {
                return new clsOrderItem(OrderItemID, OrderID, ProductID,
                    Quantity, PricePerItem, TotalItemsPrice);
            }
            else
            {
                return null;
            }

        }

        public static clsOrderItem FindOrderItem(int OrderID, int ProductID)
        {
            int OrderItemID = -1, Quantity = 0;
            decimal PricePerItem = 0, TotalItemsPrice = 0;

            if (clsOrderItemsDataAccessLayer.GetOrderItemsInfoByOrderIDAndProductID(OrderID, ProductID,
                ref OrderItemID, ref Quantity, ref PricePerItem, ref TotalItemsPrice))
            {
                return new clsOrderItem(OrderItemID, OrderID, ProductID,
                    Quantity, PricePerItem, TotalItemsPrice);
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
                    return _AddNewOrderItem();

                case enMode.Update:
                    return _UpdateOrderItem();

            }

            return false;
        }

        public static bool DeleteOrderItem(int OrderItemID)
        {
            return clsOrderItemsDataAccessLayer.DeleteOrderItem(OrderItemID);
        }

        public static bool IsOrderItemExistsByOrderItemID(int OrderItemID)
        {
            return clsOrderItemsDataAccessLayer.IsOrderItemExistsByOrderItemID(OrderItemID);
        }

        public static bool IsOrderItemExistsByOrderID(int OrderID)
        {
            return clsOrderItemsDataAccessLayer.IsOrderItemExistsByOrderID(OrderID);
        }

        public static DataView GetAllOrderItemsInfoByOrderID(int OrderID)
        {
            return clsOrderItemsDataAccessLayer.GetAllOrderItemsInfoByOrderID(OrderID);
        }

        public static DataView GetAllOrderItems()
        {
            return clsOrderItemsDataAccessLayer.GetAllOrderItems();
        }
    }


}
