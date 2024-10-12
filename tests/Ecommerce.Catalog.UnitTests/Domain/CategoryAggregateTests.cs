using Ecommerce.Catalog.Domain.CategoryAggregate;

namespace Ecommerce.Catalog.UnitTests.Domain;

public sealed class CategoryAggregateTests
{
    [Fact]
    public void Given_ValidParameters_When_CreatingCategory_Then_ShouldCreateCategorySuccessfully()
    {
        // Arrange (Given)
        const string name = "Test Category";
        const string slug = "test-category";
        const int displayOrder = 1;
        const bool isPublished = true;
        const string? description = "Test description";
        const string? metaTitle = "Meta Title";
        const string? metaDescription = "Meta Description";
        const string? metaKeywords = "Meta Keywords";
        Guid? thumbnailId = Guid.NewGuid();
        long? parentId = null;

        // Act
        var category = new Category(
            name,
            description,
            slug,
            metaTitle,
            metaDescription,
            isPublished,
            metaKeywords,
            displayOrder,
            thumbnailId,
            parentId
        );

        // Assert
        category.Name.Should().Be(name);
        category.Slug.Should().Be(slug);
        category.DisplayOrder.Should().Be(displayOrder);
        category.Description.Should().Be(description);
        category.MetaTitle.Should().Be(metaTitle);
        category.MetaDescription.Should().Be(metaDescription);
        category.MetaKeywords.Should().Be(metaKeywords);
        category.ThumbnailId.Should().Be(thumbnailId);
        category.ParentId.Should().Be(parentId);
        category.IsPublished.Should().Be(isPublished);
        category.ProductCategories.Should().BeEmpty();
        category.Children.Should().BeEmpty();
        category.IsDeleted.Should().BeFalse();
    }

    [Fact]
    public void Given_InvalidDisplayOrder_When_CreatingCategory_Then_ShouldThrowArgumentException()
    {
        // Arrange
        const string name = "Test Category";
        const string slug = "test-category";
        const int invalidDisplayOrder = 0;
        const bool isPublished = true;

        // Act
        Func<Category> action = () =>
            new(name, null, slug, null, null, isPublished, null, invalidDisplayOrder, null, null);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Given_ValidParameters_When_UpdatingCategoryInformation_Then_ShouldUpdateSuccessfully()
    {
        // Arrange
        var category = new Category(
            "Original Name",
            "Original Description",
            "original-slug",
            "Original MetaTitle",
            "Original MetaDescription",
            true,
            "Original MetaKeywords",
            1,
            Guid.NewGuid(),
            null
        );

        const string newName = "Updated Category";
        const string newSlug = "updated-category";
        const int newDisplayOrder = 2;
        const bool newIsPublished = false;
        const string? newDescription = "Updated description";
        const string? newMetaTitle = "Updated Meta Title";
        const string? newMetaDescription = "Updated Meta Description";
        const string? newMetaKeywords = "Updated Meta Keywords";
        Guid? newThumbnailId = Guid.NewGuid();
        long? newParentId = 123;

        // Act
        category.UpdateInformation(
            newName,
            newDescription,
            newSlug,
            newMetaTitle,
            newMetaDescription,
            newIsPublished,
            newMetaKeywords,
            newDisplayOrder,
            newThumbnailId,
            newParentId
        );

        // Assert
        category.Name.Should().Be(newName);
        category.Slug.Should().Be(newSlug);
        category.DisplayOrder.Should().Be(newDisplayOrder);
        category.Description.Should().Be(newDescription);
        category.MetaTitle.Should().Be(newMetaTitle);
        category.MetaDescription.Should().Be(newMetaDescription);
        category.MetaKeywords.Should().Be(newMetaKeywords);
        category.ThumbnailId.Should().Be(newThumbnailId);
        category.ParentId.Should().Be(newParentId);
        category.IsPublished.Should().Be(newIsPublished);
    }

    [Fact]
    public void Given_ValidCategory_When_DeletingCategory_Then_ShouldMarkAsDeleted()
    {
        // Arrange
        var category = new Category(
            "Category",
            "Description",
            "slug",
            "MetaTitle",
            "MetaDescription",
            true,
            "MetaKeywords",
            1,
            Guid.NewGuid(),
            null
        );

        // Act
        category.Delete();

        // Assert
        category.IsDeleted.Should().BeTrue();
    }

    [Fact]
    public void Given_EmptyName_When_CreatingCategory_Then_ShouldThrowArgumentException()
    {
        // Arrange (Given)
        string? invalidName = null;
        const string slug = "valid-slug";
        const int displayOrder = 1;
        const bool isPublished = true;

        // Act
        Func<Category> action = () =>
            new(invalidName, null, slug, null, null, isPublished, null, displayOrder, null, null);

        // Assert
        action.Should().Throw<ArgumentException>();
    }
}
