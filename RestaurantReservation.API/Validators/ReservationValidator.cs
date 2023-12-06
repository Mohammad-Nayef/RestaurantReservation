using FluentValidation;
using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Validators
{
    public class ReservationValidator : AbstractValidator<ReservationWithoutIdDTO>
    {
        public ReservationValidator()
        {
            RuleFor(reservation => reservation.PartySize)
                .GreaterThanOrEqualTo(0);
        }
    }
}
