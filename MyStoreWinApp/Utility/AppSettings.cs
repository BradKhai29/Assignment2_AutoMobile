using BusinessObject;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public sealed class AppSettings
{
    #region Singleton_Implementation
    private static AppSettings _instance;
    private static readonly object _instanceLock = new object();
    public static AppSettings Instance
    {
        get
        {
            lock (_instanceLock)
            {
                return _instance ??= new AppSettings();
            }
        }
    }
    #endregion

    #region Config Variable
    private readonly string JsonFile = "appsettings.json";
    private readonly string connectionName = "Default";
    private readonly string DatabaseName = "Assignment2_AutoMobile";
    #endregion

    #region Property
    public string ConnectionString { get; private set; }
    public Member Admin { get; set; }
    #endregion

    private AppSettings()
    {
        DirectoryHelper.SetDirectory();
        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(path: JsonFile);

        IConfigurationRoot configRoot = configBuilder.Build();
        
        ConnectionString = GetConnectionString(configRoot);
        Admin = GetAdminAccount(configRoot);
    }

    private string GetConnectionString(IConfigurationRoot configurationRoot)
    {
        // Get connectionString and modify the DatabaseName
        return configurationRoot.GetConnectionString(name: connectionName)
                                .Replace(oldValue: "[DatabaseName]", newValue: DatabaseName);
    }

    private Member GetAdminAccount(IConfigurationRoot configurationRoot)
    {
        string MemberId = configurationRoot.GetSection(nameof(Admin))["MemberId"];
        string Email = configurationRoot.GetSection(nameof(Admin))["Email"];
        string Password = configurationRoot.GetSection(nameof(Admin))["Password"];

        var account = new Member { MemberId = int.Parse(MemberId), Password = Password, Email = Email };
        return account;
    }
}
