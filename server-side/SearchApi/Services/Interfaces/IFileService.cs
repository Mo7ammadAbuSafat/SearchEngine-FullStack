namespace SearchApi.Services.Interfaces
{
    public interface IFileService
    {
        void DeleteFile(string filePath);
        Task<string> StoreImageToLocalFolder(IFormFile file);
    }
}