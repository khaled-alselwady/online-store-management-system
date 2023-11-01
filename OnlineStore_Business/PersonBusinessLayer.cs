using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OnlineStore_DataAccessLayer_;

namespace OnlineStore_BusinessLayer_
{
    public class clsPerson
    {

        public enum enPersonMode { AddNew = 0, Update = 1 }
        public enPersonMode _PersonMode = enPersonMode.AddNew;

        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public clsPerson()
        {
            this.PersonID = -1;
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.Address = string.Empty;
            this.Username = string.Empty;
            this.Password = string.Empty;

            this._PersonMode = enPersonMode.AddNew;
        }
        protected clsPerson(int personID, string name, string email,
            string address, string username, string password)
        {
            this.PersonID = personID;
            this.Name = name;
            this.Email = email;
            this.Address = address;
            this.Username = username;
            this.Password = password;

            this._PersonMode = enPersonMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonDataAccessLayer.AddNewPerson(this.Name,
                this.Email, this.Address, this.Username, this.Password);

            return (this.PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            return clsPersonDataAccessLayer.UpdatePerson(this.PersonID, this.Name,
                this.Email, this.Address, this.Username, this.Password);
        }

        public static clsPerson FindPersonByPersonID(int PersonID)
        {
            string Name = "", Email = "", Address = "", Username = "", Password = "";

            if (clsPersonDataAccessLayer.GetPersonInfoByID(PersonID, ref Name,
                 ref Email, ref Address, ref Username, ref Password))
            {
                return new clsPerson(PersonID, Name, Email,
                    Address, Username, Password);
            }

            else
            {
                return null;
            }
        }
        public static clsPerson FindByEmail(string Email)
        {
            int PersonID = -1;
            string Name = "", Address = "", Username = "", Password = "";

            if (clsPersonDataAccessLayer.GetPersonInfoByEmail(Email, ref PersonID,
                 ref Name, ref Address, ref Username, ref Password))

            {
                return new clsPerson(PersonID, Name, Email,
                    Address, Username, Password);
            }

            else
            {
                return null;
            }
        }
        public static clsPerson FindByUsername(string Username)
        {
            int PersonID = -1;
            string Name = "", Email = "", Address = "", Password = "";

            if (clsPersonDataAccessLayer.GetPersonInfoByUsername(Username,
                ref PersonID, ref Name, ref Email, ref Address, ref Password))

            {
                return new clsPerson(PersonID, Name, Email,
                    Address, Username, Password);
            }

            else
            {
                return null;
            }
        }
        public static clsPerson FindByEmailAndPassword(string Email, string Password)
        {
            int PersonID = -1;
            string Name = "", Address = "", Username = "";

            if (clsPersonDataAccessLayer.GetPersonInfoByEmailAndPassword(Email,
                Password, ref PersonID, ref Name, ref Username, ref Address))

            {
                return new clsPerson(PersonID, Name, Email, Address, Username, Password);
            }

            else
            {
                return null;
            }
        }
        public static clsPerson FindByUsernameAndPassword(string Username, string Password)
        {
            int PersonID = -1;
            string Name = "", Email = "", Address = "";

            if (clsPersonDataAccessLayer.GetPersonInfoByUsernameAndPassword(Username, Password,
                ref PersonID, ref Name, ref Email, ref Address))

            {
                return new clsPerson(PersonID, Name, Email, Address, Username, Password);
            }

            else
            {
                return null;
            }
        }

        public virtual bool Save()
        {
            switch (_PersonMode)
            {

                case enPersonMode.AddNew:
                    return _AddNewPerson();


                case enPersonMode.Update:
                    return _UpdatePerson();

            }

            return false;
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonDataAccessLayer.DeletePerson(PersonID);
        }

        public static bool IsPersonExistsByID(int PersonID)
        {
            return clsPersonDataAccessLayer.IsPersonExistsByID(PersonID);
        }
        public static bool IsPersonExistsByEmail(string Email, string NameOfTable)
        {
            return clsPersonDataAccessLayer.IsPersonExistsByEmail(Email, NameOfTable);
        }
        public static bool IsPersonExistsByUsername(string Username, string NameOfTable)
        {
            return clsPersonDataAccessLayer.IsPersonExistsByUsername(Username, NameOfTable);
        }
        public static bool IsPersonExistsByEmailAndPassword(string Email, string Password, string NameOfTable)
        {
            return clsPersonDataAccessLayer.IsPersonExistsByEmailAndPassword(Email, Password, NameOfTable);
        }
        public static bool IsPersonExistsByUsernameAndPassword(string Username, string Password, string NameOfTable)
        {
            return clsPersonDataAccessLayer.IsPersonExistsByUsernameAndPassword(Username, Password, NameOfTable);
        }

        public static DataTable GetAllPersons()
        {
            return clsPersonDataAccessLayer.GetAllPersons();
        }
    }
}
