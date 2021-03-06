﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

class ModuleInjection
{
    public static List< string >    getCheckedProcess
                              =>    possibleProcesses.ToList();

    private readonly static string moduleInjectionPath = 
        $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\ModuleInjection.txt";

    private static string[] possibleProcesses =
    {
                "iexplorer",
                "Chrome",
                "firefox",
                "svchost",
                "explorer",
                "crss",
                "smss",
                "cmd",
                "rundll32",
                "dllhost",
                "dmw",
                "wininit",
                "winlogon",
                "conhost",
                "dasHost"
    };

    public static void scanModules( )
    {
        try
        {
            string  buildStr = File.ReadAllText( moduleInjectionPath );

            foreach ( var _process in possibleProcesses )
            {
                Print.consoleColor( $"Process : {_process}", ConsoleColor.Green, true );

                foreach ( var eachProcess in Process.GetProcessesByName( _process ) )
                {
                    for ( int i = 0; i < eachProcess.Modules.Count; i++ )
                    {
                        var moduleFileName  =   eachProcess.Modules[i].FileName;
                        if ( buildStr.Contains( checkInjection( moduleFileName ) ) )
                            Print.consoleColor(
                                                $"{_process} | {moduleFileName} | [Id:{eachProcess.Id}]",
                                                ConsoleColor.Red,
                                                true
                            );
                    }
                }

                Print.consoleColor( $"End Scan for : {_process}", ConsoleColor.Green, true );
            }
        }
        catch ( Exception ex )
        {
            Print.consoleColor( $"Error : {ex.Message}", ConsoleColor.Magenta, true );
        }
    }

    private static string checkInjection( string input )
    {
        var stringBuilder = new StringBuilder();

        using ( var md5 = new MD5CryptoServiceProvider() )
        using ( var inputStream = new FileStream( input, FileMode.Open, FileAccess.Read, FileShare.Read, 8192 ) )
        {
            foreach ( var bytes in md5.ComputeHash( inputStream ) )
            {
                stringBuilder.Append( bytes.ToString( "X2" ) );
            }
        }

        return stringBuilder.ToString();
    }

}
