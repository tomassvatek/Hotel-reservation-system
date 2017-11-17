using Model;
using System;
using System.Windows;

namespace DataAccess
{
    public class AccommodationService
    {
        #region Accommodation
        public void SaveAccommodation(Guest guest, Room room, Accommodation ac)
        {
            try
            {
                using (HotelContext ctx = new HotelContext())
                {
                    Guest existGuest = GuestService.IsExistGuest(guest);
                    SetPrice(ac, room);

                    if (existGuest != null)
                    {
                        ac.GuestId = existGuest.Id;
                        ac.RoomNumber = room.Number;
                        ac.PaymentStatus = ac.PaymentStatus;
                        ctx.Entry(ac).State = System.Data.Entity.EntityState.Added;
                        ctx.SaveChanges();
                    }
                    else
                    {
                        ctx.Entry(guest).State = System.Data.Entity.EntityState.Added;
                        ac.GuestId = guest.Id;
                        ac.RoomNumber = room.Number;
                        ac.PaymentStatus = ac.PaymentStatus;
                        ctx.Entry(ac).State = System.Data.Entity.EntityState.Added;
                        ctx.SaveChanges();
                    }
                }
            }

            catch(Exception)
            {
                string caption = "Neplatně zadané údaje";
                string messageBoxText = "Chyba při ukládání. Nevyplnil jste všechny údaje. Zkuste to prosím znovu.";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        public void UpdateAccommodation(Accommodation ac, Room room)
        {
            using (HotelContext ctx = new HotelContext())
            {
                ctx.Accommodations.Attach(ac);
                var entry = ctx.Entry(ac);

                entry.Property(e => e.StartDate).IsModified = true;
                entry.Property(e => e.EndDate).IsModified = true;
                entry.Property(e => e.RoomNumber).IsModified = true;
                entry.Property(e => e.Price).IsModified = true;
                entry.Property(e => e.PaymentStatus).IsModified = true;


                ac.StartDate = ac.StartDate;
                ac.EndDate = ac.EndDate;
                ac.PaymentStatus = ac.PaymentStatus;
                if (room != null)
                {
                    ac.RoomNumber = room.Number;
                    SetPrice(ac, room);
                }
                ctx.SaveChanges();
            }
        }

        public void DeleteAccommodation(Accommodation acToDelete)
        {
            using (HotelContext ctx = new HotelContext())
            {
                acToDelete = ctx.Accommodations.Find(acToDelete.Id);
            }

            using (HotelContext ctx = new HotelContext())
            {
                ctx.Entry(acToDelete).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public void SetPrice(Accommodation ac, Room room)
        {
            ac.Price = ac.Days * room.Price;
        }
        #endregion
    }
}
