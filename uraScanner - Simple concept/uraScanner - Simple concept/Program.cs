namespace uraScanner___Simple_concept
{
    using System;

    class Program
    {
        static void Main( string[] args )
        {

            @this.consolePrint_Color
            (
                $"\n\n{@this.tabSpace}{Registered.Name}\n" + 
                    $"{@this.tabSpace}{Registered.Version}\n" + 
                    $"{@this.tabSpace}{nameof( Registered.Author )} : {Registered.Author}\n",

                ConsoleColor.Gray,
                true
            );

            @this.consolePrint_Color(
                $"\nYo {Environment.UserName}!, write <help> to see the available commands.\n",
                ConsoleColor.Gray,
                true
            );

            @return:
            {
                printUser();
                string inputArgument = Console.ReadLine().ToLower();

                switch ( inputArgument )
                {
                    case "exit": return;

                    case
                        "help":
                        {
                            @this.consolePrint_Color( "\nWrite <scan> to start the full scan.", ConsoleColor.Blue, true );
                            @this.consolePrint_Color( "Write <scanreg> to start the startup scan.", ConsoleColor.Blue, true );
                            @this.consolePrint_Color( "Write <scaninject> to start module injection scan.", ConsoleColor.Blue, true );
                            @this.consolePrint_Color( "Write <arg> to see the checked arguments used.", ConsoleColor.Blue, true );
                            @this.consolePrint_Color( "Write <regarg> to see the checked path.", ConsoleColor.Blue, true );
                            @this.consolePrint_Color( "Write <modules> to see checked processes in Module Injection option.", ConsoleColor.Blue, true );
                            @this.consolePrint_Color( "Write <exit> to quit the program.\n", ConsoleColor.Blue, true );
                            goto @return;
                        }
                    case
                        "scan":
                        {
                            Run.runScan( AvailableScans.Scan.ALL );
                            goto @return;
                        }
                    case
                        "scanreg":
                        {
                            Run.runScan( AvailableScans.Scan.RegistryScan );
                            goto @return;
                        }
                    case
                        "scaninject":
                        {
                            Run.runScan( AvailableScans.Scan.ModuleInjection );
                            goto @return;
                        }
                    case
                        "regarg":
                        {
                            @this.consolePrint_Color(
                                    string.Join( "\n", StartupScan.getExtraArg ),
                                    ConsoleColor.Gray,
                                    true
                            );
                            goto @return;
                        }
                    case
                        "modules":
                        {
                            @this.consolePrint_Color(
                                    string.Join( "\n", ModuleInjection.getCheckedProcess ),
                                    ConsoleColor.Gray,
                                    true
                            );
                            goto @return;
                        }
                    case
                        "reg":
                        {
                            @this.consolePrint_Color( 
                                        string.Join( "\n", StartupScan.getRegSub ),
                                        ConsoleColor.Gray,
                                        true 
                            );
                            goto @return;
                        }
                    default:
                        {
                            @this.consolePrint_Color
                            (
                                    "\nCommand doesn't exist. Please write <help> to see the available Commands.",
                                    ConsoleColor.Red,
                                    true
                            );
                            goto @return;
                        }
                }
            }
        }

        private static
                void printUser( )
        {
            @this.consolePrint_Color( $"{Environment.UserName}", ConsoleColor.Green, false );
            @this.consolePrint_Color( "@uraS", ConsoleColor.Red, false );
            @this.consolePrint_Color( ":", ConsoleColor.White, false );
            @this.consolePrint_Color( "~", ConsoleColor.Cyan, false );
            @this.consolePrint_Color( "$", ConsoleColor.DarkMagenta, false );
            @this.consolePrint_Color( " ", ConsoleColor.White, false );
        }
    }
}
