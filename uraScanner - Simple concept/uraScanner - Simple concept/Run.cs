using System;
using uraScanner___Simple_concept;

class Run
{
    public static
           void runScan( AvailableScans.Scan chosenScan )
    {
        @this.consolePrint_Color( "\n Scan started", ConsoleColor.Green, true );

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

        @this.consolePrint_Color( "\n\n Scan Completed. \n", ConsoleColor.Green, true );
    }
}
