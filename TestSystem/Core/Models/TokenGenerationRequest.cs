namespace TestSystem.Core.Models
{
    public class TokenGenerationRequest
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
