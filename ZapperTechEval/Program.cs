// See https://aka.ms/new-console-template for more information

using ZapperTechEval;

TestCases.Test1();
TestCases.Test2();
TestCases.Test3();

UserSettings settingsToFile = new("11001100");

settingsToFile.Save("test-settings.dat");
settingsToFile.Read("test-settings.dat");
