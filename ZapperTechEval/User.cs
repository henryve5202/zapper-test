using System;
using System.Runtime.CompilerServices;

namespace ZapperTechEval;

/// <summary>
/// Contains the settings for a user as a string of flags.
/// </summary>
public class UserSettings
{
    public const uint SMS_NOTIFICATIONS = 0;
    public const uint PUSH_NOTIICATIONS = 1;
    public const uint BIOMETRICS = 2;
    public const uint CAMERA = 3;
    public const uint LOCATION = 4;
    public const uint NFC = 5;
    public const uint VOUCHERS = 6;
    public const uint LOYALTY = 7;

    public string settings = "00000000";

    /// <summary>
    /// Constructor with values for the settings.
    /// </summary>
    /// <param name="settings"></param>
    public UserSettings(string settings)
    {
        if (settings.Length == 8)
        {
            this.settings = settings;
        }
        else
        {
            Console.WriteLine("Invalid Settings Provided");
        }
    }

    /// <summary>
    /// Checks if a specific setting is enabled.
    /// </summary>
    /// <param name="setting">The specfic setting to check for</param>
    /// <returns>True when enabled</returns>
    public bool IsEnabled(uint setting)
    {
        if (IsValidSetting(setting))
        {
            return settings[Convert.ToInt32(setting)] == '1';
        }
        else
        {
            Console.WriteLine("Invalid Setting Provided");
            return false;
        }
    }

    /// <summary>
    /// Reads the settings from a file.
    /// </summary>
    /// <param name="fileName">Filename for the settings.</param>
    /// <returns>0 when successful, -1 when the read failed.</returns>
    public int Read(String fileName)
    {
        using FileStream fileStream = new(fileName, FileMode.Open, FileAccess.Read);

        // Read and verify the data.
        byte[] dataArray = new byte[10];

        // Read and verify the data.
        for (int i = 0; i < fileStream.Length; i++)
        {
            if (dataArray[i] != fileStream.ReadByte())
            {
                Console.WriteLine("Error reading data.");
                return -1;
            }
        }

        // Convert settings back from byte read    
        settings = Convert.ToString(dataArray[0], 2).PadLeft(8, '0');
        return 0;
    }

    /// <summary>
    /// Saves the settings to a file as a byte.
    /// </summary>
    /// <param name="fileName">Filename for the settings.</param>
    /// <returns>0 when successful, -1 when failed.</returns>
    public int Save(String fileName)
    {
        using FileStream fileStream = new(fileName, FileMode.OpenOrCreate, FileAccess.Write);

        // Convert settings to byte to save space
        byte b = Convert.ToByte(settings, 2);
        fileStream.WriteByte(b);
        fileStream.Close();

        return 0;
    }

    private static bool IsValidSetting(uint setting)
    {
        return setting < 8;
    }
}
