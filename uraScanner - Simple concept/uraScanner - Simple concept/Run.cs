using System;
using uraScanner;

class Run
{
    public static void runScan( AvailableScans.Scan chosenScan )
    {
        Print.consoleColor( "\n Scan started", ConsoleColor.Green, true );

        switch ( chosenScan )
        {
            case
                AvailableScans.Scan.ALL:
                {
                    StartupScan.scanRegistry();
                    ModuleInjection.scanModules();
                    break;
                }
            case
                AvailableScans.Scan.ModuleInjection:
                {
                    ModuleInjection.scanModules();
                    break;
                }
            case
                AvailableScans.Scan.RegistryScan:
                {
                    StartupScan.scanRegistry();
                    break;
                }
        }

        Print.consoleColor( "\n\n Scan Completed. \n", ConsoleColor.Green, true );
    }
}
