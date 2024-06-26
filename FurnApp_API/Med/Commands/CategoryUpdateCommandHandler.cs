﻿using FurnApp_API.Models;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using FurnApp_API.Med.Commands;
using FurnApp_API.Security;
using System.Threading;

namespace FurnApp_API.Commands.Handlers
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, ApiResponse<Models.Categories>>
    {
        private readonly FurnAppContext _db;

        public CategoryUpdateCommandHandler(FurnAppContext context)
        {
            _db = context;
        }

        public async Task<ApiResponse<Models.Categories>> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
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

            if (string.IsNullOrWhiteSpace(request.CategoryName))
            {
                return new ApiResponse<Models.Categories>
                {
                    Data = null,
                    Message = "Category name cannot be empty!",
                    Success = false
                };
            }

            category.CategoryName = request.CategoryName;
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();

            return new ApiResponse<Models.Categories>
            {
                Data = category,
                Message = "Category was updated!",
                Success = true
            };
        }
    }
}
