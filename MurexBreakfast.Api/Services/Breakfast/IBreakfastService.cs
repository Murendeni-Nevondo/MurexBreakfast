using MurexBreakfast.Contracts.Breakfast;

namespace MurexBreakfast.Api.Services.Breakfast
{
    public interface IBreakfastService
    {
        Task<CreateBreakfastResponse> CreateBreakfastAsync(CreateBreakfastRequest request);
    }
}
