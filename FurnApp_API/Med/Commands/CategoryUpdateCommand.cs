﻿using FurnApp_API.DTO;
using FurnApp_API.Models;
using FurnApp_API.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnApp_API.Med.Commands
{
    public class CategoryUpdateCommand : IRequest<ApiResponse<Models.Categories>>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
