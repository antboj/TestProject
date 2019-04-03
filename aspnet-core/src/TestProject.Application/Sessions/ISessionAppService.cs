using System.Threading.Tasks;
using Abp.Application.Services;
using TestProject.Sessions.Dto;

namespace TestProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
