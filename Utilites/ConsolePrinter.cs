using System;


namespace UserInterface
{
    public class ConsolePrinter : IPrinter
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
