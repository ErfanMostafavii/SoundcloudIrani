using soundcloud_.Models.ViewModels;

namespace soundcloud_.Service.Queries.GetUserMusic
{
    public interface IGetUserMusic
    {
       List<MusicViewModel> getUserMusic(int UserId);

    }
}
