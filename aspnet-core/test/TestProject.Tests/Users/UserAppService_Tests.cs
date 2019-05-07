using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using TestProject.Users;
using TestProject.Users.Dto;
using Xunit;

namespace TestProject.Tests.Users
{
    public class UserAppService_Tests : TestProjectTestBase
    {
        public UserAppService_Tests()
        {
            _userAppService = Resolve<IUserAppService>();
        }

        private readonly IUserAppService _userAppService;

        [Fact]
        public async Task CreateUser_Test()
        {
            // Act
            await _userAppService.Create(
                new CreateUserDto
                {
                    EmailAddress = "john@volosoft.com",
                    IsActive = true,
                    Name = "John",
                    Surname = "Nash",
                    Password = "123qwe",
                    UserName = "john.nash"
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john.nash");
                johnNashUser.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            // Act
            var output =
                await _userAppService.GetAll(new PagedUserResultRequestDto {MaxResultCount = 20, SkipCount = 0});

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }
    }
}