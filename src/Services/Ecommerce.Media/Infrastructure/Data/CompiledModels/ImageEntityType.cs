﻿// <auto-generated />
using System;
using System.Reflection;
using Ecommerce.Media.Domain;
using Ecommerce.SharedKernel.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

#pragma warning disable 219, 612, 618
#nullable disable

namespace Ecommerce.Media.Infrastructure.Data.CompiledModels
{
    internal partial class ImageEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Ecommerce.Media.Domain.Image",
                typeof(Image),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(Guid),
                propertyInfo: typeof(Entity<Guid>).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Entity<Guid>).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw,
                sentinel: new Guid("00000000-0000-0000-0000-000000000000"));
            id.TypeMapping = GuidTypeMapping.Default.Clone(
                comparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                keyComparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                providerValueComparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "uuid"));
            id.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            id.AddAnnotation("Relational:ColumnName", "id");
            id.AddAnnotation("Relational:DefaultValueSql", "uuid_generate_v4()");

            var caption = runtimeEntityType.AddProperty(
                "Caption",
                typeof(string),
                propertyInfo: typeof(Image).GetProperty("Caption", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Image).GetField("<Caption>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 1000);
            caption.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "character varying(1000)",
                    size: 1000));
            caption.TypeMapping = ((NpgsqlStringTypeMapping)caption.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
        caption.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        caption.AddAnnotation("Relational:ColumnName", "caption");

        var createdAt = runtimeEntityType.AddProperty(
            "CreatedAt",
            typeof(DateTime),
            propertyInfo: typeof(AuditableEntity<Guid>).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(AuditableEntity<Guid>).GetField("<CreatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            valueGenerated: ValueGenerated.OnAdd,
            sentinel: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        createdAt.TypeMapping = NpgsqlTimestampTzTypeMapping.Default.Clone(
            comparer: new ValueComparer<DateTime>(
                (DateTime v1, DateTime v2) => v1.Equals(v2),
                (DateTime v) => v.GetHashCode(),
                (DateTime v) => v),
            keyComparer: new ValueComparer<DateTime>(
                (DateTime v1, DateTime v2) => v1.Equals(v2),
                (DateTime v) => v.GetHashCode(),
                (DateTime v) => v),
            providerValueComparer: new ValueComparer<DateTime>(
                (DateTime v1, DateTime v2) => v1.Equals(v2),
                (DateTime v) => v.GetHashCode(),
                (DateTime v) => v));
        createdAt.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        createdAt.AddAnnotation("Relational:ColumnName", "created_at");
        createdAt.AddAnnotation("Relational:DefaultValue", new DateTime(2024, 10, 6, 14, 32, 38, 460, DateTimeKind.Utc).AddTicks(4391));

        var fileName = runtimeEntityType.AddProperty(
            "FileName",
            typeof(string),
            propertyInfo: typeof(Image).GetProperty("FileName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Image).GetField("<FileName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            maxLength: 50);
        fileName.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
            comparer: new ValueComparer<string>(
                (string v1, string v2) => v1 == v2,
                (string v) => v.GetHashCode(),
                (string v) => v),
            keyComparer: new ValueComparer<string>(
                (string v1, string v2) => v1 == v2,
                (string v) => v.GetHashCode(),
                (string v) => v),
            providerValueComparer: new ValueComparer<string>(
                (string v1, string v2) => v1 == v2,
                (string v) => v.GetHashCode(),
                (string v) => v),
            mappingInfo: new RelationalTypeMappingInfo(
                storeTypeName: "character varying(50)",
                size: 50));
        fileName.TypeMapping = ((NpgsqlStringTypeMapping)fileName.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
    fileName.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
    fileName.AddAnnotation("Relational:ColumnName", "file_name");

    var lastModifiedAt = runtimeEntityType.AddProperty(
        "LastModifiedAt",
        typeof(DateTime?),
        propertyInfo: typeof(AuditableEntity<Guid>).GetProperty("LastModifiedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        fieldInfo: typeof(AuditableEntity<Guid>).GetField("<LastModifiedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        nullable: true,
        valueGenerated: ValueGenerated.OnAdd);
    lastModifiedAt.TypeMapping = NpgsqlTimestampTzTypeMapping.Default.Clone(
        comparer: new ValueComparer<DateTime?>(
            (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
            (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
            (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
        keyComparer: new ValueComparer<DateTime?>(
            (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
            (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
            (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
        providerValueComparer: new ValueComparer<DateTime?>(
            (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
            (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
            (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)));
    lastModifiedAt.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
    lastModifiedAt.AddAnnotation("Relational:ColumnName", "last_modified_at");
    lastModifiedAt.AddAnnotation("Relational:DefaultValue", new DateTime(2024, 10, 6, 14, 32, 38, 461, DateTimeKind.Utc).AddTicks(7054));

    var type = runtimeEntityType.AddProperty(
        "Type",
        typeof(MediaType),
        propertyInfo: typeof(Image).GetProperty("Type", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        fieldInfo: typeof(Image).GetField("<Type>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
    type.TypeMapping = IntTypeMapping.Default.Clone(
        comparer: new ValueComparer<MediaType>(
            (MediaType v1, MediaType v2) => object.Equals((object)v1, (object)v2),
            (MediaType v) => v.GetHashCode(),
            (MediaType v) => v),
        keyComparer: new ValueComparer<MediaType>(
            (MediaType v1, MediaType v2) => object.Equals((object)v1, (object)v2),
            (MediaType v) => v.GetHashCode(),
            (MediaType v) => v),
        providerValueComparer: new ValueComparer<int>(
            (int v1, int v2) => v1 == v2,
            (int v) => v,
            (int v) => v),
        mappingInfo: new RelationalTypeMappingInfo(
            storeTypeName: "integer"),
        converter: new ValueConverter<MediaType, int>(
            (MediaType value) => (int)value,
            (int value) => (MediaType)value),
        jsonValueReaderWriter: new JsonConvertedValueReaderWriter<MediaType, int>(
            JsonInt32ReaderWriter.Instance,
            new ValueConverter<MediaType, int>(
                (MediaType value) => (int)value,
                (int value) => (MediaType)value)));
    type.SetSentinelFromProviderValue(0);
    type.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
    type.AddAnnotation("Relational:ColumnName", "type");

    var version = runtimeEntityType.AddProperty(
        "Version",
        typeof(Guid),
        propertyInfo: typeof(AuditableEntity<Guid>).GetProperty("Version", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        fieldInfo: typeof(AuditableEntity<Guid>).GetField("<Version>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        concurrencyToken: true,
        sentinel: new Guid("00000000-0000-0000-0000-000000000000"));
    version.TypeMapping = GuidTypeMapping.Default.Clone(
        comparer: new ValueComparer<Guid>(
            (Guid v1, Guid v2) => v1 == v2,
            (Guid v) => v.GetHashCode(),
            (Guid v) => v),
        keyComparer: new ValueComparer<Guid>(
            (Guid v1, Guid v2) => v1 == v2,
            (Guid v) => v.GetHashCode(),
            (Guid v) => v),
        providerValueComparer: new ValueComparer<Guid>(
            (Guid v1, Guid v2) => v1 == v2,
            (Guid v) => v.GetHashCode(),
            (Guid v) => v),
        mappingInfo: new RelationalTypeMappingInfo(
            storeTypeName: "uuid"));
    version.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
    version.AddAnnotation("Relational:ColumnName", "version");

    var key = runtimeEntityType.AddKey(
        new[] { id });
    runtimeEntityType.SetPrimaryKey(key);
    key.AddAnnotation("Relational:Name", "pk_images");

    return runtimeEntityType;
}

public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
{
    runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
    runtimeEntityType.AddAnnotation("Relational:Schema", null);
    runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
    runtimeEntityType.AddAnnotation("Relational:TableName", "images");
    runtimeEntityType.AddAnnotation("Relational:ViewName", null);
    runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

    Customize(runtimeEntityType);
}

static partial void Customize(RuntimeEntityType runtimeEntityType);
}
}