using soundcloud_.Models.Utilitis;
using soundcloud_.Models;

namespace soundcloud_.Service.Commands.Admin.AcceptMusic
{
    public interface IAcceptMusic
    {
        Task<ServiseResponse> acceptMusic(int MusicId);

    }
}
