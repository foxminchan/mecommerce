using Azure;
using Polly;

namespace Ecommerce.Media.Infrastructure.Blob;

internal static class Extensions
{
    public static void AddAzureBlobService(this IHostApplicationBuilder builder)
    {
        builder.AddAzureBlobClient(ServiceName.Blob);

        builder.Services.AddResiliencePipeline(
            nameof(Blob),
            resiliencePipelineBuilder =>
                resiliencePipelineBuilder
                    .AddRetry(
                        new()
                        {
                            ShouldHandle = new PredicateBuilder().Handle<RequestFailedException>(),
                            Delay = TimeSpan.FromSeconds(2),
                            MaxRetryAttempts = 3,
                            BackoffType = DelayBackoffType.Constant,
                        }
                    )
                    .AddTimeout(TimeSpan.FromSeconds(10))
        );

        builder.Services.AddSingleton<IBlobService, BlobService>();
    }
}
