using System.ComponentModel.DataAnnotations;

namespace LumiBeam.API.DTOs.Auth
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "Номер телефону є обов'язковим.")]
        [Phone(ErrorMessage = "Некоректний формат номера телефону.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пароль є обов'язковим.")]
        public string Password { get; set; } = string.Empty;
    }
}
