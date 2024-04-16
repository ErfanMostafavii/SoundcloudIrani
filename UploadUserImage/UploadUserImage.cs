namespace soundcloud_.UploadUserName
{
    public class UploadUserImage
    {
        private readonly IWebHostEnvironment _webhostenviroment;
        public UploadUserImage(IWebHostEnvironment webhostenviroment)
        {
            _webhostenviroment = webhostenviroment;
        }


        public string upload(IFormFile file)
        {
            if (file == null) return "";
            var path = _webhostenviroment.WebRootPath + "\\images\\Users\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;

        }
    }
}
