using System;
using DemoHotelReservation.Entities;
using DemoHotelReservation.Entities.Exceptions;
namespace DemoHotelReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Room number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Check-in date (DD/MM/YYYY): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (DD/MM/YYYY): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());
                Reservation reserv = new Reservation(number, checkIn, checkOut);
                Console.WriteLine("Reservation: " + reserv);

                Console.WriteLine("\nEnter data to update the reservation:");
                Console.Write("Check-in date (DD/MM/YYYY): ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (DD/MM/YYYY): ");
                checkOut = DateTime.Parse(Console.ReadLine());
                reserv.UpdateDates(checkIn, checkOut);
                Console.WriteLine("Reservation: " + reserv);
            }
            catch (DomainException e) 
            {
                Console.WriteLine("Error in reservation: "+e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}