using FurnApp_API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FurnApp_API.Med.Queries
{ 

    public class GetCategoryQueries: IRequest <ApiResponse<List<Models.Categories>>>
    {
    }
}
