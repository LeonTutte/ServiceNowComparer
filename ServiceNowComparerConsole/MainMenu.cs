using Spectre.Console;

namespace ServiceNowComparerConsole;

public class MainMenu
{
    private ConsoleKey _cki;
    private string _storageFile;
    private string? _lastConsoleInput;

    public void OpenMenu()
    {
        AskForStorageFile();
        while (_cki != ConsoleKey.Q)
        {
            Thread.Sleep(1000);
            AnsiConsole.Clear();
            AnsiConsole.Markup("");
            AnsiConsole.MarkupLine("--- [green]Please choose an action[/] ---");
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
        AnsiConsole.WriteLine("Please input your storage file name: ");
        UserInputPrompt();
        _storageFile = _lastConsoleInput + ".storage";
        AnsiConsole.Status()
            .Start("Checking for existing file", ctx =>
            {
                // TODO: Check if file exists
                AnsiConsole.MarkupLine("Checking...");

                ctx.Spinner(Spinner.Known.Arc);
                ctx.SpinnerStyle(Style.Parse("yellow"));
                if (new Random().Next(1, 100) > 2)
                {
                    // TODO: Open file with password
                    ctx.Status("Opening storage");
                    ctx.SpinnerStyle(Style.Parse("green"));
                    Thread.Sleep(3000);
                }
                else
                {
                    // TODO: ask if file should be created
                    ctx.Status("Could not find file");
                    ctx.SpinnerStyle(Style.Parse("red"));
                    Thread.Sleep(3000);
                }
            });
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