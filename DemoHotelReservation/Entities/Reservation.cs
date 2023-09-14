using System;
using DemoHotelReservation.Entities.Exceptions;

namespace DemoHotelReservation.Entities
{
    internal class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation() { }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (DatesOk(checkIn, checkOut))
            {
                RoomNumber = roomNumber;
                CheckIn = checkIn;
                CheckOut = checkOut;
            }
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }
        private Boolean DatesOk(DateTime checkin, DateTime checkout)
        {
            DateTime now = DateTime.Now;
            if (checkout < checkin)
            {
                throw new DomainException("Check-out date must be after check-in date!");
            }
            if (checkin < now || checkout < now)
            {
                throw new DomainException("Reservation dates for update must be future dates!");
            }
            return true;
        }

        public void UpdateDates(DateTime checkin, DateTime checkout)
        {
            if (DatesOk(checkin, checkout))
            {
                CheckIn = checkin;
                CheckOut = checkout;
            }
        }

        public override string ToString()
        {
            return "Room: "
                + RoomNumber
                + ", check-in: "
                + CheckIn.ToString("dd/MM/yyyy")
                + ", check-out: "
                + CheckOut.ToString("dd/MM/yyyy")
                + ", Duration: "
                + (Duration() > 1 ? Duration().ToString() + " nights." : Duration().ToString() + " night.");
        }
    }
}
