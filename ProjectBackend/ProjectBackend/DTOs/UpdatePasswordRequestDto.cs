namespace ProjectBackend.DTOs
{
    public class UpdatePasswordRequestDto
    {
        public string Email { get; set; }

        public int EmailCode { get; set; }

        public string NewPassword { get; set; }
    }
}
