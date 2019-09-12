using System;
using FeatureFlag.Example.FeatureFlags;

namespace FeatureFlag.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FeatureFlag Example\n");
            
            var helloWorldFeature = new HelloWorldFeature(false);
            var calendarFeature = new CalendarFeature(true);

            if(helloWorldFeature.FeatureEnabled)
                Console.WriteLine("Hello World!");

            if (calendarFeature.FeatureEnabled)
                Console.WriteLine($"{DateTime.Now.Year:0000}-{DateTime.Now.Month:00}-{DateTime.Now.Day:00}");
            
            Console.ReadKey();
        }
    }
}