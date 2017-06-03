using System;
using System.ComponentModel;

namespace CarContract
{
    public interface ICarMetadata
    {
        [DefaultValue("NoName")]
        string Name { get; }

        [DefaultValue(CarColor.Unkown)]
        CarColor Color { get; }

        [DefaultValue((uint)0)]
        uint Price { get; }
    }
}
