using System;
using System.ComponentModel.DataAnnotations;

namespace Flights.Domain.Entities
{
	public record Booking(
        string PassengerEmail,
        byte NumberOfSeats);
}

