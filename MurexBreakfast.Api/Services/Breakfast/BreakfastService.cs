using MurexBreakfast.Api.Data;
using MurexBreakfast.Contracts.Breakfast;
using MurexBreakfast.Api.Models;

namespace MurexBreakfast.Api.Services.Breakfast
{
    public class BreakfastService : IBreakfastService
    {
        private readonly MurexBreakfastContext _context;
        public BreakfastService(MurexBreakfastContext context)
        {
            _context = context;
        }
        public async Task<CreateBreakfastResponse> CreateBreakfastAsync(CreateBreakfastRequest request)
        {
            return await Task.FromResult(new CreateBreakfastResponse());
        }
    }
}
