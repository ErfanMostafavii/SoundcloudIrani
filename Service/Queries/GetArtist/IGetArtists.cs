using soundcloud_.Models.ViewModels;

namespace soundcloud_.Service.Queries.GetArtist
{
    public interface IGetArtists
    {
        Task<List<ArtistsModelView>> getArtists();
    }
}
