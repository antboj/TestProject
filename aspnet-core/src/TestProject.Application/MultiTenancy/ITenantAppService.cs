using Abp.Application.Services;
using TestProject.MultiTenancy.Dto;

namespace TestProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto,
        CreateTenantDto, TenantDto>
    {
    }
}