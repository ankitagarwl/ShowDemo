

using System;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for Connection
/// </summary>
public class Connection
{
    #region Connection
    public Connection()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion

    #region AppSettings
    /// <summary>
    /// AppSettings gets key as parameter and gets its value 
    /// from web config APPSETTINGS Section
    /// </summary>
    /// <param name="key">Appsettings key for which value is fetched from web config</param>
    /// <returns>returns the exact value corresponfing to the key supplied</returns>
    public static string AppSettings(string key)
    {
        return System.Configuration.ConfigurationManager.AppSettings[key].ToString();
    }
    #endregion

    #region connnectionString
    /// <summary>
    /// This property gets the connection string value from ConnectionString section
    /// It gets the different connection string for different 
    /// "ServerValue" as defined in the APPSETTING SECTION
    /// </summary>
    public static string ConnectionString
    {
        get
        {
            //if (AppSettings("ServerValue").ToString() == "1")
            return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            //    else if (AppSettings("ServerValue").ToString() == "2")
            //        return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringOnline"].ToString();
            //    else
            //        return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringOnlineBeta"].ToString();
        }
    }
    #endregion
}
