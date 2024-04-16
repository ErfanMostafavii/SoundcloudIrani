using soundcloud_.Models.ViewModels;

namespace soundcloud_.Service.Queries.GetAllMusic
{
    public interface IGetAllMusic
    {
        Task<List<UserMusicViewModel>> getAllMusic();

    }
}
 