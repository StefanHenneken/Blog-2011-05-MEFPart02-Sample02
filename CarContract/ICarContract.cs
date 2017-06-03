using System;

namespace CarContract
{
    public interface ICarContract
    {
        string StartEngine(string name);
    }

    public enum CarColor
    {
        Unkown,
        Black,
        Red,
        Blue,
        White
    }  
}
