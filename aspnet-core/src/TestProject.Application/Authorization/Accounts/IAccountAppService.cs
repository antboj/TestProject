using System.Threading.Tasks;
using Abp.Application.Services;
using TestProject.Authorization.Accounts.Dto;

namespace TestProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
