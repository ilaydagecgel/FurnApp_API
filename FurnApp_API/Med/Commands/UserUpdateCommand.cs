using FurnApp_API.DTO;
using FurnApp_API.Models;
using FurnApp_API.Security;
using MediatR;

namespace FurnApp_API.Med.Commands
{
    public class UserUpdateCommand : IRequest<ApiResponse<Token>>
    {
        public string UserMail { get; set; }
        public UserUpdateDTO UserUpdate { get; set; }
    }
}