using Microsoft.AspNetCore.Http;

namespace SedisBackend.Core.Application.Helpers
{
    public class UploadImage
    {
        public static string UploadFile(IFormFile file, dynamic id, string baseDirectory, bool isEditMode = false, string imagePath = "")
        {
            if (isEditMode || (file == null && imagePath == null))
            {
                if (file == null)
                {
                    return imagePath;
                }
            }
            string basePath = $"/Images/{baseDirectory}/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //create folder if not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //get file extension
            Guid guid = Guid.NewGuid();
            FileInfo fileinfo = new(file.FileName);
            string filename = guid + fileinfo.Extension;

            string fileNameWithPath = Path.Combine(path, filename);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = imagePath.Split("/");
                string oldImagePath = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImagePath);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }
            return $"{basePath}/{filename}";
        }
    }
}
