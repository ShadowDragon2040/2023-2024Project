namespace authApi.Models.Dtos
{
    public class RegisterRequestDto
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
