using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.UnitTests.Domain;

public sealed class VariantAggregateTests
{
    [Fact]
    public void Given_ValidParameters_When_CreatingVariant_Then_ShouldCreateVariantSuccessfully()
    {
        // Arrange
        const string name = "Color";
        const VariantType type = VariantType.Color;

        // Act
        var variant = new Variant(name, type);

        // Assert
        variant.Name.Should().Be(name);
        variant.Type.Should().Be(type);
        variant.IsDeleted.Should().BeFalse();
    }

    [Fact]
    public void Given_InvalidName_When_CreatingVariant_Then_ShouldThrowArgumentException()
    {
        // Arrange
        string? invalidName = null;
        const VariantType type = VariantType.Ram;

        // Act
        Func<Variant> action = () => new(invalidName, type);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Given_InvalidVariantType_When_CreatingVariant_Then_ShouldThrowArgumentException()
    {
        // Arrange
        const string name = "Color";
        const VariantType invalidType = (VariantType)999;

        // Act
        Func<Variant> action = () => new Variant(name, invalidType);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Given_ValidVariant_When_DeletingVariant_Then_ShouldMarkAsDeleted()
    {
        // Arrange
        var variant = new Variant("Color", VariantType.Color);

        // Act
        variant.Delete();

        // Assert
        variant.IsDeleted.Should().BeTrue();
    }

    [Fact]
    public void Given_ValidParameters_When_UpdatingVariant_Then_ShouldUpdateSuccessfully()
    {
        // Arrange
        var variant = new Variant("Color", VariantType.Color);
        const string newName = "Size";
        const VariantType newType = VariantType.Ram;

        // Act
        variant.Update(newName, newType);

        // Assert
        variant.Name.Should().Be(newName);
        variant.Type.Should().Be(newType);
    }

    [Fact]
    public void Given_EmptyName_When_UpdatingVariant_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var variant = new Variant("Color", VariantType.Color);
        string? invalidName = null;
        const VariantType type = VariantType.Ram;

        // Act
        Action action = () => variant.Update(invalidName, type);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Given_InvalidType_When_UpdatingVariant_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var variant = new Variant("Color", VariantType.Color);
        const string newName = "Size";
        const VariantType invalidType = (VariantType)999;

        // Act
        Action action = () => variant.Update(newName, invalidType);

        // Assert
        action.Should().Throw<ArgumentException>();
    }
}
