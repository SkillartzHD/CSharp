namespace uraScanner___Simple_concept
{
    using System;

    class AvailableScans
    {
        [Flags]
        public enum Scan
        {
            ModuleInjection = 1,
            RegistryScan,
            ALL = ModuleInjection | RegistryScan
        }
    }
}
