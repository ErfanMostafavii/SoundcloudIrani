using soundcloud_.Models;

namespace soundcloud_.Service.UploadMusic
{
    public class UploadMusic
    {

        private readonly IWebHostEnvironment _webhostenviroment;
        public UploadMusic(IWebHostEnvironment webhostenviroment  )
        {
            _webhostenviroment = webhostenviroment;
        }


        public string upload(IFormFile file)
        {
            if (file == null) return "";
            var path = _webhostenviroment.WebRootPath + "\\Musics\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;

        }

    }
}
