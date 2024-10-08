﻿// <auto-generated />
using System;
using System.Reflection;
using Ecommerce.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

#pragma warning disable 219, 612, 618
#nullable disable

namespace Ecommerce.Identity.Data.CompiledModels
{
    internal partial class ApplicationUserEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Ecommerce.Identity.Models.ApplicationUser",
                typeof(ApplicationUser),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(string),
                propertyInfo: typeof(IdentityUser<string>).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityUser<string>).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw);
            id.TypeMapping = StringTypeMapping.Default.Clone(
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
                    dbType: System.Data.DbType.String));
            id.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            id.AddAnnotation("Relational:ColumnName", "id");

            var accessFailedCount = runtimeEntityType.AddProperty(
                "AccessFailedCount",
                typeof(int),
                propertyInfo: typeof(IdentityUser<string>).GetProperty("AccessFailedCount", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityUser<string>).GetField("<AccessFailedCount>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0);
            accessFailedCount.TypeMapping = IntTypeMapping.Default.Clone(
                comparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                keyComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "integer"));
            accessFailedCount.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            accessFailedCount.AddAnnotation("Relational:ColumnName", "access_failed_count");

            var concurrencyStamp = runtimeEntityType.AddProperty(
                "ConcurrencyStamp",
                typeof(string),
                propertyInfo: typeof(IdentityUser<string>).GetProperty("ConcurrencyStamp", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityUser<string>).GetField("<ConcurrencyStamp>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                concurrencyToken: true);
            concurrencyStamp.TypeMapping = StringTypeMapping.Default.Clone(
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
                    dbType: System.Data.DbType.String));
            concurrencyStamp.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            concurrencyStamp.AddAnnotation("Relational:ColumnName", "concurrency_stamp");

            var email = runtimeEntityType.AddProperty(
                "Email",
                typeof(string),
                propertyInfo: typeof(IdentityUser<string>).GetProperty("Email", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityUser<string>).GetField("<Email>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 256);
            email.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
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
                    storeTypeName: "character varying(256)",
                    size: 256));
            email.TypeMapping = ((NpgsqlStringTypeMapping)email.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
        email.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        email.AddAnnotation("Relational:ColumnName", "email");

        var emailConfirmed = runtimeEntityType.AddProperty(
            "EmailConfirmed",
            typeof(bool),
            propertyInfo: typeof(IdentityUser<string>).GetProperty("EmailConfirmed", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(IdentityUser<string>).GetField("<EmailConfirmed>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            sentinel: false);
        emailConfirmed.TypeMapping = NpgsqlBoolTypeMapping.Default.Clone(
            comparer: new ValueComparer<bool>(
                (bool v1, bool v2) => v1 == v2,
                (bool v) => v.GetHashCode(),
                (bool v) => v),
            keyComparer: new ValueComparer<bool>(
                (bool v1, bool v2) => v1 == v2,
                (bool v) => v.GetHashCode(),
                (bool v) => v),
            providerValueComparer: new ValueComparer<bool>(
                (bool v1, bool v2) => v1 == v2,
                (bool v) => v.GetHashCode(),
                (bool v) => v));
        emailConfirmed.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        emailConfirmed.AddAnnotation("Relational:ColumnName", "email_confirmed");

        var firstName = runtimeEntityType.AddProperty(
            "FirstName",
            typeof(string),
            propertyInfo: typeof(ApplicationUser).GetProperty("FirstName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(ApplicationUser).GetField("<FirstName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            nullable: true);
        firstName.TypeMapping = StringTypeMapping.Default.Clone(
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
                dbType: System.Data.DbType.String));
        firstName.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        firstName.AddAnnotation("Relational:ColumnName", "first_name");

        var lastName = runtimeEntityType.AddProperty(
            "LastName",
            typeof(string),
            propertyInfo: typeof(ApplicationUser).GetProperty("LastName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(ApplicationUser).GetField("<LastName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            nullable: true);
        lastName.TypeMapping = StringTypeMapping.Default.Clone(
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
                dbType: System.Data.DbType.String));
        lastName.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        lastName.AddAnnotation("Relational:ColumnName", "last_name");

        var lockoutEnabled = runtimeEntityType.AddProperty(
            "LockoutEnabled",
            typeof(bool),
            propertyInfo: typeof(IdentityUser<string>).GetProperty("LockoutEnabled", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(IdentityUser<string>).GetField("<LockoutEnabled>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            sentinel: false);
        lockoutEnabled.TypeMapping = NpgsqlBoolTypeMapping.Default.Clone(
            comparer: new ValueComparer<bool>(
                (bool v1, bool v2) => v1 == v2,
                (bool v) => v.GetHashCode(),
                (bool v) => v),
            keyComparer: new ValueComparer<bool>(
                (bool v1, bool v2) => v1 == v2,
                (bool v) => v.GetHashCode(),
                (bool v) => v),
            providerValueComparer: new ValueComparer<bool>(
                (bool v1, bool v2) => v1 == v2,
                (bool v) => v.GetHashCode(),
                (bool v) => v));
        lockoutEnabled.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        lockoutEnabled.AddAnnotation("Relational:ColumnName", "lockout_enabled");

        var lockoutEnd = runtimeEntityType.AddProperty(
            "LockoutEnd",
            typeof(DateTimeOffset?),
            propertyInfo: typeof(IdentityUser<string>).GetProperty("LockoutEnd", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(IdentityUser<string>).GetField("<LockoutEnd>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            nullable: true);
        lockoutEnd.TypeMapping = NpgsqlTimestampTzTypeMapping.Default.Clone(
            comparer: new ValueComparer<DateTimeOffset?>(
                (Nullable<DateTimeOffset> v1, Nullable<DateTimeOffset> v2) => v1.HasValue && v2.HasValue && ((DateTimeOffset)v1).EqualsExact((DateTimeOffset)v2) || !v1.HasValue && !v2.HasValue,
                (Nullable<DateTimeOffset> v) => v.HasValue ? ((DateTimeOffset)v).GetHashCode() : 0,
                (Nullable<DateTimeOffset> v) => v.HasValue ? (Nullable<DateTimeOffset>)(DateTimeOffset)v : default(Nullable<DateTimeOffset>)),
            keyComparer: new ValueComparer<DateTimeOffset?>(
                (Nullable<DateTimeOffset> v1, Nullable<DateTimeOffset> v2) => v1.HasValue && v2.HasValue && ((DateTimeOffset)v1).EqualsExact((DateTimeOffset)v2) || !v1.HasValue && !v2.HasValue,
                (Nullable<DateTimeOffset> v) => v.HasValue ? ((DateTimeOffset)v).GetHashCode() : 0,
                (Nullable<DateTimeOffset> v) => v.HasValue ? (Nullable<DateTimeOffset>)(DateTimeOffset)v : default(Nullable<DateTimeOffset>)),
            providerValueComparer: new ValueComparer<DateTimeOffset?>(
                (Nullable<DateTimeOffset> v1, Nullable<DateTimeOffset> v2) => v1.HasValue && v2.HasValue && ((DateTimeOffset)v1).EqualsExact((DateTimeOffset)v2) || !v1.HasValue && !v2.HasValue,
                (Nullable<DateTimeOffset> v) => v.HasValue ? ((DateTimeOffset)v).GetHashCode() : 0,
                (Nullable<DateTimeOffset> v) => v.HasValue ? (Nullable<DateTimeOffset>)(DateTimeOffset)v : default(Nullable<DateTimeOffset>)),
            clrType: typeof(DateTimeOffset),
            jsonValueReaderWriter: new NpgsqlTimestampTzTypeMapping.NpgsqlJsonTimestampTzDateTimeOffsetReaderWriter());
        lockoutEnd.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        lockoutEnd.AddAnnotation("Relational:ColumnName", "lockout_end");

        var normalizedEmail = runtimeEntityType.AddProperty(
            "NormalizedEmail",
            typeof(string),
            propertyInfo: typeof(IdentityUser<string>).GetProperty("NormalizedEmail", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(IdentityUser<string>).GetField("<NormalizedEmail>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            nullable: true,
            maxLength: 256);
        normalizedEmail.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
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
                storeTypeName: "character varying(256)",
                size: 256));
        normalizedEmail.TypeMapping = ((NpgsqlStringTypeMapping)normalizedEmail.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
    normalizedEmail.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
    normalizedEmail.AddAnnotation("Relational:ColumnName", "normalized_email");

    var normalizedUserName = runtimeEntityType.AddProperty(
        "NormalizedUserName",
        typeof(string),
        propertyInfo: typeof(IdentityUser<string>).GetProperty("NormalizedUserName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        fieldInfo: typeof(IdentityUser<string>).GetField("<NormalizedUserName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        nullable: true,
        maxLength: 256);
    normalizedUserName.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
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
            storeTypeName: "character varying(256)",
            size: 256));
    normalizedUserName.TypeMapping = ((NpgsqlStringTypeMapping)normalizedUserName.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
normalizedUserName.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
normalizedUserName.AddAnnotation("Relational:ColumnName", "normalized_user_name");

var passwordHash = runtimeEntityType.AddProperty(
    "PasswordHash",
    typeof(string),
    propertyInfo: typeof(IdentityUser<string>).GetProperty("PasswordHash", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    fieldInfo: typeof(IdentityUser<string>).GetField("<PasswordHash>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    nullable: true);
passwordHash.TypeMapping = StringTypeMapping.Default.Clone(
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
        dbType: System.Data.DbType.String));
passwordHash.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
passwordHash.AddAnnotation("Relational:ColumnName", "password_hash");

var phoneNumber = runtimeEntityType.AddProperty(
    "PhoneNumber",
    typeof(string),
    propertyInfo: typeof(IdentityUser<string>).GetProperty("PhoneNumber", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    fieldInfo: typeof(IdentityUser<string>).GetField("<PhoneNumber>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    nullable: true);
phoneNumber.TypeMapping = StringTypeMapping.Default.Clone(
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
        dbType: System.Data.DbType.String));
phoneNumber.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
phoneNumber.AddAnnotation("Relational:ColumnName", "phone_number");

var phoneNumberConfirmed = runtimeEntityType.AddProperty(
    "PhoneNumberConfirmed",
    typeof(bool),
    propertyInfo: typeof(IdentityUser<string>).GetProperty("PhoneNumberConfirmed", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    fieldInfo: typeof(IdentityUser<string>).GetField("<PhoneNumberConfirmed>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    sentinel: false);
phoneNumberConfirmed.TypeMapping = NpgsqlBoolTypeMapping.Default.Clone(
    comparer: new ValueComparer<bool>(
        (bool v1, bool v2) => v1 == v2,
        (bool v) => v.GetHashCode(),
        (bool v) => v),
    keyComparer: new ValueComparer<bool>(
        (bool v1, bool v2) => v1 == v2,
        (bool v) => v.GetHashCode(),
        (bool v) => v),
    providerValueComparer: new ValueComparer<bool>(
        (bool v1, bool v2) => v1 == v2,
        (bool v) => v.GetHashCode(),
        (bool v) => v));
phoneNumberConfirmed.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
phoneNumberConfirmed.AddAnnotation("Relational:ColumnName", "phone_number_confirmed");

var securityStamp = runtimeEntityType.AddProperty(
    "SecurityStamp",
    typeof(string),
    propertyInfo: typeof(IdentityUser<string>).GetProperty("SecurityStamp", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    fieldInfo: typeof(IdentityUser<string>).GetField("<SecurityStamp>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    nullable: true);
securityStamp.TypeMapping = StringTypeMapping.Default.Clone(
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
        dbType: System.Data.DbType.String));
securityStamp.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
securityStamp.AddAnnotation("Relational:ColumnName", "security_stamp");

var twoFactorEnabled = runtimeEntityType.AddProperty(
    "TwoFactorEnabled",
    typeof(bool),
    propertyInfo: typeof(IdentityUser<string>).GetProperty("TwoFactorEnabled", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    fieldInfo: typeof(IdentityUser<string>).GetField("<TwoFactorEnabled>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    sentinel: false);
twoFactorEnabled.TypeMapping = NpgsqlBoolTypeMapping.Default.Clone(
    comparer: new ValueComparer<bool>(
        (bool v1, bool v2) => v1 == v2,
        (bool v) => v.GetHashCode(),
        (bool v) => v),
    keyComparer: new ValueComparer<bool>(
        (bool v1, bool v2) => v1 == v2,
        (bool v) => v.GetHashCode(),
        (bool v) => v),
    providerValueComparer: new ValueComparer<bool>(
        (bool v1, bool v2) => v1 == v2,
        (bool v) => v.GetHashCode(),
        (bool v) => v));
twoFactorEnabled.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
twoFactorEnabled.AddAnnotation("Relational:ColumnName", "two_factor_enabled");

var userName = runtimeEntityType.AddProperty(
    "UserName",
    typeof(string),
    propertyInfo: typeof(IdentityUser<string>).GetProperty("UserName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    fieldInfo: typeof(IdentityUser<string>).GetField("<UserName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    nullable: true,
    maxLength: 256);
userName.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
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
        storeTypeName: "character varying(256)",
        size: 256));
userName.TypeMapping = ((NpgsqlStringTypeMapping)userName.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
userName.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
userName.AddAnnotation("Relational:ColumnName", "user_name");

var key = runtimeEntityType.AddKey(
    new[] { id });
runtimeEntityType.SetPrimaryKey(key);
key.AddAnnotation("Relational:Name", "pk_asp_net_users");

var index = runtimeEntityType.AddIndex(
    new[] { normalizedEmail });
index.AddAnnotation("Relational:Name", "EmailIndex");

var index0 = runtimeEntityType.AddIndex(
    new[] { normalizedUserName },
    unique: true);
index0.AddAnnotation("Relational:Name", "UserNameIndex");

return runtimeEntityType;
}

public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
{
    runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
    runtimeEntityType.AddAnnotation("Relational:Schema", null);
    runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
    runtimeEntityType.AddAnnotation("Relational:TableName", "AspNetUsers");
    runtimeEntityType.AddAnnotation("Relational:ViewName", null);
    runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

    Customize(runtimeEntityType);
}

static partial void Customize(RuntimeEntityType runtimeEntityType);
}
}
