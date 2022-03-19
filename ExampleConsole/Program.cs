using System;
using ABCNet;
using System.Collections.Generic;

namespace ExampleConsole
{
    class Program
    {
		private static Random random = new Random(Guid.NewGuid().GetHashCode());

        static void Main(string[] args)
        {
            CharTest();
        }

        private static void LocationTest()
        {
            List<IFoodSource> foodSources = new List<IFoodSource>();
            for (int i = 0; i < 10; i++)
            {
                foodSources.Add(new LocationFoodSource(FoodSourceLocation.GenerateRandom(random)));
            }
            for (int i = 0; i < 50; i++)
            {
                Colony colony = new Colony(100, foodSources);

                var fittestSources = colony.Run();
                fittestSources.ForEach(x =>
                {
                    Console.WriteLine(string.Format("{0:0.000} => {1}", x.Fitness, x.ToString()));
                });
                Console.WriteLine("==============================");
            }
        }


        private static void CharTest()
        {
            List<IFoodSource> foodSources = new List<IFoodSource>();
            for (int i = 0; i < 10; i++)
            {
                foodSources.Add(new CharFoodSource((char)random.Next('A', 'z')));
            }
            for (int i = 0; i < 50; i++)
            {
                Colony colony = new Colony(100, foodSources);

                var fittestSources = colony.Run();
                fittestSources.ForEach(x =>
                {
                    Console.WriteLine(string.Format("{0:0.000} => {1}", x.Fitness, x.ToString()));
                });
                Console.WriteLine("==============================");
            }
        }
    }
}
