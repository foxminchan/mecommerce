namespace Ecommerce.Constant;

public static class ServiceName
{
    public static class Database
    {
        public const string Catalog = "catalog-db";
        public const string Identity = "identity-db";
        public const string Media = "media-db";
        public const string Inventory = "inventory-db";
        public const string Customer = "customer-db";
        public const string Notification = "notification-db";
        public const string Order = "order-db";
        public const string Promotion = "promotion-db";
        public const string Rating = "rating-db";
        public const string Tax = "tax-db";
        public const string Webhook = "webhook-db";
        public const string Location = "location-db";
        public const string Shipment = "shipment-db";
        public const string Payment = "payment-db";
    }

    public const string Redis = "redis";
    public const string Blob = "blob";
    public const string Mail = "mail";
}
