namespace Pera.UtangApi.Services
{
    public interface IUserService
    {
        public bool ValidateCredentials(string username, string password);
    }
}