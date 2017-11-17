using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class DataGrid : INotifyPropertyChanged
    {
        public DataGrid()
        {
            _accommodation = new Accommodation();
            _guest = new Guest();
            _room = new Room();
        }

        public DataGrid(Guest guest, Room room, Accommodation accommodation)
        {
            _guest = guest;
            _room = room;
            _accommodation = accommodation;
        }

        private Accommodation _accommodation;
        public Accommodation Accommodation
        {
            get { return _accommodation; }
            set
            {
                _accommodation = value;
                OnPropertyChanged("Accommodation");
            }
        }
        private Guest _guest;
        public Guest Guest
        {
            get { return _guest; }
            set
            {
                _guest = value;
                OnPropertyChanged("Guest");
            }
        }
        private Room _room;
        public Room Room
        {
            get { return _room; }
            set
            {
                _room = value;
                OnPropertyChanged("Room");
            }
        }
        public override string ToString()
        {
            return $"{Guest} {Room} {Accommodation}";
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
