using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

class StartupScan
{
    public static List< string > getRegSub
                              => regScanPath.ToList();

    public static List<string> getExtraArg
                              => Enumerable.Range( 0, extraArguments.GetLength( 0 ) )
                                           .Select( c => extraArguments[c, 0] )
                                           .ToList( ) 
    ;

    private readonly static
                string[ ] regScanPath   =
        {
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce",
                "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Windows",
                "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon",
                "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run",
                "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\RunOnce",
                "SOFTWARE\\Wow6432\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon"
        };

    private static readonly
                string[ , ] extraArguments =
        {
               { "\"\""             , "5" },
               { ", explorer.exe"   , "70" },
               { ",svchost.exe"     , "63" },
               { "/reg"             , "43" },
               { "/service"         , "25" },
               { ",ServiceMain"     , "25" },
               { "-silent"          , "45" },
               { "/autostart"       , "40" },
               { "/autorun"         , "40" },
               { "-autostart"       , "40" },
               { "/min"             , "10" },
               { "/minimized"       , "10" },
               { "-minimized"       , "10" },
               { "/background"      , "13" },
               { "-hide"            , "61" },
               { "-hidden"          , "61" },
               { "cmd /C"           , "20" }
        };


    public static
           void scanRegistry( )
    {
        foreach ( var regKey in regScanPath )
        {
            using ( var reg = Registry.LocalMachine.OpenSubKey( regKey, false ) )
            {
                if ( reg == null )
                    continue;

                var valueNames = reg.GetValueNames();

                for ( int j = 0; j < valueNames.Count(); j++ )
                {
                    for ( int k = 0; k <= extraArguments.GetUpperBound( 0 ); k++ )
                    {
                        var getVal = reg.GetValue( valueNames[ j ] ).ToString();
                        if ( getVal.Contains( extraArguments[k, 0] ) )
                        {
                            @this.consolePrint_Color(
                                        $"\n Found : {getVal.ToString()}",
                                        ConsoleColor.Red,
                                        false
                            );
                            @this.consolePrint_Color( $" | ", ConsoleColor.Magenta, false );
                            @this.consolePrint_Color( $"Found : {extraArguments[k, 0]}", ConsoleColor.Gray, false );
                            @this.consolePrint_Color( $" | ", ConsoleColor.Yellow, false );
                            @this.consolePrint_Color( "Detection rate : ", ConsoleColor.White, false );
                            @this.consolePrint_Color(
                                        $"[{int.Parse( extraArguments[k, 1] )}%]",
                                        ConsoleColor.Green,
                                        true
                            );
                        }
                    }
                }
            }
        }
    }
}

