using System.Collections.Generic;

namespace Model
{
    public class Room
    {
        #region Constructors
        public Room()
        {
        }

        public Room(int number, int capacity, decimal price)
        {
            _number = number;
            _capacity = capacity;
            _price = price;
            Accommodations = new List<Accommodation>();
        }

        #endregion

        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private int _capacity;

        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        private decimal _price;

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public ICollection<Accommodation> Accommodations { get; set; }

        public override string ToString()
        {
            return $"Číslo pokoje {Number}";
        }
    }
}
