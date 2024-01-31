using CoreLayer.Entity.ViewModel.FtpHelper;
using Microsoft.Extensions.Configuration;

namespace CoreLayer.Helper
{
    public class ConfigurationHelper
    {
        private readonly static string _privateProjectKey = "f27c9b94069f47fbabbeee9e8caa5b0f";
        #region Constructor
        private static IConfigurationRoot _configurationRoot;
        private static IConfigurationRoot configurationRoot
        {
            get
            {
                if (_configurationRoot is null)
                    _configurationRoot = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .Build();

                return _configurationRoot;
            }
        }
        #endregion

        #region GetSqlConnectionString
        public static String GetSqlConnectionString()
        {
            return EncryptionHelper.DecryptPassword(configurationRoot.GetConnectionString("SqlServerConnectionString"),
                                                    _privateProjectKey);
        }

        public static String GetSqlConnectionType()
        {
            return configurationRoot.GetSection("SqlConnectionType").Get<string>();
        }
        public static String GetLogConnectionString()
        {


            string connectionString;

            var SQL_CONNECTION_STRING = Environment.GetEnvironmentVariable("SQLLOG_CONNECTION_STRING");
            if (!String.IsNullOrEmpty(SQL_CONNECTION_STRING))
                connectionString = SQL_CONNECTION_STRING;
            else
                connectionString = configurationRoot.GetConnectionString("LogConnectionString");

            return connectionString;
        }
        #endregion

        #region GetTcmbExchangeUrl
        public static string GetTcmbExchangeUrl()
        {
            return configurationRoot.GetSection("TcmbExchangeUrl").Get<string>();
        }
        #endregion

        #region GetSecurityKey
        public static string GetSecurityKey()
        {
            return configurationRoot.GetSection("EncryptKey").Get<string>();
        }
        #endregion

        #region GetFtpSettings
        public static FtpSettingViewModel GetFtpSettings()
        {
            return configurationRoot.GetSection("FtpSettings").Get<FtpSettingViewModel>();
        }
        #endregion

    }
}
