namespace GameOfLife
{
    using System;
    public class ConsolePrinter : IConsolePrinter
    {
        public void OutputToConsole(string output)
        {
            foreach(var c in output){
                if(c == 'x'){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(c);
                    Console.ResetColor();
                }else{
                    Console.Write(c);
                }
            }
        }

        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
