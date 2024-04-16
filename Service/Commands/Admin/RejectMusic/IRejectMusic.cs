using soundcloud_.Models.Utilitis;

namespace soundcloud_.Service.Commands.Admin.RejectMusic
{
    public interface IRejectMusic
    {
      public  Task<ServiseResponse> rejectMusic(int MusicId);

    }
}
