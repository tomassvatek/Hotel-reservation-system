using System;
using Model;
using System.Collections.ObjectModel;
using ViewModel.Commands;

namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _dataGrid = new ObservableCollection<DataGrid>();
            _dataGrid = dataGridService.GetCurrent();

            CurrentCommand = new CurrentCommand(this);
            ReservationCommand = new ReservationCommand(this);
            HistoryCommand = new HistoryCommand(this);
            DeleteCommand = new DeleteCommand(this);
            UpdateCommand = new UpdateCommand(this);
            AvaibleRoomsCommand = new AvaibleRoomsCommand(this);

            SetButtons(true, false, false, true, true);
        }

        #region Properties
        private ObservableCollection<DataGrid> _dataGrid;
        public ObservableCollection<DataGrid> DataGrid
        {
            get { return _dataGrid; }
        }

        private DataGrid _selectedItem;
        public DataGrid SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private bool _isEditable;
        public bool IsEditable
        {
            get { return _isEditable; }
            set
            {
                _isEditable = value;
                OnPropertyChanged("IsEditable");
            }
        }

        private bool _isDeletable;

        public bool IsDeletable
        {
            get { return _isDeletable; }
            set
            {
                _isDeletable = value;
                OnPropertyChanged("IsDeletable");
            }
        }

        private bool _isCurrentEnabled;
        public bool IsCurrentEnabled
        {
            get { return _isCurrentEnabled; }
            set
            {
                _isCurrentEnabled = value;
                OnPropertyChanged("IsCurrentEnabled");
            }
        }

        private bool _isReservationEnabled;
        public bool IsReservationEnabled
        {
            get { return _isReservationEnabled; }
            set
            {
                _isReservationEnabled = value;
                OnPropertyChanged("IsReservationEnabled");
            }
        }

        private bool _isHistoryEnabled;
        public bool IsHistoryEnabled
        {
            get { return _isHistoryEnabled; }
            set
            {
                _isHistoryEnabled = value;
                OnPropertyChanged("IsHistoryEnabled");
            }
        }

        public bool IsDateEnabled
        {
            get
            {
                if (SelectedItem.Accommodation.StartDate > DateTime.Today)
                    return true;
                else
                    return false;
            }
        }

        private bool _isComboBoxEnabled;
        public bool IsComboBoxEnabled
        {
            get
            {
                if (_selectedItem.Accommodation.PaymentStatus == "Zaplaceno")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                _isComboBoxEnabled = value;
                OnPropertyChanged("IsComboBoxEnabled");
            }
        }

        #endregion

        #region Command members
        /*Načte do DataGridu aktuální pobyty.*/
        public CurrentCommand CurrentCommand { get; set; }
        /*Načte do DataGridu budoucí pobyty.*/
        public ReservationCommand ReservationCommand { get; set; }
        /*Načte do DataGridu hitorii pobytů.*/
        public HistoryCommand HistoryCommand { get; set; }
        /*Odstranění jednoho záznamu*/
        public DeleteCommand DeleteCommand { get; set; }
        /*Upravení jednoho záznamu*/
        public UpdateCommand UpdateCommand { get; set; }
        /*Vyhledá dostupné pokoje*/
        public AvaibleRoomsCommand AvaibleRoomsCommand { get; set; }
        #endregion

        #region Methods
        private void SetButtons(bool isEditable, bool isDeletable, bool isCurrentEnabled, bool isReservationEnabled, bool isHistoryEnabled)
        {
            IsEditable = isEditable;
            IsDeletable = isDeletable;
            IsCurrentEnabled = isCurrentEnabled;
            IsReservationEnabled = isReservationEnabled;
            IsHistoryEnabled = isHistoryEnabled;
        }

        public void SetCurrent()
        {
            _dataGrid = dataGridService.GetCurrent();
            SetButtons(true, false, false, true, true);
        }

        public void SetReservation()
        {
            _dataGrid = dataGridService.GetReservation();
            SetButtons(true, true, true, false, true);
        }

        public void SetHistory()
        {
            _dataGrid = dataGridService.GetHistory();
            SetButtons(false, true, true, true, false);
        }

        public void DeleteAccommodation()
        {
            if (_selectedItem != null)
            {
                accommodationService.DeleteAccommodation(_selectedItem.Accommodation);
                _dataGrid.Remove(_selectedItem);
            }
        }

        public void UpdateAccommodation()
        {
            guestService.UpdateGuest(_selectedItem.Guest);
            accommodationService.UpdateAccommodation(_selectedItem.Accommodation, SelectedRoom);
        }

        public override void LoadRooms()
        {
            roomService.SelectAvaibleRooms(_selectedItem.Accommodation, _rooms);
            if (!roomService.ContainRoom(_rooms, _selectedItem.Room))
            _rooms.Add(_selectedItem.Room);
        }
        #endregion
    }
}

