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
    public class clsAdministrator : clsPerson
    {

        public enum enAdministratorMode { AddNew = 0, Update = 1 }
        public enAdministratorMode _AdministratorMode = enAdministratorMode.AddNew;

        private static clsPerson _Person;

        public int AdministratorID { get; set; }

        public clsAdministrator() : base()
        {
            this.AdministratorID = -1;

            this._AdministratorMode = enAdministratorMode.AddNew;

            base._PersonMode = clsPerson.enPersonMode.AddNew;
        }

        protected clsAdministrator(int AdministratorID, int PersonID, string Name,
            string Email, string Address, string Username, string Password)
            : base(PersonID, Name, Email, Address, Username, Password)
        {
            this.AdministratorID = AdministratorID;

            _AdministratorMode = enAdministratorMode.Update;

            base._PersonMode = clsPerson.enPersonMode.Update;
        }

        private static int _GetAdministratorIDByPersonID(int PersonID)
        {
            return clsAdministratorDataAccessLayer.GetAdministratorIDByPersonID(PersonID);
        }
        private static int _GetPersonIDByAdministratorID(int AdministratorID)

        {
            return clsAdministratorDataAccessLayer.GetPersonIDByAdministratorID(AdministratorID);
        }

        private bool _AddNewAdministrator()
        {
            if (base.Save())
            {
                this.AdministratorID = clsAdministratorDataAccessLayer.AddNewAdministrator(base.PersonID);
            }

            return (this.AdministratorID != -1);
        }
        private bool _UpdateAdministrator()
        {
            return base.Save();
        }

        public static clsAdministrator FindAdministratorByAdministratorID(int AdministratorID)
        {
            int PersonID = -1;

            if (clsAdministratorDataAccessLayer.GetAdministratorInfoByAdministratorID(AdministratorID, ref PersonID))
            {
                _Person = clsPerson.FindPersonByPersonID(PersonID);

                return new clsAdministrator(AdministratorID, PersonID,
                    _Person.Name, _Person.Email, _Person.Address,
                    _Person.Username, _Person.Password);
            }
            else
            {
                return null;
            }
        }
        public static clsAdministrator FindAdministratorByEmail(string Email)
        {
            _Person = clsPerson.FindByEmail(Email);
            int AdministratorID = -1;

            if (_Person != null)
            {
                AdministratorID = _GetAdministratorIDByPersonID(_Person.PersonID);
            }

            if (AdministratorID != -1)
            {
                return new clsAdministrator(AdministratorID, _Person.PersonID,
                    _Person.Name, _Person.Email, _Person.Address,
                    _Person.Username, _Person.Password);
            }
            else
            {
                return null;
            }

        }
        public static clsAdministrator FindAdministratorByUsername(string UserName)
        {
            _Person = clsPerson.FindByUsername(UserName);
            int AdministratorID = -1;

            if (_Person != null)
            {
                AdministratorID = _GetAdministratorIDByPersonID(_Person.PersonID);
            }

            if (AdministratorID != -1)
            {
                return new clsAdministrator(AdministratorID, _Person.PersonID,
                    _Person.Name, _Person.Email, _Person.Address,
                    _Person.Username, _Person.Password);
            }
            else
            {
                return null;
            }

        }
        public static clsAdministrator FindAdministratorByEmailAndPassword(string Email, string Password)
        {
            _Person = clsPerson.FindByEmailAndPassword(Email, Password);
            int AdministratorID = -1;

            if (_Person != null)
            {
                AdministratorID = _GetAdministratorIDByPersonID(_Person.PersonID);
            }

            if (AdministratorID != -1)
            {
                return new clsAdministrator(AdministratorID, _Person.PersonID,
                    _Person.Name, _Person.Email, _Person.Address,
                    _Person.Username, _Person.Password);
            }
            else
            {
                return null;
            }

        }
        public static clsAdministrator FindAdministratorByUsernameAndPassword(string Username, string Password)
        {
            _Person = clsPerson.FindByUsernameAndPassword(Username, Password);
            int AdministratorID = -1;

            if (_Person != null)
            {
                AdministratorID = _GetAdministratorIDByPersonID(_Person.PersonID);
            }

            if (AdministratorID != -1)
            {
                return new clsAdministrator(AdministratorID, _Person.PersonID,
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
            switch (_AdministratorMode)
            {
                case enAdministratorMode.AddNew:
                    return _AddNewAdministrator();

                case enAdministratorMode.Update:
                    return _UpdateAdministrator();
            }

            return false;
        }

        public static bool DeleteAdministrator(int AdministratorID)
        {
            int PersonID = _GetPersonIDByAdministratorID(AdministratorID);

            if (clsAdministratorDataAccessLayer.DeleteAdministrator(AdministratorID))
            {
                return DeletePerson(PersonID);
            }

            return false;
        }


        public static bool IsAdministratorExistsByID(int AdministratorID)
        {
            return clsAdministratorDataAccessLayer.IsAdministratorExistsByID(AdministratorID);
        }
        public static bool IsAdministratorExistsByEmail(string Email)
        {
            return IsPersonExistsByEmail(Email, "Administrators");
        }
        public static bool IsAdministratorExistsByUsername(string Username)
        {
            return IsPersonExistsByUsername(Username, "Administrators");
        }
        public static bool IsAdministratorExistsByEmailAndPassword(string Email, string Password)
        {
            return IsPersonExistsByEmailAndPassword(Email, Password, "Administrators");
        }
        public static bool IsAdministratorExistsByUsernameAndPassword(string Username, string Password)
        {
            return IsPersonExistsByUsernameAndPassword(Username, Password, "Administrators");
        }

        public static DataView GetAllAdministrators()
        {
            return clsAdministratorDataAccessLayer.GetAllAdministrators();
        }

        public static DataView SearchAdministratorsContainsByAdministratorID(string Contains)
        {
            return clsAdministratorDataAccessLayer.SearchAdministratorsContainsByAdministratorID(Contains);
        }
        public static DataView SearchAdministratorsContainsByName(string Contains)
        {
            return clsAdministratorDataAccessLayer.SearchAdministratorsContainsByName(Contains);
        }
        public static DataView SearchAdministratorsContainsByUsername(string Contains)
        {
            return clsAdministratorDataAccessLayer.SearchAdministratorsContainsByUsername(Contains);
        }
    }
}
