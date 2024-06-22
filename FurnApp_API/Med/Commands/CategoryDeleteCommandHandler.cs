using FurnApp_API.Med.Commands;
using FurnApp_API.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FurnApp_API.Commands.Handlers
{
    public class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand, ApiResponse<Models.Categories>>
    {
        private readonly FurnAppContext _db;

        public CategoryDeleteCommandHandler(FurnAppContext context)
        {
            _db = context;
        }

        public async Task<ApiResponse<Models.Categories>> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var category = await _db.Categories.FindAsync(request.CategoryId);

            if (category == null)
            {
                return new ApiResponse<Models.Categories>
                {
                    Data = null,
                    Message = "Category not found!",
                    Success = false
                };
            }

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            return new ApiResponse<Models.Categories>
            {
                Data = category,
                Message = "Category was deleted!",
                Success = true
            };
        }
    }
}


