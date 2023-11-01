using OnlineStore_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_BusinessLayer_
{
    public class clsCategory
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public clsCategory()
        {
            this.CategoryID = -1;
            this.CategoryName = string.Empty;

            this._Mode = enMode.AddNew;
        }

        private clsCategory(int categoryID, string categoryName)
        {
            this.CategoryID = categoryID;
            this.CategoryName = categoryName;

            _Mode = enMode.Update;
        }

        private bool _AddNewCategory()
        {
            this.CategoryID = clsCategoryDataAccessLayer.AddNewCategory(this.CategoryName);

            return (this.CategoryID != -1);
        }
        private bool _UpdateCategory()
        {
            return clsCategoryDataAccessLayer.UpdateCategory(this.CategoryID, this.CategoryName);
        }

        public static clsCategory FindCategory(int categoryID)
        {
            string categoryName = string.Empty;

            if (clsCategoryDataAccessLayer.GetProductCategoryInfoByID(categoryID, ref categoryName))
            {
                return new clsCategory(categoryID, categoryName);
            }
            else
            {
                return null;
            }
        }
        public static clsCategory FindCategory(string categoryName)
        {
            int categoryID = -1;

            if (clsCategoryDataAccessLayer.GetProductCategoryInfoByName(categoryName, ref categoryID))
            {
                return new clsCategory(categoryID, categoryName);
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
                    return _AddNewCategory();

                case enMode.Update:
                    return _UpdateCategory();

            }

            return false;
        }

        public static bool DeleteCategory(int categoryID)
        {
            return clsCategoryDataAccessLayer.DeleteCategory(categoryID);
        }

        public static bool IsCategoryExists(int categoryID)
        {
            return clsCategoryDataAccessLayer.IsCategoryExists(categoryID);
        }
        public static bool IsCategoryExists(string categoryName)
        {
            return clsCategoryDataAccessLayer.IsCategoryExists(categoryName);
        }

        public static DataView GetAllCategories()
        {
            return clsCategoryDataAccessLayer.GetAllCategories();
        }

        public static DataView SearchCategoriesContainsByCategoryID(string Contains)
        {
            return clsCategoryDataAccessLayer.SearchCategoriesContainsByCategoryID(Contains);
        }

        public static DataView SearchCategoriesContainsByCategoryName(string Contains)
        {
            return clsCategoryDataAccessLayer.SearchCategoriesContainsByCategoryName(Contains);
        }
    }
}
