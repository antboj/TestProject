using System.Threading.Tasks;
using TestProject.Configuration.Dto;

namespace TestProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
