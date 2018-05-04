namespace uraScanner
{
    using System;

    class Program
    {
        private static void Main( string[] args )
        {           
            Print.consoleColor(
                $"\n\n{Print.tabSpace}{Registered.Name}\n" + 
                    $"{Print.tabSpace}{Registered.Version}\n" + 
                    $"{Print.tabSpace}{nameof( Registered.Author )} : {Registered.Author}\n",

                ConsoleColor.Gray,
                true
            );

            Print.consoleColor(
                $"\nYo {Environment.UserName}!, write <help> to see the available commands.\n",
                ConsoleColor.Gray,
                false
            );

            printUser();

            string inputArgument;
            while ( ( inputArgument = Console.ReadLine().ToLower() ) != "exit" )
            {
                switch ( inputArgument )
                {
                    case
                        "help":
                        {
                            Print.consoleColor( "\nWrite <scan> to start the full scan.", ConsoleColor.Blue, true );
                            Print.consoleColor( "Write <scanreg> to start the startup scan.", ConsoleColor.Blue, true );
                            Print.consoleColor( "Write <scaninject> to start module injection scan.", ConsoleColor.Blue, true );
                            Print.consoleColor( "Write <arg> to see the checked arguments used.", ConsoleColor.Blue, true );
                            Print.consoleColor( "Write <regarg> to see the checked path.", ConsoleColor.Blue, true );
                            Print.consoleColor( "Write <modules> to see checked processes in Module Injection option.", ConsoleColor.Blue, true );
                            Print.consoleColor( "Write <exit> to quit the program.\n", ConsoleColor.Blue, true );
                            printUser();
                            break;
                        }
                    case
                        "scan":
                        {
                            Run.runScan( AvailableScans.Scan.ALL );
                            printUser();
                            break;
                        }
                    case
                        "scanreg":
                        {
                            Run.runScan( AvailableScans.Scan.RegistryScan );
                            printUser();
                            break;
                        }
                    case
                        "scaninject":
                        {
                            Run.runScan( AvailableScans.Scan.ModuleInjection );
                            printUser();
                            break;
                        }
                    case
                        "regarg":
                        {
                            Print.consoleColor(
                                    string.Join( "\n", StartupScan.getExtraArg ),
                                    ConsoleColor.Gray,
                                    true
                            );
                            printUser();
                            break;
                        }
                    case
                        "modules":
                        {
                            Print.consoleColor(
                                    string.Join( "\n", ModuleInjection.getCheckedProcess ),
                                    ConsoleColor.Gray,
                                    true
                            );
                            printUser();
                            break;
                        }
                    case
                        "reg":
                        {
                            Print.consoleColor(
                                        string.Join( "\n", StartupScan.getRegSub ),
                                        ConsoleColor.Gray,
                                        true
                            );
                            printUser();
                            break;
                        }
                    default:
                        {
                            Print.consoleColor
                            (
                                    "\nCommand doesn't exist. Please write <help> to see the available Commands.",
                                    ConsoleColor.Red,
                                    true
                            );
                            printUser();
                            break;
                        }
                }
            }
        }

        private static void printUser( )
        {
            Print.consoleColor( $"{Environment.UserName}", ConsoleColor.Green, false );
            Print.consoleColor( "@uraS", ConsoleColor.Red, false );
            Print.consoleColor( ":", ConsoleColor.White, false );
            Print.consoleColor( "~", ConsoleColor.Cyan, false );
            Print.consoleColor( "$", ConsoleColor.DarkMagenta, false );
            Print.consoleColor( " ", ConsoleColor.White, false );
        }
    }
}
