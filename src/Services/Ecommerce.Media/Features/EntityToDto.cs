using Ecommerce.Media.Domain;

namespace Ecommerce.Media.Features;

public static class EntityToDto
{
    public static ImageDto ToImageDto(this Image image, string? url)
    {
        return new(image.Id, url ?? image.FileName, image.Caption, image.Type);
    }
}
