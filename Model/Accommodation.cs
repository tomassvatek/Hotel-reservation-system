using System;
using System.ComponentModel;

namespace Model
{
    public class Accommodation : IDataErrorInfo
    {
        #region Constructors
        public Accommodation(int id, DateTime startDate, DateTime endDate, decimal price, string paymentStatus, int guestId, int roomId)
        {
            _id = id;
            _startDate = startDate;
            _endDate = endDate;
            _paymentStatus = paymentStatus;
            _price = price;
            GuestId = guestId;
            RoomNumber = roomId;
        }

        public Accommodation()
        {
            _startDate = DateTime.Today;
            _endDate = DateTime.Today.AddDays(1);
            _paymentStatus = "Nezaplaceno";
        }
        #endregion

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
            }

        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
            }
        }

        private decimal _price;

        public decimal Price
        {
            get
            {
             return _price;
            }
            set { _price = value; }
        }

        private string _paymentStatus;

        public string PaymentStatus
        {
            get { return _paymentStatus; }
            set
            {
                _paymentStatus = value;
            }
        }

        public int GuestId { get; set; }

        public int RoomNumber { get; set; }

        public Guest Guest { get; set; }

        public Room Room { get; set; }

        public int Days
        {
            get
            {
                return (_endDate.DayOfYear + 1) - _startDate.DayOfYear;
            }
        }

        public override string ToString()
        {
            return $"Host: {GuestId} Pokoj: {RoomNumber} {_startDate.ToShortDateString()} - {_endDate.ToShortDateString()}";
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
            "StartDate", "EndDate"
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
                case "StartDate":
                    error = ValidateStartDate();
                    break;
                case "EndDate":
                    error = ValidateEndDate();
                    break;
            }
            return error;
        }

        private string ValidateStartDate()
        {
            if (StartDate < DateTime.Today)
            {
                return "Začátek pobytu nesmí být v minulosti.";
            }
            else if(StartDate == EndDate)
            {
                return "Pobyt musí být alespon na dva dny";
            }
            return null;
        }

        private string ValidateEndDate()
        {
            if (StartDate > EndDate)
            {
                return "Konec pobytu musí následovat začátek pobytu.";
            }
            else if (StartDate == EndDate)
            {
                return "Pobyt musí být alespon na dva dny";
            }
            return null;
        }
        #endregion
    }
}
