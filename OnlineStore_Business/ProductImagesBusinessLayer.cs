using OnlineStore_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_BusinessLayer_
{
    public class clsProductImages
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public int ImageID { get; set; }
        public string ImageURL { get; set; }
        public short ImageOrder { get; set; }
        public int ProductID { get; set; }

        public clsProductImages()
        {
            this.ImageID = -1;
            this.ImageURL = string.Empty;
            this.ImageOrder = 0;
            this.ProductID = -1;

            this._Mode = enMode.AddNew;
        }

        private clsProductImages(int imageID, string imageURL, short imageOrder, int productID)
        {
            this.ImageID = imageID;
            this.ImageURL = imageURL;
            this.ImageOrder = imageOrder;
            this.ProductID = productID;

            this._Mode = enMode.Update;
        }

        private bool _AddNewImage()
        {
            this.ImageID = clsProductImagesDataAccessLayer.AddNewProductImage(this.ImageURL,
                this.ImageOrder, this.ProductID);

            return (this.ImageID != -1);
        }
        private bool _UpdateImage()
        {
            return clsProductImagesDataAccessLayer.UpdateNewProductImage(this.ImageID,
                this.ImageURL, this.ImageOrder, this.ProductID);
        }

        public static clsProductImages FindImage(int ImageID)
        {
            string ImageURL = string.Empty;
            short ImageOrder = 0;
            int ProductID = -1;

            if (clsProductImagesDataAccessLayer.GetProductImagesInfoByImageID(ImageID,
                ref ImageURL, ref ImageOrder, ref ProductID))
            {
                return new clsProductImages(ImageID, ImageURL, ImageOrder, ProductID);
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
                    return _AddNewImage();

                case enMode.Update:
                    return _UpdateImage();

            }

            return false;
        }


        public static bool DeleteImage(int ImageID)
        {
            return clsProductImagesDataAccessLayer.DeleteProductImage(ImageID);
        }

        public static bool IsImageExists(int ImageID)
        {
            return clsProductImagesDataAccessLayer.IsImageExists(ImageID);
        }

        public static DataView GetAllImagesOfSpecificProduct(int ProductID)
        {
            return clsProductImagesDataAccessLayer.GetAllImagesOfSpecificProduct(ProductID);
        }
        public static DataView GetAllImages()
        {
            return clsProductImagesDataAccessLayer.GetAllImages();
        }
    }
}
