var builder = DistributedApplication.CreateBuilder(args);

var launchProfileName = builder.Configuration["DOTNET_LAUNCH_PROFILE"] ?? "http";

var postgresUser = builder.AddParameter("postgres-user", true);
var postgresPassword = builder.AddParameter("postgres-password", true);

// Components
var postgres = builder
    .AddPostgres("postgres", postgresUser, postgresPassword, 5432)
    .WithPgAdmin()
    .WithDataBindMount("../../../mnt/postgres");

var redis = builder
    .AddRedis(ServiceName.Redis, 6379)
    .WithRedisCommander()
    .WithDataBindMount("../../../mnt/redis");

var mongodb = builder
    .AddMongoDB("mongodb", 27017)
    .WithMongoExpress()
    .WithDataBindMount("../../../mnt/mongodb");

var storage = builder.AddAzureStorage("storage");

if (builder.Environment.IsDevelopment())
{
    storage.RunAsEmulator(config => config.WithDataBindMount("../../../mnt/azurite"));
}

var blobs = storage.AddBlobs(ServiceName.Blob);
var smtpServer = builder.AddMailDev(ServiceName.Mail, 1080);
var rabbitMq = builder.AddRabbitMQ("event-bus").WithManagementPlugin();

// Databases
var catalogDb = postgres.AddDatabase(ServiceName.Database.Catalog);
var identityDb = postgres.AddDatabase(ServiceName.Database.Identity);
var mediaDb = postgres.AddDatabase(ServiceName.Database.Media);
var inventoryDb = postgres.AddDatabase(ServiceName.Database.Inventory);
var customerDb = postgres.AddDatabase(ServiceName.Database.Customer);
var emailDb = mongodb.AddDatabase(ServiceName.Database.Notification);
var orderDb = postgres.AddDatabase(ServiceName.Database.Order);
var promotionDb = postgres.AddDatabase(ServiceName.Database.Promotion);
var ratingDb = mongodb.AddDatabase(ServiceName.Database.Rating);
var taxDb = postgres.AddDatabase(ServiceName.Database.Tax);
var webhookDb = postgres.AddDatabase(ServiceName.Database.Webhook);
var locationDb = postgres.AddDatabase(ServiceName.Database.Location);

// Services
var identityApi = builder
    .AddProject<Ecommerce_Identity>("identity-api")
    .WithReference(identityDb)
    .WithReference(redis)
    .WithExternalHttpEndpoints();

var identityEndpoint = identityApi.GetEndpoint(launchProfileName);

var catalogApi = builder
    .AddProject<Ecommerce_Catalog>("catalog-api")
    .WithReference(catalogDb)
    .WithReference(rabbitMq)
    .WithEnvironment("Identity__Url", identityEndpoint);

var mediaApi = builder
    .AddProject<Ecommerce_Media>("media-api")
    .WithReference(mediaDb)
    .WithReference(blobs)
    .WithReference(rabbitMq)
    .WithEnvironment("Identity__Url", identityEndpoint);

var inventoryApi = builder
    .AddProject<Ecommerce_Inventory>("inventory-api")
    .WithReference(inventoryDb)
    .WithReference(rabbitMq)
    .WithEnvironment("Identity__Url", identityEndpoint);

var basketApi = builder
    .AddProject<Ecommerce_Basket>("basket-api")
    .WithReference(redis)
    .WithReference(rabbitMq)
    .WithEnvironment("Identity__Url", identityEndpoint);

var customerApi = builder
    .AddProject<Ecommerce_Customer>("customer-api")
    .WithReference(customerDb)
    .WithReference(rabbitMq)
    .WithEnvironment("Identity__Url", identityEndpoint);

var emailApi = builder
    .AddProject<Ecommerce_Notification>("email-api")
    .WithReference(emailDb)
    .WithReference(rabbitMq)
    .WithReference(smtpServer);

var orderApi = builder
    .AddProject<Ecommerce_Order>("order-api")
    .WithReference(orderDb)
    .WithReference(rabbitMq)
    .WithEnvironment("Identity__Url", identityEndpoint);

var promotionApi = builder
    .AddProject<Ecommerce_Promotion>("promotion-api")
    .WithReference(promotionDb)
    .WithReference(rabbitMq)
    .WithEnvironment("Identity__Url", identityEndpoint);

var ratingApi = builder
    .AddProject<Ecommerce_Rating>("rating-api")
    .WithReference(ratingDb)
    .WithReference(rabbitMq)
    .WithEnvironment("Identity__Url", identityEndpoint);

var taxApi = builder
    .AddProject<Ecommerce_Tax>("tax-api")
    .WithReference(taxDb)
    .WithEnvironment("Identity__Url", identityEndpoint);

var webhookApi = builder
    .AddProject<Ecommerce_Webhook>("webhook-api")
    .WithReference(webhookDb)
    .WithReference(rabbitMq)
    .WithEnvironment("Identity__Url", identityEndpoint);

var locationApi = builder
    .AddProject<Ecommerce_Location>("location-api")
    .WithReference(locationDb)
    .WithEnvironment("Identity__Url", identityEndpoint);

// Bff
var userBff = builder
    .AddProject<Ecommerce_Bff_StoreFront>("user-bff")
    .WithEnvironment("BFF__Authority", identityEndpoint)
    .WithExternalHttpEndpoints();

var userBffEndpoint = userBff.GetEndpoint("http");

var adminBff = builder
    .AddProject<Ecommerce_Bff_BackOffice>("admin-bff")
    .WithEnvironment("BFF__Authority", identityEndpoint)
    .WithExternalHttpEndpoints();

var adminBffEndpoint = adminBff.GetEndpoint("http");

// Clients
var storeFront = builder
    .AddProject<Ecommerce_StoreFront>("store-front")
    .WithEnvironment("ApiGateway__Url", userBffEndpoint)
    .WithExternalHttpEndpoints();

var backOffice = builder
    .AddProject<Ecommerce_BackOffice>("back-office")
    .WithEnvironment("ApiGateway__Url", adminBffEndpoint)
    .WithExternalHttpEndpoints();

var webhookClient = builder
    .AddProject<Ecommerce_WebhookClient>("webhook-client")
    .WithReference(webhookApi)
    .WithEnvironment("IdentityUrl", identityEndpoint);

// Health Checks
builder
    .AddHealthChecksUi("healthchecksui")
    .WithReference(catalogApi)
    .WithReference(identityApi)
    .WithReference(mediaApi)
    .WithReference(inventoryApi)
    .WithReference(basketApi)
    .WithReference(customerApi)
    .WithReference(emailApi)
    .WithReference(orderApi)
    .WithReference(promotionApi)
    .WithReference(ratingApi)
    .WithReference(taxApi)
    .WithReference(userBff)
    .WithReference(adminBff)
    .WithReference(storeFront)
    .WithReference(backOffice)
    .WithReference(webhookApi)
    .WithReference(webhookClient)
    .WithReference(locationApi)
    .WithExternalHttpEndpoints();

identityApi
    .WithEnvironment("Clients__Catalog", catalogApi.GetEndpoint(launchProfileName))
    .WithEnvironment("Clients__Media", mediaApi.GetEndpoint(launchProfileName))
    .WithEnvironment("Clients__Inventory", inventoryApi.GetEndpoint(launchProfileName))
    .WithEnvironment("Clients__Basket", basketApi.GetEndpoint(launchProfileName))
    .WithEnvironment("Clients__Customer", customerApi.GetEndpoint(launchProfileName))
    .WithEnvironment("Clients__Order", orderApi.GetEndpoint(launchProfileName))
    .WithEnvironment("Clients__Promotion", promotionApi.GetEndpoint(launchProfileName))
    .WithEnvironment("Clients__Rating", ratingApi.GetEndpoint(launchProfileName))
    .WithEnvironment("Clients__Tax", taxApi.GetEndpoint(launchProfileName))
    .WithEnvironment("Clients__Location", locationApi.GetEndpoint(launchProfileName))
    .WithEnvironment("Clients__StoreFront", userBffEndpoint)
    .WithEnvironment("Clients__BackOffice", adminBffEndpoint)
    .WithEnvironment("Clients__Webhook", webhookApi.GetEndpoint(launchProfileName))
    .WithEnvironment("Clients__WebhookClient", webhookClient.GetEndpoint(launchProfileName));

builder.Build().Run();
