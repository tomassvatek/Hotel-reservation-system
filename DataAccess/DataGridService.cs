using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace DataAccess
{
    public class DataGridService
    {
        private ObservableCollection<DataGrid> dataGrid;

        public DataGridService()
        {
            dataGrid = new ObservableCollection<DataGrid>();
        }

        private ObservableCollection<DataGrid> GetAll()
        {
            dataGrid.Clear();
            using (HotelContext ctx = new HotelContext())
            {
                var query = from r in ctx.Rooms
                            join a in ctx.Accommodations
                            on r.Number equals a.Room.Number
                            join g in ctx.Guests
                            on a.Guest.Id equals g.Id
                            select new
                            {
                                guestId = g.Id,
                                fistName = g.FirstName,
                                lastName = g.LastName,
                                email = g.Email,
                                phoneNumber = g.PhoneNumber,
                                roomNumber = r.Number,
                                capacity = r.Capacity,
                                price = r.Price,
                                accommodationId = a.Id,
                                startDate = a.StartDate,
                                endDate = a.EndDate,
                                totalPrice = a.Price,
                                paymentStatus = a.PaymentStatus
                            };

                foreach (var item in query)
                {
                    dataGrid.Add(new DataGrid()
                    {
                        Guest = new Guest(item.guestId, item.fistName, item.lastName,
                                          item.phoneNumber, item.email),

                        Room = new Room(item.roomNumber, item.capacity, item.price),

                        Accommodation = new Accommodation(item.accommodationId, item.startDate,
                                                          item.endDate, item.totalPrice,
                                                          item.paymentStatus, item.guestId,
                                                          item.roomNumber)
                    });
                }
                return dataGrid;
            }
        }

        private void AddRange(List<DataGrid> list)
        {
            foreach (var item in list)
            {
                dataGrid.Add(new DataGrid()
                {
                    Guest = new Guest(item.Guest.Id, item.Guest.FirstName, item.Guest.LastName,
                                      item.Guest.PhoneNumber, item.Guest.Email),

                    Room = new Room(item.Room.Number, item.Room.Capacity, item.Room.Price),

                    Accommodation = new Accommodation(item.Accommodation.Id,
                                                      item.Accommodation.StartDate,
                                                      item.Accommodation.EndDate,
                                                      item.Accommodation.Price,
                                                      item.Accommodation.PaymentStatus,
                                                      item.Accommodation.GuestId,
                                                      item.Accommodation.RoomNumber)
                });
            }

        }

        public ObservableCollection<DataGrid> GetCurrent()
        {
            GetAll();
            var query = dataGrid.Where(s => s.Accommodation.StartDate <= DateTime.Today &&
                                s.Accommodation.EndDate >= DateTime.Today).ToList<DataGrid>();
            dataGrid.Clear();
            AddRange(query);
            return dataGrid;
        }

        public ObservableCollection<DataGrid> GetReservation()
        {
            GetAll();
            var query = dataGrid.Where(s => s.Accommodation.StartDate > DateTime.Today &&
                                s.Accommodation.EndDate > DateTime.Today).ToList<DataGrid>();
            dataGrid.Clear();
            AddRange(query);
            return dataGrid;
        }


        public ObservableCollection<DataGrid> GetHistory()
        {
            GetAll();
            var query = dataGrid.Where(s => s.Accommodation.StartDate < DateTime.Today &&
                                      s.Accommodation.EndDate < DateTime.Today)
                                      .ToList<DataGrid>();
            dataGrid.Clear();
            AddRange(query);
            return dataGrid;
        }
    }
}
