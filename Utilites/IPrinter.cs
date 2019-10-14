using System;

namespace UserInterface
{ 
    public interface IPrinter
    {
        void Write(string msg);
        string Read();
    }
}
