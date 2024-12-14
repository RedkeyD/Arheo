using Arheo.Domain;

namespace Arheo.Application.Repositories
{
    public interface IFileMetadata
    {
        Task<List<FileMetadata>> GetAllFilesAsync();
        Task<FileMetadata> GetFileByIdAsync( Guid id );
        Task AddFileAsync( FileMetadata file );
        Task DeleteFileAsync( Guid id );
    }
}
