using Ecommerce.Catalog.Domain.BrandAggregate;
using Ecommerce.Catalog.Domain.CategoryAggregate;
using Ecommerce.Catalog.Domain.ProductAttributeAggregate;
using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;
using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Infrastructure;

public sealed class CatalogContextSeed : IDbSeeder<CatalogContext>
{
    public async Task SeedAsync(CatalogContext context)
    {
        if (!context.Categories.Any())
        {
            await context.Categories.AddRangeAsync(GetPreconfiguredCategories());
            await context.SaveChangesAsync();
        }

        if (!context.Brands.Any())
        {
            await context.Brands.AddRangeAsync(GetPreconfiguredBrands());
            await context.SaveChangesAsync();
        }

        if (!context.Variants.Any())
        {
            await context.Variants.AddRangeAsync(GetPreconfiguredVariants());
            await context.SaveChangesAsync();
        }

        if (!context.ProductAttributeGroups.Any())
        {
            await context.ProductAttributeGroups.AddRangeAsync(GetPreconfiguredAttributeGroups());
            await context.SaveChangesAsync();
        }

        if (!context.ProductAttributes.Any())
        {
            var attributeGroups = await context.ProductAttributeGroups.ToListAsync();
            await context.ProductAttributes.AddRangeAsync(
                GetPreconfiguredAttributes(attributeGroups)
            );
            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<Category> GetPreconfiguredCategories()
    {
        yield return new(
            "Smartphones",
            "Latest smartphones from top brands",
            "smartphones",
            "Smartphones",
            "Shop the latest smartphones from Apple, Samsung, and more.",
            true,
            "smartphones, mobile phones, latest smartphones",
            1,
            null,
            null
        );

        yield return new(
            "Accessories",
            "Mobile phone accessories including cases, chargers, and more.",
            "accessories",
            "Phone Accessories",
            "Find a wide range of accessories for your mobile phone.",
            true,
            "phone accessories, chargers, phone cases",
            2,
            null,
            null
        );

        yield return new(
            "Tablets",
            "High-performance tablets for work and entertainment.",
            "tablets",
            "Tablets",
            "Explore a wide range of tablets from Apple, Samsung, and more.",
            true,
            "tablets, ipad, android tablets",
            3,
            null,
            null
        );

        yield return new(
            "Wearables",
            "Smartwatches and fitness trackers from top brands.",
            "wearables",
            "Wearables",
            "Discover the latest smartwatches and fitness trackers.",
            true,
            "smartwatches, fitness trackers, wearables",
            4,
            null,
            null
        );

        yield return new(
            "Gaming Phones",
            "High-performance gaming phones with advanced features.",
            "gaming-phones",
            "Gaming Phones",
            "Shop the best gaming phones for an immersive experience.",
            true,
            "gaming phones, high-performance phones",
            5,
            null,
            null
        );

        yield return new(
            "Pre-owned Phones",
            "Quality pre-owned smartphones at affordable prices.",
            "pre-owned-phones",
            "Pre-owned Phones",
            "Explore our range of pre-owned smartphones.",
            true,
            "pre-owned phones, second-hand phones",
            6,
            null,
            null
        );
    }

    private static IEnumerable<Brand> GetPreconfiguredBrands()
    {
        yield return new(
            "Apple",
            "Leading brand known for iPhones, iPads, and MacBooks.",
            "apple",
            "Apple",
            "Explore the latest products from Apple, including iPhones, iPads, and MacBooks.",
            "apple, iphones, ipads, macbooks",
            1,
            null
        );

        yield return new(
            "Samsung",
            "Top brand offering a wide range of smartphones, tablets, and wearables.",
            "samsung",
            "Samsung",
            "Discover the latest smartphones, tablets, and wearables from Samsung.",
            "samsung, smartphones, tablets, wearables",
            2,
            null
        );

        yield return new(
            "Xiaomi",
            "Innovative brand known for high-quality yet affordable smartphones.",
            "xiaomi",
            "Xiaomi",
            "Shop for high-quality smartphones and gadgets from Xiaomi at affordable prices.",
            "xiaomi, affordable smartphones, gadgets",
            3,
            null
        );

        yield return new(
            "OnePlus",
            "Premium brand offering high-performance smartphones with a focus on user experience.",
            "oneplus",
            "OnePlus",
            "Check out the latest high-performance smartphones from OnePlus.",
            "oneplus, high-performance smartphones",
            4,
            null
        );

        yield return new(
            "Sony",
            "Renowned brand known for its high-quality electronics and smartphones.",
            "sony",
            "Sony",
            "Explore Sony's range of high-quality electronics and smartphones.",
            "sony, electronics, high-quality smartphones",
            5,
            null
        );

        yield return new(
            "Huawei",
            "Global brand offering a variety of smartphones and technology solutions.",
            "huawei",
            "Huawei",
            "Discover advanced smartphones and technology solutions from Huawei.",
            "huawei, smartphones, technology solutions",
            6,
            null
        );
    }

    private static IEnumerable<Variant> GetPreconfiguredVariants()
    {
        yield return new("32GB", VariantType.Storage);
        yield return new("64GB", VariantType.Storage);
        yield return new("128GB", VariantType.Storage);
        yield return new("256GB", VariantType.Storage);
        yield return new("512GB", VariantType.Storage);
        yield return new("8GB", VariantType.Ram);
        yield return new("12GB RAM", VariantType.Ram);
        yield return new("16GB RAM", VariantType.Ram);
        yield return new("Black", VariantType.Color);
        yield return new("White", VariantType.Color);
        yield return new("Gold", VariantType.Color);
    }

    private static IEnumerable<ProductAttributeGroup> GetPreconfiguredAttributeGroups()
    {
        yield return new("Display");
        yield return new("Memory");
        yield return new("Camera");
        yield return new("Body");
        yield return new("Battery");
        yield return new("Platform");
        yield return new("Miscellaneous");
        yield return new("Sound");
        yield return new("Cellular");
        yield return new("Connectivity & Features");
    }

    private static IEnumerable<ProductAttribute> GetPreconfiguredAttributes(
        List<ProductAttributeGroup> attributeGroups
    )
    {
        var displayGroup = attributeGroups.First(x => x.Name == "Display");

        List<ProductAttribute> displayAttributes =
        [
            new("Size", displayGroup.Id),
            new("Resolution", displayGroup.Id),
            new("Refresh Rate", displayGroup.Id),
            new("Technology", displayGroup.Id),
            new("Features", displayGroup.Id),
        ];

        // Seed memory attributes
        var memoryGroup = attributeGroups.First(x => x.Name == "Memory");

        List<ProductAttribute> memoryAttributes =
        [
            new("RAM", memoryGroup.Id),
            new("Internal Storage", memoryGroup.Id),
            new("Expandable Storage", memoryGroup.Id),
        ];

        // Seed camera attributes
        var cameraGroup = attributeGroups.First(x => x.Name == "Camera");

        List<ProductAttribute> cameraAttributes =
        [
            new("Rear", cameraGroup.Id),
            new("Main camera", cameraGroup.Id),
            new("Selfie camera", cameraGroup.Id),
        ];

        // Seed body attributes
        var bodyGroup = attributeGroups.First(x => x.Name == "Body");

        List<ProductAttribute> bodyAttributes =
        [
            new("Dimensions", bodyGroup.Id),
            new("Weight", bodyGroup.Id),
            new("Build", bodyGroup.Id),
            new("SIM", bodyGroup.Id),
        ];

        // Seed battery attributes
        var batteryGroup = attributeGroups.First(x => x.Name == "Battery");

        List<ProductAttribute> batteryAttributes =
        [
            new("Type", batteryGroup.Id),
            new("Capacity", batteryGroup.Id),
            new("Charging", batteryGroup.Id),
        ];

        // Seed platform attributes
        var platformGroup = attributeGroups.First(x => x.Name == "Platform");

        List<ProductAttribute> platformAttributes =
        [
            new("OS", platformGroup.Id),
            new("Chipset", platformGroup.Id),
            new("GPU", platformGroup.Id),
        ];

        // Seed miscellaneous attributes
        var miscellaneousGroup = attributeGroups.First(x => x.Name == "Miscellaneous");

        List<ProductAttribute> miscellaneousAttributes =
        [
            new("Sensors", miscellaneousGroup.Id),
            new("Features", miscellaneousGroup.Id),
            new("Colors", miscellaneousGroup.Id),
        ];

        // Seed sound attributes
        var soundGroup = attributeGroups.First(x => x.Name == "Sound");

        List<ProductAttribute> soundAttributes =
        [
            new("Loudspeaker", soundGroup.Id),
            new("3.5mm jack", soundGroup.Id),
        ];

        // Seed cellular attributes
        var cellularGroup = attributeGroups.First(x => x.Name == "Cellular");

        List<ProductAttribute> cellularAttributes =
        [
            new("Technology", cellularGroup.Id),
            new("Speed", cellularGroup.Id),
            new("GPRS", cellularGroup.Id),
            new("EDGE", cellularGroup.Id),
            new("3G", cellularGroup.Id),
            new("4G", cellularGroup.Id),
            new("5G", cellularGroup.Id),
        ];

        // Seed connectivity & features attributes
        var connectivityGroup = attributeGroups.First(x => x.Name == "Connectivity & Features");

        List<ProductAttribute> connectivityAttributes =
        [
            new("WLAN", connectivityGroup.Id),
            new("Bluetooth", connectivityGroup.Id),
            new("GPS", connectivityGroup.Id),
            new("NFC", connectivityGroup.Id),
            new("Radio", connectivityGroup.Id),
            new("USB", connectivityGroup.Id),
        ];

        return displayAttributes
            .Concat(memoryAttributes)
            .Concat(cameraAttributes)
            .Concat(bodyAttributes)
            .Concat(batteryAttributes)
            .Concat(platformAttributes)
            .Concat(miscellaneousAttributes)
            .Concat(soundAttributes)
            .Concat(cellularAttributes)
            .Concat(connectivityAttributes);
    }
}
