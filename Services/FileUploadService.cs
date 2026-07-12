namespace StudentPortal.Mvc.Services;

public class FileUploadService : IFileUploadService
{
    private readonly IWebHostEnvironment _environment;

    public FileUploadService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> SaveImageAsync(IFormFile file, string folderName)
    {
        if (file == null || file.Length == 0) throw new Exception("Vui lòng chọn file.");

        // 1. Kiểm tra dung lượng (Tối đa 2MB)
        if (file.Length > 2 * 1024 * 1024)
            throw new Exception("Dung lượng file quá lớn. Tối đa 2MB.");

        // 2. Whitelist: Chỉ cho phép ảnh
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(ext))
            throw new Exception("Định dạng file không hợp lệ! Chỉ nhận .jpg, .png, .webp");

        // 3. Đổi tên file thành Guid để chống đụng độ và Path Traversal
        var safeName = $"{Guid.NewGuid():N}{ext}";
        
        var folderPath = Path.Combine(_environment.WebRootPath, "uploads", folderName);
        Directory.CreateDirectory(folderPath); 
        
        var filePath = Path.Combine(folderPath, safeName);

        using var stream = new FileStream(filePath, FileMode.CreateNew);
        await file.CopyToAsync(stream);

        return $"/uploads/{folderName}/{safeName}";
    }

    public void DeleteFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath)) return;
        var fullPath = Path.Combine(_environment.WebRootPath, filePath.TrimStart('/'));
        if (File.Exists(fullPath)) File.Delete(fullPath);
    }
}