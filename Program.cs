using System;
using System.Threading;

namespace MonteCarlo
{
    class Program
    {
        static void Main (string [] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew ();
            uint iterations = uint.Parse(Console.ReadLine ());
            int i = 0;
            int outsideCircle = 0;
            int insideCircle = 0;
            Random rand = new Random ();

            do
            {
                Tuple<double, double> tup = RandomTuple (rand);
                double x = tup.Item1;
                double y = tup.Item2;
                double hypot = Hypotenuse (x, y);
                if (hypot > 1)
                {
                    outsideCircle++;
                }
                else
                {
                    insideCircle++;
                }
                ++i;
            } while (i != iterations);
            double calcPi = ((double)insideCircle / (double)iterations) * 4;
            long piDiff = (long)Math.Abs((long)calcPi - (long)Math.PI);
            Console.WriteLine ($"Calculated Pi is {calcPi}. The difference in the calculated Pi and the provided value " +
                $"of pi is {piDiff}");
            watch.Stop ();
            Console.WriteLine ($"Total execution time is :{watch.ElapsedMilliseconds} ms");
        }

        static Tuple<double, double> RandomTuple (Random rand)
        {
            double x = rand.NextDouble ();
            double y = rand.NextDouble ();
            Tuple<double, double> retTup = new Tuple<double, double> (x, y);

            return (retTup);
        }

        //(double, double) RandomePair (Random rand) => (rand.NextDouble (), rand.NextDouble ()); better method for RandomTuple
        //expression body syntax method^

        static double Hypotenuse (double x, double y)
        {
            double hypot = Math.Sqrt (Math.Pow(x,2) + Math.Pow(y, 2));
            return hypot;
        }
    }

}

/* 10 = Calculated Pi is 3.6. The difference in the calculated Pi and the provided value of pi is 0.458407346410207
 100 = Calculated Pi is 3.2. The difference in the calculated Pi and the provided value of pi is 0.0584073464102071
 1000 = Calculated Pi is 3.108. The difference in the calculated Pi and the provided value of pi is 0.033592653589793
 10000 = Calculated Pi is 3.1764. The difference in the calculated Pi and the provided value of pi is 0.034807346410207


    1. Because you're only dealing with one quadrant of the square and in order to fully find the area of the circle
        you must use the data showing how many random points were plotted inside the circle within that quadrant and 
        apply it to all four quadrants.
    2. The more data you have the more accurate your result will be.
    3. No, because each time you run the program it is starting a new random number generator.
    4. 2147483647
    5. 2147483647 : Calculated Pi is 3.14155010094007. The difference in the calculated Pi and the provided value of pi is 4.25526497229711E-05
*/
