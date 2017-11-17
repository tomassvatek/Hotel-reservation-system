using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using DataAccess;
using ViewModel;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Room room = new Room() { Number = 1, Price = 2000 };
            ////pozor na NULL u phoneNumber
            //Guest guest = new Guest() {Id = 9, FirstName = "Pepa", LastName = "Bedna", Email = "email", PhoneNumber = "phone" };
            Accommodation ac = new Accommodation() {StartDate = DateTime.Parse("14.2.2017"),
                                                    EndDate = DateTime.Parse("17.2.2017")};
            HotelData data = new HotelData();
            //Guest g = new Guest() { Email = "Jarda20", FirstName = "no" };
            //Accommodation up = new Accommodation() { RoomNumber = 2 };
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            data.SelectAvaibleRooms(ac, rooms);

            //Console.WriteLine(ac);
            //MainViewModel vm = new MainViewModel();
            foreach (var item in rooms)
            {
                Console.WriteLine(item);
            }
        }
    }
}     
