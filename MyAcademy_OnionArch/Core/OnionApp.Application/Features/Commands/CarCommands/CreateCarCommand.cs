using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.CarCommands
{
    public record CreateCarCommand(int BrandID, string Model, string CoverImageUrl, int Km, string Transmission, byte Seat, byte Luggage, string Fuel, string BigImageUrl) : IRequest<BaseResult<object>>;
}
