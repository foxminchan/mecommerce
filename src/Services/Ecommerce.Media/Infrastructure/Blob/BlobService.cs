using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Ecommerce.Media.Domain;
using Polly;
using Polly.Registry;

namespace Ecommerce.Media.Infrastructure.Blob;

public sealed class BlobService(
    BlobServiceClient client,
    ResiliencePipelineProvider<string> pipeline
) : IBlobService
{
    private readonly ResiliencePipeline _policy = pipeline.GetPipeline(nameof(Blob));

    public async Task<string> UploadFileAsync(
        IFormFile file,
        MediaType container,
        CancellationToken cancellationToken = default
    )
    {
        var blobContainerClient = client.GetBlobContainerClient(container.ToString());
        await blobContainerClient.CreateIfNotExistsAsync(
            PublicAccessType.BlobContainer,
            cancellationToken: cancellationToken
        );
        var fileName = Guid.NewGuid().ToString();
        var blobClient = blobContainerClient.GetBlobClient(fileName);
        await _policy.ExecuteAsync(
            async token =>
                await blobClient.UploadAsync(
                    file.OpenReadStream(),
                    new BlobHttpHeaders { ContentType = file.ContentType },
                    cancellationToken: token
                ),
            cancellationToken
        );
        return fileName;
    }

    public async Task DeleteFileAsync(
        string fileName,
        MediaType container,
        CancellationToken cancellationToken = default
    )
    {
        var blobContainerClient = client.GetBlobContainerClient(container.ToString());
        var blobClient = blobContainerClient.GetBlobClient(fileName);
        await _policy.ExecuteAsync(
            async token =>
                await blobClient.DeleteIfExistsAsync(
                    DeleteSnapshotsOption.IncludeSnapshots,
                    cancellationToken: token
                ),
            cancellationToken
        );
    }

    public string GetFileUrl(string fileName, MediaType container)
    {
        var blobContainerClient = client.GetBlobContainerClient(container.ToString());
        var blobClient = blobContainerClient.GetBlobClient(fileName);
        return blobClient.Uri.AbsoluteUri;
    }

    public async Task<FileResponse> GetFileAsync(
        string fileName,
        MediaType container,
        CancellationToken cancellationToken = default
    )
    {
        var blobContainerClient = client.GetBlobContainerClient(container.ToString());
        var blobClient = blobContainerClient.GetBlobClient(fileName);
        var response = await _policy.ExecuteAsync(
            async token => await blobClient.DownloadContentAsync(cancellationToken: token),
            cancellationToken
        );
        return new(response.Value.Content.ToStream(), response.Value.Details.ContentType, fileName);
    }
}
