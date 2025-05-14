using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Task14
{
    public static void ReindeerOlympics()
    {
        var input = input14.input.Replace("\n", "").Split("\r"); ;
        string pattern = @"\d+";
        var raceDuration = 2503;
        var distanceTraveled = new List<int>();
        var maxDistance = 0;

        Regex regex = new Regex(pattern);

        foreach(var row in input)
        {
            var values = regex.Matches(row).Select(x => Convert.ToInt32( x.Value)).ToList();
            var cycleDuration = values[1] + values[2];
            int fullCyclesCount = raceDuration / cycleDuration;
            int lastCycleDuration = raceDuration % cycleDuration;
            int lastCycleDistance = Math.Min(lastCycleDuration, values[1]) * values[0];

            var resultDistance = fullCyclesCount * values[0] * values[1] + lastCycleDistance;

            distanceTraveled.Add(resultDistance);
        }

        maxDistance = distanceTraveled.Max();
        Console.WriteLine(maxDistance);
        

        

    }
}