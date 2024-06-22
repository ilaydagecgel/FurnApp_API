using FurnApp_API.Med.Commands;
using FurnApp_API.Models;
using System.Threading;
using System.Threading.Tasks;

namespace FurnApp_API.Commands.Handlers
{
    public interface ICategoryDeleteCommandHandler<T>
    {
        Task<ApiResponse<T>> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken);
    }
}