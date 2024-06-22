using FurnApp_API.Models;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using FurnApp_API.Med.Commands;
using FurnApp_API.Security;
using System.Threading;

namespace FurnApp_API.Commands.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ApiResponse<Models.Categories>>
    {
        private readonly FurnAppContext _db;

        public CreateCategoryCommandHandler(FurnAppContext context)
        {
            _db = context;
        }

        public async Task<ApiResponse<Models.Categories>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request.CategoryName == null)
            {
                return new ApiResponse<Models.Categories>
                {
                    Data = null,
                    Message = "There is no CategoryNamw!",
                    Success = false
                };
            }
             
            var category= new Models.Categories() {CategoryName=request.CategoryName };
            await _db.Categories.AddAsync(category);   
            await _db.SaveChangesAsync();

            return new ApiResponse<Models.Categories>
            {
                Data = category,
                Message="Category was created!",
                Success = true
            };
        }
    }
}
