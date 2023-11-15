using Microsoft.Extensions.Configuration;

namespace R5._08.Project.Database
{
    public class ConnectionString
    {
        public static string GetConnectionString()
        {
            IConfigurationBuilder v_Builder = new ConfigurationBuilder()
                .AddUserSecrets<ConnectionString>();

            IConfigurationRoot v_Configuration = v_Builder.Build();

            string v_ConnectionString = v_Configuration["ConnectionString"]
                ?? throw new NotImplementedException("You must enter the connection string");

            return v_ConnectionString;
        }
    }
}
