using System.ComponentModel.DataAnnotations;

namespace TestProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}