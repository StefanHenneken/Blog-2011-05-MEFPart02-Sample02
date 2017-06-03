using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using CarContract;

namespace CarHost
{
    class Program
    {
        [ImportMany(typeof(ICarContract))]
        private IEnumerable<Lazy<ICarContract, ICarMetadata>> CarParts { get; set; }
       
        static void Main(string[] args)
        {
            new Program().Run();
        }
        void Run()
        {          
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            foreach (Lazy<ICarContract, ICarMetadata> car in CarParts)
            {
                Console.WriteLine(car.Metadata.Name);
                Console.WriteLine(car.Metadata.Color);
                Console.WriteLine(car.Metadata.Price);
                Console.WriteLine("");
            }
            // invokes the method only of black cars
            var blackCars = from lazyCarPart in CarParts
                            let metadata = lazyCarPart.Metadata
                            where metadata.Color == CarColor.Black
                            select lazyCarPart.Value;
            foreach (ICarContract blackCar in blackCars)
                Console.WriteLine(blackCar.StartEngine("Sebastian"));
            Console.WriteLine("");
            // invokes the method of all imports
            foreach (Lazy<ICarContract> car in CarParts)
                Console.WriteLine(car.Value.StartEngine("Sebastian"));
            container.Dispose();
        }
    }
}
