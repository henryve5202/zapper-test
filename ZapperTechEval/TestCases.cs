namespace ZapperTechEval
{
    public class TestCases
    {
        public static void Test1()
        {
            UserSettings settings = new("00000000");
            if (!settings.IsEnabled(UserSettings.VOUCHERS))
            {
                Console.WriteLine("Test 1 Passed");
            }
            else
            {
                Console.WriteLine("Test 1 Failed");
            }
        }
        public static void Test2()
        {
            UserSettings settings = new("00000010");
            if (settings.IsEnabled(UserSettings.VOUCHERS))
            {
                Console.WriteLine("Test 2 Passed");
            }
            else
            {
                Console.WriteLine("Test 2 Failed");
            }
        }
        public static void Test3()
        {
            UserSettings settings = new("11111111");
            if (settings.IsEnabled(UserSettings.CAMERA))
            {
                Console.WriteLine("Test 3 Passed");
            }
            else
            {
                Console.WriteLine("Test 3 Failed");
            }
        }
    }
}