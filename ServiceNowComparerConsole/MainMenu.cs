using LiteDB;

using ServiceNowComparerLibrary.Modules.Static;

using Spectre.Console;

namespace ServiceNowComparerConsole;

public class MainMenu
{
    private ConsoleKey _cki;
    private string _storageFile;
    private string? _lastConsoleInput;
    private LiteDatabase? _storage;

    public void OpenMenu()
    {
        AskForStorageFile();
        while (_cki != ConsoleKey.Q)
        {
            Thread.Sleep(1000);
            AnsiConsole.Clear();
            AnsiConsole.Markup("");
            AnsiConsole.MarkupLine("--- [green]Please choose an action[/] ---");
            AnsiConsole.WriteLine("A: Create new ServiceNow Instance");
            AnsiConsole.MarkupLine("--- [grey]Quit by pressing Q[/] ---");

            UserInputPrompt(true);
            switch (_cki)
            {
                case ConsoleKey.Q:
                    break;
                default:
                    AnsiConsole.Markup("[red]Invalid Input![/]");
                    break;
            }
        }
    }

    public void AskForStorageFile()
    {
        _storageFile = StorageModule.GetStorageLabel();
        AnsiConsole.Status()
            .Start("Checking for storage file", ctx =>
            {
                // TODO: Check if file exists
                AnsiConsole.MarkupLine("Checking...");

                ctx.Spinner(Spinner.Known.Arc);
                ctx.SpinnerStyle(Style.Parse("yellow"));
            });
        if (File.Exists(_storageFile))
        {
            AnsiConsole.WriteLine("Please input your storage password");
            UserInputPrompt();
            CryptoModule.StoragePassword = _lastConsoleInput;
            _lastConsoleInput = String.Empty;
            _storage = StorageModule.GetStorage();
            AnsiConsole.MarkupLine("[green]Opening storage[/]");
            Thread.Sleep(2000);
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Could not find file[/]");
            Thread.Sleep(1000);
            var answer = AnsiConsole.Prompt(
                new SelectionPrompt<bool>()
                    .Title($"Do you want to create a new storage with the label {_storageFile}")
                    .AddChoices(new bool[] { true, false }));
            if (answer)
            {
                AnsiConsole.WriteLine("Creating new file");
                Thread.Sleep(1000);
                AnsiConsole.WriteLine("Please input your storage password");
                UserInputPrompt();
                CryptoModule.StoragePassword = _lastConsoleInput;
                _lastConsoleInput = String.Empty;
                _storage = StorageModule.GetStorage();
                AnsiConsole.MarkupLine("[green]Opening storage[/]");
                Thread.Sleep(2000);
            }
            else
            {
                AnsiConsole.WriteLine("Exiting");
                Environment.Exit(0);
            }
        }
    }

    private void UserInputPrompt(bool key = false)
    {
        AnsiConsole.Markup("[blue]//:[/] ");
        if (key)
        {
            _cki = Console.ReadKey().Key;
            AnsiConsole.WriteLine();
        }
        else
        {
            _lastConsoleInput = Console.ReadLine();
            AnsiConsole.WriteLine();
        }
    }
}