using Model;
using DataAccess;
using ViewModel.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Collections.Generic;

namespace ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
            _rooms = new ObservableCollection<Room>();
            _comboBox = new List<string>();

            dataGridService = new DataGridService();
            accommodationService = new AccommodationService();
            guestService = new GuestService();
            roomService = new RoomService();
        }

        protected DataGridService dataGridService;
        protected AccommodationService accommodationService;
        protected GuestService guestService;
        protected RoomService roomService;

        protected ObservableCollection<Room> _rooms;

        public ObservableCollection<Room> Rooms
        {
            get { return _rooms; }
        }

        protected Room _selectedRoom;

        public Room SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                _selectedRoom = value;
                OnPropertyChanged("SelectedRoom");
            }
        }

        private List<string> _comboBox;

        public List<string> ComboBox
        {
            get
            {
                _comboBox.Clear();
                _comboBox.Add("Zaplaceno");
                _comboBox.Add("Nezaplaceno");
                return _comboBox;
            }
        }


        public DateTime Today {get { return DateTime.Today; } }

        public void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        public abstract void LoadRooms();

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
