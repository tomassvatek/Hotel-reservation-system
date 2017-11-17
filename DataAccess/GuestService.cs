using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GuestService
    {
        public void UpdateGuest(Guest original)
        {
            original.FirstName = original.FirstName;
            using (HotelContext ctx = new HotelContext())
            {
                ctx.Guests.Attach(original);
                var entry = ctx.Entry(original);

                entry.Property(e => e.Email).IsModified = true;
                entry.Property(e => e.PhoneNumber).IsModified = true;

                original.Email = original.Email;
                original.PhoneNumber = original.PhoneNumber;

                ctx.SaveChanges();
            }
        }

        public static Guest IsExistGuest(Guest guest)
        {
            try
            {
                using (HotelContext ctx = new HotelContext())
                {
                    var query = ctx.Guests.Where(
                                           g => g.FirstName.Contains(guest.FirstName) &&
                                           g.LastName.Contains(guest.LastName) &&
                                           g.PhoneNumber.Contains(guest.PhoneNumber) &&
                                           g.Email.Contains(guest.Email)
                                           ).First();
                    return query;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
