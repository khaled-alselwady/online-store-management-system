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
    public class clsReview
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public int ReviewID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public string ReviewText { get; set; }
        public decimal Rating { get; set; }
        public DateTime ReviewDate { get; set; }

        public clsReview()
        {
            this.ReviewID = -1;
            this.ProductID = -1;
            this.CustomerID = -1;
            this.ReviewText = string.Empty;
            this.Rating = 0;
            this.ReviewDate = new DateTime();

            this._Mode = enMode.AddNew;
        }

        private clsReview(int ReviewID, int ProductID, int CustomerID,
            string ReviewText, decimal Rating, DateTime ReviewDate)
        {
            this.ReviewID = ReviewID;
            this.ProductID = ProductID;
            this.CustomerID = CustomerID;
            this.ReviewText = ReviewText;
            this.Rating = Rating;
            this.ReviewDate = ReviewDate;

            this._Mode = enMode.Update;
        }

        private bool _AddNewReview()
        {
            this.ReviewID = clsReviewDataAccessLayer.AddNewReview(this.ProductID,
                  this.CustomerID, this.ReviewText, this.Rating, this.ReviewDate);

            return (this.ReviewID != -1);

        }
        private bool _UpdateReview()
        {
            return clsReviewDataAccessLayer.UpdateReview(this.ReviewID, this.ProductID,
                         this.CustomerID, this.ReviewText, this.Rating, this.ReviewDate);
        }

        public static clsReview FindReview(int ReviewID)
        {
            int ProductID = -1, CustomerID = -1;
            string ReviewText = string.Empty;
            decimal Rating = 0;
            DateTime ReviewDate = new DateTime();

            if (clsReviewDataAccessLayer.GetReviewInfoByReviewID(ReviewID, ref ProductID,
                ref CustomerID, ref ReviewText, ref Rating, ref ReviewDate))
            {
                return new clsReview(ReviewID, ProductID, CustomerID,
                    ReviewText, Rating, ReviewDate);
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
                    return _AddNewReview();

                case enMode.Update:
                    return _UpdateReview();


            }

            return false;

        }

        public static bool DeleteReview(int ReviewID)
        {
            return clsReviewDataAccessLayer.DeleteReview(ReviewID);
        }

        public static bool IsReviewExists(int ReviewID)
        {
            return clsReviewDataAccessLayer.IsReviewExists(ReviewID);
        }

        public static DataView GetAllReviewsOfSpecificCustomer(int CustomerID)
        {
            return clsReviewDataAccessLayer.GetAllReviewsOfSpecificCustomer(CustomerID);
        }

        public static DataView GetAllReviewsOfSpecificProduct(int ProductID)
        {
            return clsReviewDataAccessLayer.GetAllReviewsOfSpecificProduct(ProductID);
        }

        public static DataView GetAllReviews()
        {
            return clsReviewDataAccessLayer.GetAllReviews();
        }

        public static DataView SearchReviewsContainsByReviewID(string Contains)
        {
            return clsReviewDataAccessLayer.SearchReviewsContainsByReviewID(Contains);
        }

        public static DataView SearchReviewsContainsByProductID(string Contains)
        {
            return clsReviewDataAccessLayer.SearchReviewsContainsByProductID(Contains);
        }

        public static DataView SearchReviewsContainsByRating(string Contains)
        {
            return clsReviewDataAccessLayer.SearchReviewsContainsByRating(Contains);
        }

        public static DataView SearchReviewsContainsByReviewIDWithoutCustomerIDColumn(string Contains, int CustomerID)
        {
            return clsReviewDataAccessLayer.SearchReviewsContainsByReviewIDWithoutCustomerIDColumn(Contains, CustomerID);
        }

        public static DataView SearchReviewsContainsByProductNameWithoutCustomerIDColumn(string Contains, int CustomerID)
        {
            return clsReviewDataAccessLayer.SearchReviewsContainsByProductNameWithoutCustomerIDColumn(Contains, CustomerID);
        }

        public static DataView SearchReviewsContainsByReviewDateWithoutCustomerIDColumn(string Contains, int CustomerID)
        {
            return clsReviewDataAccessLayer.SearchReviewsContainsByReviewDateWithoutCustomerIDColumn(Contains, CustomerID);
        }

    }
}
