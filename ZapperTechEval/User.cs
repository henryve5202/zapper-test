using System;
using System.Runtime.CompilerServices;

namespace ZapperTechEval;

public class UserSettings
{
    public const int SMS_NOTIFICATIONS = 0;
    public const int PUSH_NOTIICATIONS = 1;
    public const int BIOMETRICS = 2;
    public const int CAMERA = 3;
    public const int LOCATION = 4;
    public const int NFC = 5;
    public const int VOUCHERS = 6;
    public const int LOYALTY = 7;

    public string settings = "00000000";

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

    public bool IsEnabled(int setting)
    {
        return this.settings[setting] == '1';
    }

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

        settings = Convert.ToString(dataArray[0], 2).PadLeft(8, '0');
        return 0;
    }

    public int Save(String fileName)
    {
        using FileStream fileStream = new(fileName, FileMode.OpenOrCreate, FileAccess.Write);
        byte b = Convert.ToByte(settings, 2);
        fileStream.WriteByte(b);
        fileStream.Close();

        return 0;
    }
}
