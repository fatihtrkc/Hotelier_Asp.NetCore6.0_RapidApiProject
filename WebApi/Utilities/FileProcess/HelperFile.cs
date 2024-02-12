namespace WebApi.Utilities.FileProcess
{
    internal static class HelperFile
    {
        internal static string GenerateUniqueFileName(IFormFile file)
        {
            if (file is null) return null;

            return Guid.NewGuid() + "_" + file.FileName;
        }

        internal static bool isValidImageFormat(IFormFile image)
        {
            if (image is null) return false;

            var validFormats = new[] { ".jpg", ".jpeg", ".png" };

            var fileExtension = Path.GetExtension(image.FileName);

            return validFormats.Contains(fileExtension.ToLower());
        }

        internal static bool IsValidFileFormat(IFormFile file)
        {
            if (file is null) return false;

            var validFormats = new[] { ".pdf", ".docx" };

            var fileExtension = Path.GetExtension(file.FileName);

            return validFormats.Contains(fileExtension.ToLower());
        }
    }
}
