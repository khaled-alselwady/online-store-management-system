using OnlineStore_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_BusinessLayer_
{
    public class clsProduct
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int CategoryID { get; set; }


        public clsProduct()
        {
            this.ProductID = -1;
            this.ProductName = string.Empty;
            this.Description = string.Empty;
            this.Price = 0;
            this.QuantityInStock = 0;
            this.CategoryID = -1;

            _Mode = enMode.AddNew;
        }

        private clsProduct(int productID, string productName, string description,
            decimal price, int quantityInStock, int categoryID)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Description = description;
            this.Price = price;
            this.QuantityInStock = quantityInStock;
            this.CategoryID = categoryID;

            this._Mode = enMode.Update;
        }

        private bool _AddNewProduct()
        {
            this.ProductID = clsProductDataAccessLayer.AddNewProduct(this.ProductName,
                this.Description, this.Price, this.QuantityInStock, this.CategoryID);

            return (this.ProductID != -1);
        }
        private bool _UpdateProduct()
        {
            return clsProductDataAccessLayer.UpdateProduct(this.ProductID, this.ProductName,
                this.Description, this.Price, this.QuantityInStock, this.CategoryID);
        }

        public static clsProduct FindProduct(int ProductID)
        {
            string ProductName = string.Empty, Description = string.Empty;
            int QuantityInStock = 0, CategoryID = 0;
            decimal Price = 0;

            if (clsProductDataAccessLayer.GetProductInfoByID(ProductID, ref ProductName,
                ref Description, ref Price, ref QuantityInStock, ref CategoryID))
            {
                return new clsProduct(ProductID, ProductName, Description,
                    Price, QuantityInStock, CategoryID);
            }
            else
            {
                return null;
            }
        }
        public static clsProduct FindProduct(string ProductName)
        {
            string Description = string.Empty;
            int ProductID = 0, QuantityInStock = 0, CategoryID = 0;
            decimal Price = 0;

            if (clsProductDataAccessLayer.GetProductInfoByName(ProductName, ref ProductID,
                ref Description, ref Price, ref QuantityInStock, ref CategoryID))
            {
                return new clsProduct(ProductID, ProductName, Description,
                    Price, QuantityInStock, CategoryID);
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
                    return _AddNewProduct();

                case enMode.Update:
                    return _UpdateProduct();

            }

            return false;
        }

        public static bool DeleteProduct(int ProductID)
        {
            return clsProductDataAccessLayer.DeleteProduct(ProductID);
        }

        public static bool IsProductExists(int ProductID)
        {
            return clsProductDataAccessLayer.IsProductExists(ProductID);
        }
        public static bool IsProductExists(string ProductName)
        {
            return clsProductDataAccessLayer.IsProductExists(ProductName);
        }

        public static DataView GetAllProducts()
        {
            return clsProductDataAccessLayer.GetAllProducts();
        }

        public static DataView GetAllProductsWithoutQuantity()
        {
            return clsProductDataAccessLayer.GetAllProductsWithoutQuantity();
        }

        public static DataView GetAllProductsWithSpecificCategory(string CategoryName)
        {
            return clsProductDataAccessLayer.GetAllProductsWithSpecificCategory(CategoryName);
        }

        public static DataView GetAllProductsWithSpecificCategoryWithoutQuantity(string CategoryName)
        {
            return clsProductDataAccessLayer.GetAllProductsWithSpecificCategoryWithoutQuantity(CategoryName);
        }

        public static DataView SearchProductsContainsByProductID(string Contains, string CategoryName)
        {
            return clsProductDataAccessLayer.SearchProductsContainsByProductID(Contains, CategoryName);
        }

        public static DataView SearchProductsContainsByProductName(string Contains, string CategoryName)
        {
            return clsProductDataAccessLayer.SearchProductsContainsByProductName(Contains, CategoryName);
        }

        public static DataView SearchProductsContainsByProductCategory(string Contains, string CategoryName)
        {
            return clsProductDataAccessLayer.SearchProductsContainsByProductCategory(Contains, CategoryName);
        }

        public static DataView SearchProductsContainsByProductIDWithoutQuantity(string Contains, string CategoryName)
        {
            return clsProductDataAccessLayer.SearchProductsContainsByProductIDWithoutQuantity(Contains, CategoryName);
        }

        public static DataView SearchProductsContainsByProductNameWithoutQuantity(string Contains, string CategoryName)
        {
            return clsProductDataAccessLayer.SearchProductsContainsByProductNameWithoutQuantity(Contains, CategoryName);
        }

        public static DataView SearchProductsContainsByProductCategoryWithoutQuantity(string Contains, string CategoryName)
        {
            return clsProductDataAccessLayer.SearchProductsContainsByProductCategoryWithoutQuantity(Contains, CategoryName);
        }

    }
}
