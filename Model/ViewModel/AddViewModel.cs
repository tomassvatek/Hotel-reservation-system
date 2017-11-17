using System;
using Model;
using ViewModel.Commands;

namespace ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        public AddViewModel()
        {
            _guest = new Guest();
            _accommodation = new Accommodation();
            
            SaveCommand = new SaveCommand(this);
            AvaibleRoomsCommand = new AvaibleRoomsCommand(this);
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

        //private bool _canSave;

        //public bool CanSave
        //{
        //    get
        //    {
        //        if(SelectedRoom == null)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    set
        //    {
        //        _canSave = value;
        //        OnPropertyChanged("CanSave");
        //    }
        //}


        #region Command members
        public AvaibleRoomsCommand AvaibleRoomsCommand { get; set; }
        public SaveCommand SaveCommand { get; set; }
        #endregion

        #region Methods
        public void SaveAccommodation()
        {
            accommodationService.SaveAccommodation(_guest, _selectedRoom, _accommodation);
        }

        public override void LoadRooms()
        {
            roomService.SelectAvaibleRooms(_accommodation,_rooms);
        }
        #endregion
    }
}
