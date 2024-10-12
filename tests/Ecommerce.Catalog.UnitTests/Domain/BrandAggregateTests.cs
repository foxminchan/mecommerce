using Ecommerce.Catalog.Domain.BrandAggregate;

namespace Ecommerce.Catalog.UnitTests.Domain;

public sealed class BrandAggregateTests
{
    [Fact]
    public void Given_ValidParameters_When_CreatingBrand_Then_ShouldCreateBrandSuccessfully()
    {
        // Arrange
        const string? name = "Test Brand";
        const string? slug = "test-brand";
        const int displayOrder = 1;
        const string? description = "Test description";
        const string? metaTitle = "Meta Title";
        const string? metaDescription = "Meta Description";
        const string? metaKeywords = "Meta Keywords";
        Guid? thumbnailId = Guid.NewGuid();

        // Act
        var brand = new Brand(
            name,
            description,
            slug,
            metaTitle,
            metaDescription,
            metaKeywords,
            displayOrder,
            thumbnailId
        );

        // Assert
        brand.Name.Should().Be(name);
        brand.Slug.Should().Be(slug);
        brand.DisplayOrder.Should().Be(displayOrder);
        brand.Description.Should().Be(description);
        brand.MetaTitle.Should().Be(metaTitle);
        brand.MetaDescription.Should().Be(metaDescription);
        brand.MetaKeywords.Should().Be(metaKeywords);
        brand.ThumbnailId.Should().Be(thumbnailId);
        brand.Products.Should().BeEmpty();
        brand.IsDeleted.Should().BeFalse();
    }

    [Fact]
    public void Given_InvalidDisplayOrder_When_CreatingBrand_Then_ShouldThrowArgumentException()
    {
        // Arrange
        const string? name = "Test Brand";
        const string? slug = "test-brand";
        const int invalidDisplayOrder = 0;
        const string? description = "Test description";

        // Act
        Func<Brand> action = () =>
            new(name, description, slug, null, null, null, invalidDisplayOrder, null);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Given_ValidParameters_When_UpdatingBrandInformation_Then_ShouldUpdateSuccessfully()
    {
        // Arrange
        var brand = new Brand(
            "Original Name",
            "Original Description",
            "original-slug",
            "Original MetaTitle",
            "Original MetaDescription",
            "Original MetaKeywords",
            1,
            Guid.NewGuid()
        );

        const string? newName = "Updated Brand";
        const string? newSlug = "updated-brand";
        const int newDisplayOrder = 2;
        const string? newDescription = "Updated description";
        const string? newMetaTitle = "Updated Meta Title";
        const string? newMetaDescription = "Updated Meta Description";
        const string? newMetaKeywords = "Updated Meta Keywords";
        Guid? newThumbnailId = Guid.NewGuid();

        // Act
        brand.UpdateInformation(
            newName,
            newDescription,
            newSlug,
            newMetaTitle,
            newMetaDescription,
            newMetaKeywords,
            newDisplayOrder,
            newThumbnailId
        );

        // Assert
        brand.Name.Should().Be(newName);
        brand.Slug.Should().Be(newSlug);
        brand.DisplayOrder.Should().Be(newDisplayOrder);
        brand.Description.Should().Be(newDescription);
        brand.MetaTitle.Should().Be(newMetaTitle);
        brand.MetaDescription.Should().Be(newMetaDescription);
        brand.MetaKeywords.Should().Be(newMetaKeywords);
        brand.ThumbnailId.Should().Be(newThumbnailId);
    }

    [Fact]
    public void Given_ValidBrand_When_DeletingBrand_Then_ShouldMarkAsDeleted()
    {
        // Arrange
        var brand = new Brand(
            "Brand",
            "Description",
            "slug",
            "MetaTitle",
            "MetaDescription",
            "MetaKeywords",
            1,
            Guid.NewGuid()
        );

        // Act
        brand.Delete();

        // Assert
        brand.IsDeleted.Should().BeTrue();
    }

    [Fact]
    public void Given_EmptyName_When_CreatingBrand_Then_ShouldThrowArgumentException()
    {
        // Arrange
        string? invalidName = null;
        const string slug = "valid-slug";
        const int displayOrder = 1;

        // Act
        Func<Brand> action = () =>
            new(invalidName, "Description", slug, null, null, null, displayOrder, null);

        // Assert
        action.Should().Throw<ArgumentException>();
    }
}
