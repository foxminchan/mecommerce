using Ecommerce.Media.Domain;

namespace Ecommerce.Media.Infrastructure.Blob;

public interface IBlobService
{
    Task<string> UploadFileAsync(
        IFormFile file,
        MediaType container,
        CancellationToken cancellationToken = default
    );

    Task DeleteFileAsync(
        string fileName,
        MediaType container,
        CancellationToken cancellationToken = default
    );

    string GetFileUrl(string fileName, MediaType container);
    Task<FileResponse> GetFileAsync(
        string fileName,
        MediaType container,
        CancellationToken cancellationToken = default
    );
}
