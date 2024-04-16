using soundcloud_.Models.ViewModels;

namespace soundcloud_.Service.Queries.UserPlaylist
{
    public interface IGetUserPlaylist
    {
        List<UserMusicViewModel> getUserPlaylist(int UserId);

    }
}
