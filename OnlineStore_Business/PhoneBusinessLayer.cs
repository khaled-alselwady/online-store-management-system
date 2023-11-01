using OnlineStore_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_BusinessLayer_
{
    public class clsPhone
    {
        enum enMode { AddNew, Update }
        enMode _Mode = enMode.AddNew;

        public int PhoneID { get; set; }
        public string Phone { get; set; }
        public int PersonID { get; set; }

        public clsPhone()
        {
            this.PhoneID = -1;
            this.Phone = string.Empty;
            this.PersonID = -1;

            this._Mode = enMode.AddNew;
        }

        private clsPhone(int phoneID, string phone, int personID)
        {
            this.PhoneID = phoneID;
            this.Phone = phone;
            this.PersonID = personID;

            this._Mode = enMode.Update;
        }

        private bool _AddNewPhoneNumber()
        {
            this.PhoneID = clsPhoneDataAccessLayer.AddNewPhoneNumber(this.Phone, this.PersonID);

            return (this.PhoneID != -1);
        }

        private bool _UpdatePhoneNumber()
        {
            return clsPhoneDataAccessLayer.UpdatePhoneNumber(this.PhoneID, this.Phone, this.PersonID);
        }

        public bool Save()
        {
            switch (this._Mode)
            {

                case enMode.AddNew:
                    return _AddNewPhoneNumber();

                case enMode.Update:
                    return _UpdatePhoneNumber();

            }

            return false;
        }

        public static clsPhone FindPhone(string Phone)
        {
            int PhoneID = -1, PersonID = -1;

            if (clsPhoneDataAccessLayer.GetPhoneInfoByNumberPhone(Phone, ref PhoneID, ref PersonID))
            {
                return new clsPhone(PhoneID, Phone, PersonID);
            }
            else
            {
                return null;
            }

        }

        public static bool DeletePhoneNumber(int phoneID)
        {
            return clsPhoneDataAccessLayer.DeletePhoneNumber(phoneID);
        }

        public static DataView GetAllPhonesOfSpecificPerson(int PersonID)
        {
            return clsPhoneDataAccessLayer.GetAllPhonesOfSpecificPerson(PersonID);
        }

        public static bool IsPhoneExists(string Phone)
        {
            return clsPhoneDataAccessLayer.IsPhoneExists(Phone);
        }

    }
}
