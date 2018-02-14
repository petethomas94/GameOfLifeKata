namespace GameOfLife
{
    using System;
    using System.Text.RegularExpressions;

    public class ConsolePrinter : IConsolePrinter
    {
        private Regex _regex = new Regex(@"([ox])\1+");

        public void OutputToConsole(string output)
        {
            var split = _regex.Match(output);

            foreach (var c in output)
            {
                if (c == 'x')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(c);
                    Console.ResetColor();
                }
                else
                {
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
