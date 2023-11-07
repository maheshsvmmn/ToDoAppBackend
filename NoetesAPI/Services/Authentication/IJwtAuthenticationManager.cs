namespace NoetesAPI.Services.Authentication
{
    public interface IJwtAuthenticationManager
    {
        public string Authenticate(string email, string password);
    }
}
