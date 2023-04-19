// See https://aka.ms/new-console-template for more information

using ServiceNowComparerConsole;

using ServiceNowComparerLibrary.Modules.Static;

LogModule.WriteInformation("Application loaded!");

MainMenu mainMenu = new();
mainMenu.OpenMenu();