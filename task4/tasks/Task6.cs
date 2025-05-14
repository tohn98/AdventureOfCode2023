using System;
using System.Collections.Generic;
using System.Linq;

class Task6
{
    public static void Lights()
    {
        var input = input6.input.Replace("\n", "").Split("\r");


        //part 1
        var lightsOn = 0;

        //part 2
        long totalBrightness = 0;
        

        byte[][] lights = new byte[1000][];
        int[][] brightness = new int[1000][];
        for(int i=0; i<1000;i++)
        {
            lights[i] = new byte[1000];
            brightness[i] = new int[1000];
        }

        foreach (var row in input)
        {
            IEnumerable<int> from = null;
            IEnumerable<int> to = null;
            var data = row.Split(" ");
            if (data[1] == "off")
            {
                from = data[2].Split(',').Select(x=> Convert.ToInt32(x));
                to = data[4].Split(',').Select(x => Convert.ToInt32(x));

                for (int i = Math.Min(from.ElementAt(0), to.ElementAt(0)) ; i <= Math.Max(from.ElementAt(0), to.ElementAt(0)); i++)
                {
                    for( int j = Math.Min(from.ElementAt(1), to.ElementAt(1)); j<= Math.Max(from.ElementAt(1), to.ElementAt(1)); j++)
                    {
                        lights[i][j] = 0;
                        brightness[i][j] = brightness[i][j] > 0 ? brightness[i][j] - 1 : 0;  
                    }
                }
            }
            else if ( data[1] == "on")
            {
                from = data[2].Split(',').Select(x => Convert.ToInt32(x));
                to = data[4].Split(',').Select(x => Convert.ToInt32(x));

                for (int i = Math.Min(from.ElementAt(0), to.ElementAt(0)); i <= Math.Max(from.ElementAt(0), to.ElementAt(0)); i++)
                {
                    for (int j = Math.Min(from.ElementAt(1), to.ElementAt(1)); j <= Math.Max(from.ElementAt(1), to.ElementAt(1)); j++)
                    {
                        lights[i][j] = 1;
                        brightness[i][j] += 1;
                    }
                }
            }
            else if ( data[0] == "toggle")
            {
                from = data[1].Split(',').Select(x => Convert.ToInt32(x));
                to = data[3].Split(',').Select(x => Convert.ToInt32(x));

                for (int i = Math.Min(from.ElementAt(0), to.ElementAt(0)); i <= Math.Max(from.ElementAt(0), to.ElementAt(0)); i++)
                {
                    for (int j = Math.Min(from.ElementAt(1), to.ElementAt(1)); j <= Math.Max(from.ElementAt(1), to.ElementAt(1)); j++)
                    {
                        lights[i][j] = lights[i][j] == 0 ? 1 : 0;
                        brightness[i][j] += 2;
                    }
                }
            }
            else
            {
                var lol = 1;
            }
        }

        foreach(var row in lights)
        {
            foreach(var cell in row)
            {
                lightsOn += cell;
            }
        }

        foreach (var row in brightness)
        {
            foreach (var cell in row)
            {
                totalBrightness += cell;
            }
        }

        Console.WriteLine(lightsOn);
        Console.WriteLine(totalBrightness);


    }
}