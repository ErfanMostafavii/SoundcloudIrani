using Microsoft.AspNetCore.Identity;
using soundcloud_.Models.Countexts;
using soundcloud_.Models.ViewModels;
using soundcloud_.Models;

namespace soundcloud_.Service.Queries.Authentication
{
    public class UserAuthenticate : IUserAuthenticate
    {
        DataBaseContext _DatabaseContext;
        public UserAuthenticate(DataBaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }
        public UserInfo Authenticate(string username, string password)
        {
           var user= _DatabaseContext.Users.Where(x => x.Email == username).FirstOrDefault();
            if (user == null)
            {


            }
            else
            {
                var isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
                if (!isValid)
                {

                }
                else
                {
                    UserInfo userInfo = new UserInfo()
                    { 
                      UserId = user.id,
                      UserName = user.Email, 
                      family = user.family,
                      name = user.Name,
                      RoleId = user.Roleid,
                     };
                    return userInfo;

                }
            }
            return null;
        }
    }
}
