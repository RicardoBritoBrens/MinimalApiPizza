namespace PirzzaApi.Core
{
    public static class Constants
    {
        public const string PIZZAS_FIND_ALL_PATH = "/pizzas";
        public const string PIZZAS_FIND_BY_ID = "/pizzas/{id}";
        public const string PIZZAS_CREATE_PATH = "/pizzas";
        public const string PIZZAS_UPDATE_PATH = "/pizzas/{id}";
        public const string PIZZAS_DELETE_PATH = "/pizzas/{id}";


        public const string DATABASE_CONFIGURATION_KEY = "Pizzas";
        public const string CONNECTION_STRING_NAME = "Data Source=Pizzas.db";


        public const string SWAGGER_JSON_PATH = "/swagger/v1/swagger.json";
        public const string SEAGGER_API_DESCRIPTION = "PizzaStore API V1";

        

    }
}