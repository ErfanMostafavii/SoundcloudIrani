using soundcloud_.Models.ViewModels;

namespace soundcloud_.Service.Queries.GetUserInfo
{
    public interface IGetUserInfo
    {
        UserInfo GetUserinfo(int UserId);

    }
}
