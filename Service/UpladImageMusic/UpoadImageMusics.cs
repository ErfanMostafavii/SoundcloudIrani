
using soundcloud_.Models;

namespace soundcloud_.Service.UpladImageMusic
{
    public class UpoadImageMusics
    {
        private readonly IWebHostEnvironment _webhostenviroment;
        public UpoadImageMusics(IWebHostEnvironment webhostenviroment)
        {
            _webhostenviroment = webhostenviroment;
        }


        public string upload(IFormFile file)
        {
            if (file == null) return "";
            var path = _webhostenviroment.WebRootPath + "\\images\\Music\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;

        }

    }
}
