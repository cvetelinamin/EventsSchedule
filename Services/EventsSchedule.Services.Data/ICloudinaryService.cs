namespace EventsSchedule.Services.Data
{
    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        string UploadPicture(IFormFile pictureFile, string fileName);
    }
}
