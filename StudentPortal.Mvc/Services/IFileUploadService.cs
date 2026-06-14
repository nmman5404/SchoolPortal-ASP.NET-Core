namespace StudentPortal.Mvc.Services;

public interface IFileUploadService
{
    Task<string> SaveImageAsync(IFormFile file, string folderName);
    void DeleteFile(string filePath);
}