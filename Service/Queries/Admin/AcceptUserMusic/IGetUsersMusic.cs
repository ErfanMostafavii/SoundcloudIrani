using soundcloud_.Models.ViewModels;

namespace soundcloud_.Service.Queries.Admin.AcceptUserMusic
{
    public interface IGetUsersMusic
    {
         Task<List<AdminUserMusicModelView>> getUsersMusic();

    }
}
