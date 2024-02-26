namespace authApi.Models.Dtos
{
    public class VerificationRequestDto
    {
        public string Email { get; set; }

        public int EmailCode { get; set;}
    }
}
