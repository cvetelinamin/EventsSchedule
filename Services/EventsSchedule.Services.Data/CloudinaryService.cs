namespace EventsSchedule.Services.Data
{
    using System.IO;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinaryUtility;

        public CloudinaryService(Cloudinary cloudinaryUtility)
        {
            this.cloudinaryUtility = cloudinaryUtility;
        }

        public string UploadPicture(IFormFile pictureFile, string fileName)
        {
            if (pictureFile != null)
            {
                byte[] destinationData;

                using (var ms = new MemoryStream())
                {
                    pictureFile.CopyTo(ms);
                    destinationData = ms.ToArray();
                }

                UploadResult uploadResult = null;

                using (var ms = new MemoryStream(destinationData))
                {
                    ImageUploadParams uploadParams = new ImageUploadParams
                    {
                        Folder = "product_images",
                        File = new FileDescription(fileName, ms),
                    };

                    uploadResult = this.cloudinaryUtility.Upload(uploadParams);
                }

                return uploadResult?.SecureUri.AbsoluteUri;
            }

            return string.Empty;
        }
    }
}
