using soundcloud_.Models.Utilitis;
using soundcloud_.Models;

namespace soundcloud_.Service.Commands.Musics
{
    public interface IAddMusics
    {

        Task<ServiseResponse> AddNewMusic(Music m);

    }
}
