namespace Application.Features.Auth.Dtos;
public class RegisterDto
{
    public BaseAuthDto User { get; set; }
    // ... diğer verilecek kayıt bilgileri
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
}