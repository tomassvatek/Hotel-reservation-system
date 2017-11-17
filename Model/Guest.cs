using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
    public class Guest : IDataErrorInfo
    {
        #region Constructors
        public Guest(int id, string fistName, string lastName, string phoneNumber, string email)
        {
            _id = id;
            _firstName = fistName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _email = email;
            Accommodations = new List<Accommodation>();
        }

        public Guest(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            Accommodations = new List<Accommodation>();
        }
        #endregion

        public Guest()
        {
            Accommodations = new List<Accommodation>();
        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public ICollection<Accommodation> Accommodations { get; set; }

        public override string ToString()
        {
            return $"{_id} {_firstName} {_lastName}";
        }

        #region IDataErrorInfo
        public string Error
        {
            get
            {
                return null;
            }
        }

        static readonly string[] ValidatedProperties =
        {
            "FirstName", "LastName", "PhoneNumber", "Email"
        };

        public bool IsValid
        {
            get
            {
                foreach (var property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        string GetValidationError(string propertyName)
        {
            string error = null;

            switch (propertyName)
            {
                case "FirstName":
                    error = ValidateFirstName();
                    break;
                case "LastName":
                    error = ValidateLastName();
                    break;
                case "PhoneNumber":
                    error = ValidatePhoneNumber();
                    break;
                case "Email":
                    error = ValidateEmail();
                    break;
            }
            return error;
        }

        private string ValidateFirstName()
        {
            if (String.IsNullOrWhiteSpace(FirstName))
            {
                return "Jméno musí být vyplněno.";
            }
            else if (FirstName.Length < 3)
            {
                return "Jméno musí obsahovat alespon tři znaky.";
            }
            else if(FirstName.Length > 15)
            {
                return "Jméno může obsahovat maximálně patnáct znaků";
            }
            return null;
        }

        private string ValidateLastName()
        {
            if (String.IsNullOrWhiteSpace(LastName))
            {
                return "Přijmení musí být vyplněno.";
            }
            else if(LastName.Length < 3)
            {
                return "Přijmení musí obsahovat alespon tři znaky.";
            }
            else if (LastName.Length > 18)
            {
                return "Příjmení může obsahovat maximálně osmnáct znaků";
            }
            return null;
        }

        private string ValidateEmail()
        {
            if (String.IsNullOrWhiteSpace(Email))
            {
                return "Email musí být vyplněn.";
            }
            else if(Email.Length < 4)
            {
                return "Email musí mít alespon čtyři znaky";
            }
            else if (!Email.Contains("@"))
            {
                return "Email musí obsahovat @";
            }
            else if (Email.Length >= 35)
            {
                return "Email může obsahovat maximálně třicet pět znaků";
            }
            return null;
        }

        private string ValidatePhoneNumber()
        {
            int phone;
            if (String.IsNullOrWhiteSpace(PhoneNumber))
            {
                return "Telefonní číslo musí být vyplněno.";
            }
            else if (PhoneNumber.Length < 9)
            {
                return "Telefonní číslo musí alespon devět čísel.";
            }
            else if (!Int32.TryParse(PhoneNumber, out phone))
                return  "Telefonní číslo může obsahovat maximálne deset čísel.";
            return null;
        }

        #endregion
        
    }
}
