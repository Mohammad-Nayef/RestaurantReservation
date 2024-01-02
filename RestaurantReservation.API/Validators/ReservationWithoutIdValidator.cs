using FluentValidation;
using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Validators
{
    public class ReservationWithoutIdValidator : AbstractValidator<ReservationWithoutIdDTO>
    {
        public ReservationWithoutIdValidator()
        {
            RuleFor(reservation => reservation.PartySize)
                .GreaterThanOrEqualTo(0);
        }
    }
}
