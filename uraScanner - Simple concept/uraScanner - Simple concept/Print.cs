using System;

class Print
{
    public static string tabSpace = " ".PadRight( 0x2D );

    public static void consoleColor( string input, ConsoleColor color, bool nLine /*= true */)
    {
        Console.ForegroundColor = color;
        Console.Write( nLine ? $"{input}{Environment.NewLine}" : input );
    }
}

