using System;

namespace DemoHotelReservation.Entities.Exceptions
{
    internal class DomainException : ApplicationException
    {
        public DomainException(string message)
            : base(message)
        {

        }
    }
}
