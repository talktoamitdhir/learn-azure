namespace Core.Config
{
    public static class PlatformConfigurationConstants
    {
        public const string DATABASE_NAME = "ABC";

        public const string KEYVAULT_ENDPOINT_URL = "https://dummyproject-keyvault.vault.azure.net/";

        public const string DOCUMENT_DB_END_POINT = "documentDBEndPoint";
        public const string DOCUMENT_DB_ENDPOINT_KEYVAULT_KEY = "documentDBKey";
        public const string DOCUMENT_DB_CONNECTION_STRING = "documentDBConnectionString";
        // public const string DOCUMENT_DB_NAME = "documentDB-name";

        public const string SERVICEBUS_END_POINT = "";
        public const string SERVICEBUS_ENDPOINT_KEYVAULT_KEY = "";
        public const string SERVICEBUS_CONNECTION_STRING = "ServiceBusConnectionString";
        public const string SERVICEBUS_QUEUE_NAME_ORDERS = "orders";
        public const byte SERVICEBUS_QUEUE_NO_OF_MESSAGES = 10;

        // public const string QUEUE_NAME = "dummyprojectqueue";
    }
}
