namespace Pera.UtangApi.Services
{
    public class UserService : IUserService
    {
        public bool ValidateCredentials(string userName, string password)
        {
            return userName.Equals("demo") && password.Equals("demo");
        }
    }
}