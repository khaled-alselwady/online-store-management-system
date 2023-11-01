using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OnlineStore_BusinessLayer_;
using OnlineStore_DataAccessLayer_;

namespace OnlineStore_BusinessLayer_
{
    public class clsCustomer : clsPerson
    {
        public enum enCustomerMode { AddNew = 0, Update = 1 }
        public enCustomerMode _CustomerMode = enCustomerMode.AddNew;

        private static clsPerson _Person;

        public int CustomerID { get; set; }

        public clsCustomer() : base()
        {
            this.CustomerID = -1;
            this._CustomerMode = enCustomerMode.AddNew;
            base._PersonMode = clsPerson.enPersonMode.AddNew;
        }

        protected clsCustomer(int customerID, int PersonID, string Name,
            string Email, string Address, string Username, string Password)
            : base(PersonID, Name, Email, Address, Username, Password)
        {
            this.CustomerID = customerID;
            this._CustomerMode = enCustomerMode.Update;
            base._PersonMode = clsPerson.enPersonMode.Update;
        }


        private bool _AddNewCustomer()
        {
            if (base.Save())
            {
                this.CustomerID = clsCustomerDataAccessLayer.AddNewCustomer(base.PersonID);
            }

            return (this.CustomerID != -1);
        }

        private bool _UpdateCustomer()
        {
            return base.Save();
        }

        private static int _GetCustomerIDByPersonID(int personID)
        {
            return clsCustomerDataAccessLayer.GetCustomerIDByPersonID(personID);
        }

        public static int GetPersonIDByCustomerID(int CustomerID)
        {
            return clsCustomerDataAccessLayer.GetPersonIDByCustomerID(CustomerID);
        }

        public static clsCustomer FindCustomerByCustomerID(int customerID)
        {
            int PersonID = -1;

            if (clsCustomerDataAccessLayer.FindCustomerByCustomerID(customerID, ref PersonID))
            {
                _Person = clsPerson.FindPersonByPersonID(PersonID);

                return new clsCustomer(customerID, _Person.PersonID,
                    _Person.Name, _Person.Email, _Person.Address,
                    _Person.Username, _Person.Password);
            }
            else
            {
                return null;
            }
        }
        public static clsCustomer FindCustomerByEmail(string email)
        {
            _Person = clsPerson.FindByEmail(email);
            int CustomerID = -1;

            if (_Person != null)
            {
                CustomerID = _GetCustomerIDByPersonID(_Person.PersonID);
            }


            if (CustomerID != -1)
            {
                return new clsCustomer(CustomerID, _Person.PersonID,
                    _Person.Name, _Person.Email, _Person.Address,
                    _Person.Username, _Person.Password);
            }
            else
            {
                return null;
            }

        }
        public static clsCustomer FindCustomerByUsername(string Username)
        {
            _Person = clsPerson.FindByUsername(Username);
            int CustomerID = -1;

            if (_Person != null)
            {
                CustomerID = _GetCustomerIDByPersonID(_Person.PersonID);
            }


            if (CustomerID != -1)
            {
                return new clsCustomer(CustomerID, _Person.PersonID,
                    _Person.Name, _Person.Email, _Person.Address,
                    _Person.Username, _Person.Password);
            }
            else
            {
                return null;
            }

        }
        public static clsCustomer FindCustomerByEmailAndPassword(string Email, string Password)
        {
            _Person = clsPerson.FindByEmailAndPassword(Email, Password);
            int CustomerID = -1;

            if (_Person != null)
            {
                CustomerID = _GetCustomerIDByPersonID(_Person.PersonID);
            }


            if (CustomerID != -1)
            {
                return new clsCustomer(CustomerID, _Person.PersonID,
                    _Person.Name, _Person.Email, _Person.Address,
                    _Person.Username, _Person.Password);
            }
            else
            {
                return null;
            }

        }
        public static clsCustomer FindCustomerByUsernameAndPassword(string Username, string Password)
        {
            _Person = clsPerson.FindByUsernameAndPassword(Username, Password);
            int CustomerID = -1;

            if (_Person != null)
            {
                CustomerID = _GetCustomerIDByPersonID(_Person.PersonID);
            }


            if (CustomerID != -1)
            {
                return new clsCustomer(CustomerID, _Person.PersonID,
                    _Person.Name, _Person.Email, _Person.Address,
                    _Person.Username, _Person.Password);
            }
            else
            {
                return null;
            }

        }

        public override bool Save()
        {
            switch (_CustomerMode)
            {

                case enCustomerMode.AddNew:
                    return _AddNewCustomer();

                case enCustomerMode.Update:
                    return _UpdateCustomer();
            }

            return false;
        }


        public static bool DeleteCustomer(int CustomerID)
        {
            int PersonID = GetPersonIDByCustomerID(CustomerID);

            if (clsCustomerDataAccessLayer.DeleteCustomer(CustomerID))
            {
                return DeletePerson(PersonID);
            }

            return false;
        }

        public static bool IsCustomerExistsByID(int CustomerID)
        {
            return clsCustomerDataAccessLayer.IsCustomerExistsByID(CustomerID);
        }
        public static bool IsCustomerExistsByEmail(string Email)
        {
            return IsPersonExistsByEmail(Email, "Customers");
        }
        public static bool IsCustomerExistsByUsername(string Username)
        {
            return IsPersonExistsByUsername(Username, "Customers");
        }
        public static bool IsCustomerExistsByEmailAndPassword(string Email, string Password)
        {
            return IsPersonExistsByEmailAndPassword(Email, Password, "Customers");
        }
        public static bool IsCustomerExistsByUsernameAndPassword(string Username, string Password)
        {
            return IsPersonExistsByUsernameAndPassword(Username, Password, "Customers");
        }

        public static DataView GetAllCustomers()
        {
            return clsCustomerDataAccessLayer.GetAllCustomers().DefaultView;
        }

        public static DataView SearchCustomersContainsByCustomerID(string Contains)
        {
            return clsCustomerDataAccessLayer.SearchCustomersContainsByCustomerID(Contains);
        }
        public static DataView SearchCustomersContainsByName(string Contains)
        {
            return clsCustomerDataAccessLayer.SearchCustomersContainsByName(Contains);
        }
        public static DataView SearchCustomersContainsByUsername(string Contains)
        {
            return clsCustomerDataAccessLayer.SearchCustomersContainsByUsername(Contains);
        }

    }
}
