using System;
using System.ComponentModel.Composition;
using CarContract;

namespace CarBMW
{
    [ExportMetadata("Name","BMW")]
    [ExportMetadata("Color", CarColor.Black)]
    [ExportMetadata("Price", (uint)55000)]
    [Export(typeof(ICarContract))]
    public class BMW : ICarContract
    {
        private BMW()
        {
            Console.WriteLine("BMW constructor.");
        }
        public string StartEngine(string name)
        {
            return String.Format("{0} starts the BMW.", name);
        }
    }
}
