using soundcloud_.Models.Countexts;
using soundcloud_.Models.ViewModels;

namespace soundcloud_.Service.Queries.GetUserInfo
{
    public class GetUserInfo : IGetUserInfo
    {
        DataBaseContext _DatabaseContext;
        public GetUserInfo(DataBaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }
        public UserInfo GetUserinfo(int UserId)
        {

            var user = _DatabaseContext.Users.Where(i=>i.id==UserId).Single();
            UserInfo u=new UserInfo();
            u.UserId = user.id;
            u.name = user.Name;
            u.family = user.family;
            u.UserName = user.Email;
            u.RoleId = user.Roleid;
            u.image = user.UserPhoto;
            return u;
        }
    }
}
