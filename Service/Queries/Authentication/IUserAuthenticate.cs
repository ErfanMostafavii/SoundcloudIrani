using soundcloud_.Models.ViewModels;
using soundcloud_.Models;

namespace soundcloud_.Service.Queries.Authentication
{
    public interface IUserAuthenticate
    {

        public UserInfo Authenticate(string username, string password);
    }
}
