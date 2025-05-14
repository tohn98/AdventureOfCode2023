using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2023
{
    public class Task
    {

        public static void Trebuchet1()
        {
            var input = Inputs.Input1.input1.Replace("\n", "").Split("\r");
            var result1 = 0;
            var result2 = 0;

            var stringNumbers = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            for (int i=0; i <input.Count(); i++ )
            {
                //part 1
                var tens = Convert.ToInt32(input[i].First(x => char.IsDigit(x)).ToString());
                var singles = Convert.ToInt32(input[i].Last(x => char.IsDigit(x)).ToString());
                result1 += (tens * 10 + singles);

                //part 2
                var firstIndex = input[i].IndexOf(input[i].First(x => char.IsDigit(x)));
                var lastIndex = input[i].LastIndexOf(input[i].Last(x => char.IsDigit(x)));

                var firstNumber = tens;
                var lastNumber = singles;
                for (int j = 0; j < stringNumbers.Count(); j++)
                {
                    var firstStringIndex = input[i].IndexOf(stringNumbers[j]);
                    var lastStringIndex = input[i].LastIndexOf(stringNumbers[j]);
                    if (firstStringIndex >= 0)
                    {
                        if (lastStringIndex > lastIndex)
                        {
                            lastIndex = lastStringIndex;
                            lastNumber = j + 1;
                        }
                        if (firstStringIndex < firstIndex)
                        {
                            firstIndex = firstStringIndex;
                            firstNumber = j + 1;
                        }
                    }
                }
                Console.WriteLine(firstNumber * 10 + lastNumber);
                result2 += (firstNumber * 10 + lastNumber);
            }

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        public static void CubeConundrum2()
        {
            var input = Inputs.Input2.input.Replace("\n", "").Split("\r");

            var result = 0;

            var maxRed = 12;
            var maxGreen = 13;
            var maxBlue = 14;


            foreach (var row in input)
            {
                var data = row.Split(":", StringSplitOptions.RemoveEmptyEntries);
                var gameId = Convert.ToInt32(data[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
                var rounds = data[1].Split(";", StringSplitOptions.RemoveEmptyEntries);



                var isGamePossible = true;

                foreach (var round in rounds)
                {
                    var redCount = 0;
                    var blueCount = 0;
                    var greenCount = 0;

                    var cubes = round.Split(",", StringSplitOptions.RemoveEmptyEntries);

                    foreach (var cube in cubes)
                    {
                        var cubeData = cube.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        var count = Convert.ToInt32(cubeData[0]);
                        var color = cubeData[1];

                        if (color == "red")
                        {
                            redCount += count;
                        }
                        else if (color == "blue")
                        {
                            blueCount += count;
                        }
                        else if (color == "green")
                        {
                            greenCount += count;
                        }
                    }

                    if (redCount > maxRed || blueCount > maxBlue || greenCount > maxGreen)
                    {
                        isGamePossible = false;
                        break;
                    }
                }

                if (isGamePossible)
                {
                    result += gameId;
                }

            }

            Console.WriteLine(result);


        }

        public static void CubeConundrum2Part2()
        {
            var input = Inputs.Input2.input.Replace("\n", "").Split("\r");

            var result = 0;

            foreach (var row in input)
            {
                var data = row.Split(":", StringSplitOptions.RemoveEmptyEntries);
                var rounds = data[1].Split(";", StringSplitOptions.RemoveEmptyEntries);

                var maxRedCount = 0;
                var maxBlueCount = 0;
                var maxGreenCount = 0;

                foreach (var round in rounds)
                {
                    var cubes = round.Split(",", StringSplitOptions.RemoveEmptyEntries);

                    foreach (var cube in cubes)
                    {
                        var cubeData = cube.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        var count = Convert.ToInt32(cubeData[0]);
                        var color = cubeData[1];

                        if (color == "red" && maxRedCount < count)
                        {
                            maxRedCount = count;
                        }
                        else if (color == "blue" && maxBlueCount < count)
                        {
                            maxBlueCount = count;
                        }
                        else if (color == "green" && maxGreenCount < count)
                        {
                            maxGreenCount = count;
                        }
                    }
                }
                result += maxRedCount * maxBlueCount * maxGreenCount;

            }
            Console.WriteLine(result);
        }

        public static void GearRatios3()
        {
            var input = Inputs.Input3.input.Replace("\n", "").Split("\r");
            var result = 0;

            Regex numberRegex = new Regex(@"\d+");
            Regex symbolRegex = new Regex("[^0-9.]");

            for (int i = 0; i < input.Length; i++)
            {

                MatchCollection numberMatches = numberRegex.Matches(input[i]);
                foreach (Match match in numberMatches)
                {
                    if (match.Success)
                    {
                        var value = Convert.ToInt32(match.Value);
                        var extraSearchLength = match.Value.Length == 2 ? 1 : match.Value.Length == 3 ? 2 : 0;

                        int startRow = Math.Max(i - 1, 0);
                        int endRow = Math.Min(i + 1, input.Length - 1);
                        int startCol = Math.Max(match.Index - 1, 0);
                        int endCol = Math.Min(match.Index + 1 + extraSearchLength, input[i].Length - 1);

                        for (int j = startRow; j <= endRow; j++)
                        {
                            var sectionToCheck = input[j].Substring(startCol, endCol - startCol + 1);
                            var symbolMatch = symbolRegex.Match(sectionToCheck);
                            if (symbolMatch.Success)
                            {
                                result += value;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(result);
        }

        public static void GearRatios3Part2()
        {
            var input = Inputs.Input3.input.Replace("\n", "").Split("\r");
            var result = 0;

            Regex numberRegex = new Regex(@"\d+");
            Regex symbolRegex = new Regex(@"\*");

            for (int i = 0; i < input.Length; i++)
            {

                MatchCollection numberMatches = numberRegex.Matches(input[i]);
                foreach (Match match in numberMatches)
                {
                    if (match.Success)
                    {
                        var value = Convert.ToInt32(match.Value);
                        var extraSearchLength = match.Value.Length == 2 ? 1 : match.Value.Length == 3 ? 2 : 0;

                        int startRow = Math.Max(i - 1, 0);
                        int endRow = Math.Min(i + 1, input.Length - 1);
                        int startCol = Math.Max(match.Index - 1, 0);
                        int endCol = Math.Min(match.Index + 1 + extraSearchLength, input[i].Length - 1);

                        for (int j = startRow; j <= endRow; j++)
                        {
                            var sectionToCheck = input[j].Substring(startCol, endCol - startCol + 1);
                            var symbolMatch = symbolRegex.Match(sectionToCheck);
                            if (symbolMatch.Success)
                            {
                                result += value;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(result);
        }

        public static void ScratchCards4()
        {
            var input = Inputs.Input4.input.Replace("\n", "").Split("\r").Select(x => x.Split(":")[1]);
            var result1 = 0;
            var result2 = 0;
            var countByCard = new int[input.Count()];

            int index = 0;

            foreach (var row in input)
            {
                var numbers = row.Split('|');
                var winningNumbers = numbers[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());
                var numbersWeHave = numbers[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());

                var overlapCount = winningNumbers.Intersect(numbersWeHave).Count();

                //part 1
                if (overlapCount >= 1)
                {
                    result1 += (int)Math.Pow(2, overlapCount - 1);
                }

                //part 2
                var countToCopy = countByCard[index];
                countByCard[index]++;

                for (int i = index + 1; i <= index + overlapCount; i++)
                {
                    countByCard[i] += 1 + countToCopy;
                }
                index++;
            }
            result2 = countByCard.Sum();

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        public static void Fertilizer5()
        {

            long CalcSeedLocation(long seed, string[] maps)
            {
                var seedCurrentPos = seed;
                foreach (var map in maps)
                {
                    foreach (var mapData in map.Split('\n'))
                    {
                        var splitedData = mapData.Split(' ').Select(x => Convert.ToInt64(x));
                        var sourceValue = splitedData.ElementAt(1);

                        if (seedCurrentPos >= sourceValue)
                        {
                            var length = splitedData.ElementAt(2);
                            if (seedCurrentPos < sourceValue + length)
                            {
                                var destinationValue = splitedData.ElementAt(0);

                                seedCurrentPos = destinationValue + seedCurrentPos - sourceValue;
                                break;

                            }
                        }
                    }

                    if (seed == seedCurrentPos)
                    {
                        Console.WriteLine("no change");
                    }
                }

                return seedCurrentPos;
            }

            var seeds = Inputs.Input5.seeds.Split(' ').Select(x => Convert.ToInt64(x));
            var maps = Inputs.Input5.maps;
            long minSeedLocation1 = -1;
            long minSeedLocation2 = -1;

            //part 1
            foreach( var seed in seeds)
            {

                var seedMapedFinalLocation = CalcSeedLocation(seed, maps);

                if (minSeedLocation1 == -1 || minSeedLocation1 > seedMapedFinalLocation)
                {
                    minSeedLocation1 = seedMapedFinalLocation;
                }
            }

            //part 2

            foreach (var mapData in maps[0].Replace("\n", "").Split("\r"))
            {
                foreach (var test2 in maps.Skip(1))
                {
                    foreach(var test3 in test2.Replace("\n", "").Split("\r"))
                    {
                        var splitedData = test3.Split(' ').Select(x => Convert.ToInt64(x));
                        var sourceValue = splitedData.ElementAt(1);
                            var length = splitedData.ElementAt(2);
                                var destinationValue = splitedData.ElementAt(0);

                    }

                }
            }

            for(int i = 0; i < seeds.Count(); i+= 2)
            {
                var startSeedIndex = seeds.ElementAt(i);
                var range = seeds.ElementAt(i + 1);

                for (long j = startSeedIndex; j< startSeedIndex + range; j++)
                {
                    var seedMapedFinalLocation = CalcSeedLocation(j, maps);

                    if (minSeedLocation2 == -1 || minSeedLocation2 > seedMapedFinalLocation)
                    {
                        minSeedLocation2 = seedMapedFinalLocation;
                    }
                }
            }
            Console.WriteLine(minSeedLocation1);
            Console.WriteLine(minSeedLocation2);
        }

        public static void Fertilizer5Part2()
        {
            var seeds = Inputs.Input5.seeds.Split(' ').Select(x => Convert.ToInt64(x));
            var maps = Inputs.Input5.maps;
            long minSeedLocation2 = -1;

           

            foreach (var mapData in maps[0].Replace("\n", "").Split("\r"))
            {
                foreach (var test2 in maps.Skip(1))
                {
                    foreach (var test3 in test2.Replace("\n", "").Split("\r"))
                    {
                        var splitedData = test3.Split(' ').Select(x => Convert.ToInt64(x));
                        var sourceValue = splitedData.ElementAt(1);
                        var length = splitedData.ElementAt(2);
                        var destinationValue = splitedData.ElementAt(0);

                    }

                }
            }

            for (int i = 0; i < seeds.Count(); i += 2)
            {
                var startSeedIndex = seeds.ElementAt(i);
                var range = seeds.ElementAt(i + 1);

                for (long j = startSeedIndex; j < startSeedIndex + range; j++)
                {
                    //var seedMapedFinalLocation = CalcSeedLocation(j, maps);

                    //if (minSeedLocation2 == -1 || minSeedLocation2 > seedMapedFinalLocation)
                    //{
                    //    minSeedLocation2 = seedMapedFinalLocation;
                    //}
                }
            }
            Console.WriteLine(minSeedLocation2);
        }




        public static void BoatRace6()
        {
            var input = Inputs.Input6.input;
            //can use binary search
            //and can count only up to the middle time and double the result
            var result1 = 1;

            //part 1
            for (int i = 0; i < input.Length; i++)
            {
                var race = input[i];
                var winningRaceCount = 0;
                for (int j = 1; j <= race.time; j++)
                {
                    var traveledDistance = (race.time - j) * j;
                    if (traveledDistance > race.distanceToBeat)
                    {
                        winningRaceCount++;
                    }
                }
                result1 *= winningRaceCount;
            }

            //part 2
            var time = 40929790;
            var distanceToBeat = 215106415051100;
            var start = distanceToBeat / time;
            long result2 = 0;

            for (long j = start; j <= time / 2; j++)
            {
                var traveledDistance = (time - j) * j;
                if (traveledDistance > distanceToBeat)
                {
                    result2 = time - 2 * j + 1;
                    break;
                }
            }

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        public static void CamelCards7()
        {
            var input = Inputs.Input7.input.Replace("\n", "").Split("\r");

            foreach (var row in input)
            {
                var data = row.Split(" ");
                var hand = data[0];
                var value = data[1];
                var repeates = new (char letter, int count)[5];

                foreach (var card in hand)
                {

                }
            }

        }

        public static void NavigateNetwork8()
        {

            var input = Inputs.Input8.input.Replace("\n", "").Split("\r", StringSplitOptions.RemoveEmptyEntries);

            var elements = new Dictionary<string, (string left, string right)>();

            for (int i = 1; i < input.Length; i++)
            {
                string pattern = @"[a-zA-Z]{3}";

                MatchCollection matches = Regex.Matches(input[i], pattern);

                var node = matches[0].Value;
                var left = matches[1].Value;
                var right = matches[2].Value;

                elements.Add(node, (left, right));

            }

            //part 1
            var currentNode = "AAA";
            var targetNode = "ZZZ";
            var steps = 0;
            var found = false;

            while (!found)
            {
                foreach (var direction in input[0])
                {
                    if (direction == 'L')
                    {
                        currentNode = elements[currentNode].left;
                    }
                    else
                    {
                        currentNode = elements[currentNode].right;
                    }

                    steps++;

                    if (currentNode == targetNode)
                    {
                        found = true;
                        break;
                    }
                }
            }

            //part 2
            var startingElements = elements.Keys.Where(x => x.EndsWith('A')).ToList();
            var foundPart2 = false;
            long stepsPart2 = 0;
            var test = new List<List<long>>(6);
            for( int i = 0;i< 6; i++)
            {
                test.Add(new List<long>());
            }
            while (!foundPart2)
            {
                foreach (var direction in input[0])
                {
                    for (var i = 0; i < startingElements.Count; i++)
                    {
                        if (direction == 'L')
                        {
                            startingElements[i] = elements[startingElements[i]].left;
                        }
                        else
                        {
                            startingElements[i] = elements[startingElements[i]].right;
                        }
                    }

                    for( int i=0;i< startingElements.Count; i++)
                    {
                        if(startingElements[i].EndsWith('Z'))
                        {
                            if(test[i].Count > 0)
                            {
                                test[i].Add(stepsPart2 - test[i][test[i].Count - 1]);
                            }
                            else
                            {
                                test[i].Add(stepsPart2);
                            }
                            
                        }
                    }
                    if (startingElements.Where(x => x.EndsWith('Z')).Count() > 3)
                    {
                        Console.WriteLine(string.Join(", ", startingElements));
                    }


                    stepsPart2++;

                    if (startingElements.All(x => x.EndsWith('Z')))
                    {
                        foundPart2 = true;
                        break;
                    }
                }
            }


            Console.WriteLine(steps);
            Console.WriteLine(stepsPart2);
        }

        public static void OASIS9()
        {
            var input = Inputs.Input9.input.Replace("\n", "").Split("\r");

            long result1 = 0;
            long result2 = 0;

            foreach (var history in input)
            {
                var data = history.Split(' ').Select(x => Convert.ToInt32(x)).ToList();
                var lastValues = new List<int>();
                var firstValues = new List<int>();
                var currentHistory = data;
                while (currentHistory.Any(x => x != 0))
                {
                    var newHistory = new List<int>(currentHistory.Count - 1);

                    for (int i = 0; i < currentHistory.Count - 1; i++)
                    {
                        newHistory.Add(currentHistory[i + 1] - currentHistory[i]);
                    }
                    //part 1
                    lastValues.Add(currentHistory[currentHistory.Count - 1]);

                    //part 2
                    firstValues.Add(currentHistory[0]);
                    currentHistory = newHistory;
                }

                var backwardExtrapolate = 0;
                for( int i = 0; i< firstValues.Count; i++)
                {
                    backwardExtrapolate += i % 2 == 0 ? firstValues[i] : -firstValues[i];
                }

                result1 += lastValues.Sum();
                result2 += backwardExtrapolate;
            }

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }
        // x = 2- 0
        // y = 0 - x
        // z = 3 - y
        // w = 10 - z

        // w = 10 - ( 3 - ( 0 - ( 2 -0 )))

        public static void PipeMaze10Part1()
        {
            var stepsToFurthestPipe = 0;
            var input = Inputs.Input10.input.Replace("\n", "").Split("\r");

            (int row, int col) startPos = input.Select((x, i) => (i, x.IndexOf('S'))).First(x => x.Item2 != -1);

            var topPipe = input[startPos.row-1].ElementAt(startPos.col);
            var bottomPipe = input[startPos.row + 1].ElementAt(startPos.col);
            var leftPipe = input[startPos.row].ElementAt(startPos.col-1);

            Move(startPos, FindStartingDirection(), 0);

            Console.WriteLine(stepsToFurthestPipe);

            void Move((int row, int col) curPos, string direction, int steps)
            {
                (int row, int col) newPos = curPos;
                while (stepsToFurthestPipe == 0)
                {
                    var newDirection = "";
                    var moveX = 0;
                    var moveY = 0;

                    switch (input[newPos.row].ElementAt(newPos.col))
                    {
                        case '|':
                            if (direction == "up")
                            {
                                newDirection = direction;
                                moveY = -1;
                            }
                            else if (direction == "down")
                            {
                                newDirection = direction;
                                moveY = 1;
                            }
                            break;
                        case '-':
                            if (direction == "left")
                            {
                                newDirection = direction;
                                moveX = -1;
                            }
                            else if (direction == "right")
                            {
                                newDirection = direction;
                                moveX = 1;
                            }
                            break;
                        case 'L':
                            if (direction == "down")
                            {
                                newDirection = "right";
                                moveX = 1;
                            }
                            else if (direction == "left")
                            {
                                newDirection = "up";
                                moveY = -1;
                            }
                            break;
                        case 'J':
                            if (direction == "down")
                            {
                                newDirection = "left";
                                moveX = -1;
                            }
                            else if (direction == "right")
                            {
                                newDirection = "up";
                                moveY = -1;
                            }
                            break;
                        case '7':
                            if (direction == "right")
                            {
                                newDirection = "down";
                                moveY = 1;
                            }
                            else if (direction == "up")
                            {
                                newDirection = "left";
                                moveX = -1;
                            }
                            break;
                        case 'F':
                            if (direction == "left")
                            {
                                newDirection = "down";
                                moveY = 1;
                            }
                            else if (direction == "up")
                            {
                                newDirection = "right";
                                moveX = 1;
                            }
                            break;
                        case 'S':
                            if (steps == 0)
                            {
                                newDirection = direction;
                                if (direction == "up")
                                {
                                    moveY = -1;
                                }
                                else if (direction == "down")
                                {
                                    moveY = 1;
                                }
                                else if (direction == "left")
                                {
                                    moveX = -1;
                                }
                                else
                                {
                                    moveX = 1;
                                }
                            }
                            else
                            {
                                stepsToFurthestPipe = (int)Math.Ceiling(steps / 2.0);
                                return;
                            }
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }

                    newPos = (newPos.row + moveY, newPos.col + moveX);
                    direction = newDirection;
                    steps++;
                }
            }

            string FindStartingDirection()
            {
                if (topPipe == '|' || topPipe == '7' || topPipe == 'F')
                {
                    return "up";
                }
                else if (bottomPipe == '|' || bottomPipe == 'L' || bottomPipe == 'J')
                {
                    return "down";
                }
                else if (leftPipe == '-' || leftPipe == 'L' || leftPipe == 'F')
                {
                    return "left";
                }
                return null;
            }

        }


        private class Galaxy
        {
            public int x;
            public int y;

            public Galaxy(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int CalcDist(Galaxy other)
            {
                return Math.Abs(x - other.x) + Math.Abs(y - other.y);
            }

            public Galaxy ExpandedCoords(int expandX, int expandY)
            {
                x += expandX;
                y += expandY;
                return this;
            }

            public override string ToString() => x + " " + y;
        }
        private class GalaxyComparer : IEqualityComparer<Galaxy>
        {
            public bool Equals(Galaxy p1, Galaxy p2) => p1.x == p2.x && p1.y == p2.y;
            public int GetHashCode([DisallowNull] Galaxy obj)
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + obj.x.GetHashCode();
                hash = hash * 23 + obj.y.GetHashCode();
                return hash;
            }
        }
        public static void CosmicExpansion11()
        {
            var input = Inputs.Input11.input.Replace("\n", "").Split("\r");

            var comparer = new GalaxyComparer();
            var expandedRows = new Dictionary<Galaxy, int>(comparer);
            var expandedGalaxies = new List<Galaxy>();
            var emptyRows = 0;
            var emptyCols = 0;

            //part 1
            var expansionRate1 = 1;
            // part 2 
            var expansionRate2 = 999999;

            for (int y = 0; y < input.Length; y++)
            {
                var isRowEmpty = true;
                for (int x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] == '#')
                    {
                        var galaxy = new Galaxy(x, y);
                        expandedRows.Add(galaxy, emptyRows);
                        isRowEmpty = false;
                    }
                }

                if (isRowEmpty)
                {
                    emptyRows += expansionRate2;
                }
            }

            for (int x = 0; x < input[0].Length; x++)
            {
                var isColEmpty = true;
                for (int y = 0; y < input.Length; y++)
                {
                    if (input[y][x] == '#')
                    {
                        var galaxy = new Galaxy(x, y);
                        expandedGalaxies.Add(galaxy.ExpandedCoords(emptyCols, expandedRows[galaxy]));
                        isColEmpty = false;
                    }
                }

                if (isColEmpty)
                {
                    emptyCols += expansionRate2;
                }

            }

            long res = 0;
            for (int i = 0; i < expandedGalaxies.Count; i++)
            {
                for (int j = i + 1; j < expandedGalaxies.Count; j++)
                {
                    res += expandedGalaxies[i].CalcDist(expandedGalaxies[j]);
                }
            }

            Console.WriteLine(res);
        }

        public static void HotSpringsRepair12()
        {
            var input = Inputs.Input12.input.Replace("\n", "").Split("\r");
        }

        public static void PointofIncidence13()
        {
            //chat GPT wrote that agregate :D
            var input = Inputs.Input13.input.Replace("\n", "").Split("\r")
                .Aggregate(new List<List<string>> { new List<string>() },
                (acc, x) =>
                {
                    if (string.IsNullOrEmpty(x))
                        acc.Add(new List<string>());
                    else
                        acc.Last().Add(x);

                    return acc;
                })
            .Where(group => group.Any())
            .ToList();

            var result = 0;

            foreach(var pattern in input)
            {
                var hashCodes = new int[pattern.Count];
                var horizontalReflectionFound = false;
                for (int i = 0; i < pattern.Count-1; i++)
                {
                    var reflectionLength = 0;

                    while (CheckCondition())
                    {
                        reflectionLength ++;
                    }
                    
                    if (reflectionLength > 0)
                    {
                        if (i + 1 - reflectionLength == 0 || i + 1 + reflectionLength == pattern.Count)
                        {
                            result += (i + 1) * 100;
                            horizontalReflectionFound = true;
                            break;
                        }
                        else
                        {

                        }
                    }

                    bool CheckCondition()
                    {
                        var minIndex = i - reflectionLength;
                        var maxIndex = i + 1 + reflectionLength;
                        return minIndex >= 0 && maxIndex < pattern.Count && pattern[minIndex] == pattern[maxIndex];
                    }
                }

                if (!horizontalReflectionFound)
                {
                    var transposedPattern = pattern
                        .SelectMany(inner => inner.Select((item, index) => new { item, index }))
                        .GroupBy(i => i.index, i => i.item)
                        .Select(g => g.ToList())
                        .ToList();

                    for (int i = 0; i < transposedPattern.Count - 1; i++)
                    {
                        var reflectionLength = 0;

                        while (CheckCondition())
                        {
                            reflectionLength++;
                        }
                        if (reflectionLength > 0)
                        {
                            if (i + 1 - reflectionLength == 0 || i + 1 + reflectionLength == transposedPattern[i].Count)
                            {
                                result += i + 1;
                                break;
                            }
                            else
                            {

                            }
                        }

                        bool CheckCondition()
                        {
                            var minIndex = i - reflectionLength;
                            var maxIndex = i + 1 + reflectionLength;
                            return minIndex >= 0 && maxIndex < transposedPattern.Count && transposedPattern[minIndex].SequenceEqual(transposedPattern[maxIndex]);
                        }
                    }
                }
            }

            //41859
            Console.WriteLine(result);

        }

        public static void ReflectorDish14()
        {
            var input = Inputs.Input14.input.Replace("\n", "").Split("\r");

            var roundedRocks = new List<int>[input.Length];
            var squareRocks = new List<int>[input.Length];

            for (int i =0; i< roundedRocks.Length; i++)
            {
                roundedRocks[i] = new List<int>();
                squareRocks[i] = new List<int>();
            }


            for (int i = 0; i<input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++) 
                {
                    if(input[i][j]== 'O')
                    {
                        roundedRocks[j].Add(i);
                    }
                    else if(input[i][j] == '#')
                    {
                        squareRocks[j].Add(i);
                    }
                    
                }
            }

            for (int i = 0; i < roundedRocks.Length; i++) 
            {
                var rocksMoved = 0;
                var RowToMoveNextRockTo = Math.Min(roundedRocks[i][0], squareRocks[i][0]);
                var squareRockIndex = 0;

                for (int j = 0; j < roundedRocks[i].Count; j++)
                {
                    if(roundedRocks[i][j] < squareRocks[i][squareRockIndex])
                    {
                        roundedRocks[i][j] = RowToMoveNextRockTo;
                        
                    }
                    else
                    {
                        //squareRockIndex
                    }
                    RowToMoveNextRockTo++;
                }
            }


        }
        
        public static void LensLibraryASCII15Part1()
        {
            var input = Inputs.Input15.input.Split(',');
            var result = 0;

            foreach( var step in input)
            {
                var currentValue = 0;

                foreach(var value in step)
                {
                    var asciiValue = (int)value;
                    currentValue += asciiValue;
                    currentValue *= 17;
                    currentValue %= 256;
                }
                result += currentValue;
            }
            Console.WriteLine(result);
        }

        public static void LensLibraryASCII15Part2()
        {
            var input = Inputs.Input15.input.Split(',');
            var boxes = new List<(string lable , int focalLength)>[256];

            for(int i =0;i < boxes.Length; i++)
            {
                boxes[i] = new List<(string lable, int focalLength)>();
            }

            foreach (var step in input)
            {
                var currentValue = 0;
                var lable = string.Join("", step.TakeWhile(x => x != '-' && x != '='));

                foreach (var value in lable)
                {
                    var asciiValue = (int)value;
                    currentValue += asciiValue;
                    currentValue *= 17;
                    currentValue %= 256;
                }
                var boxNumber = currentValue;

                var operation = step.ElementAt(lable.Count());
                if(operation == '-')
                {
                    boxes[boxNumber].RemoveAll(x => x.lable == lable);
                }
                else
                {
                    var focalLength = (int)Char.GetNumericValue(step.ElementAt(lable.Count() + 1));
                    var index = boxes[boxNumber].FindIndex(0, x => x.lable == lable);
                    if (index != -1)
                    {
                        boxes[boxNumber][index] = (lable, focalLength);
                    }
                    else
                    {
                        boxes[boxNumber].Add((lable, focalLength));
                    }
                }
            }

            var result = 0;
            for (int i =0; i < boxes.Length; i++)
            {
                for( int j = 0; j < boxes[i].Count; j++)
                {
                    var focusingPower = (i + 1) * (j + 1) * boxes[i][j].focalLength;
                    result += focusingPower;
                }
            }
            Console.WriteLine(result);
        }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            None
        }

        public class LightBeam
        {
            public (int x, int y) position;
            public Direction direction;

            public LightBeam((int x, int y) position, Direction direction)
            {
                this.position.x = position.x;
                this.position.y = position.y;
                this.direction = direction;
            }

            public override string ToString() => $"{position.x} {position.y} - {direction.ToString()}";
            public override bool Equals(object obj)
            {
                var other = (obj as LightBeam);
                return other.position == position && other.direction == direction;
            }
            public override int GetHashCode()
            {
                var hashCode = HashCode.Combine(position, direction);
                return hashCode;
            }
        }

        public static int EnergizedTiles16Part1(LightBeam startingBeam = null)
        {
            var input = Inputs.Input16.input.Replace("\n", "").Split("\r");

            var lightBeams = new HashSet<LightBeam>();
            var newLightBeams = new HashSet<LightBeam>();
            var lightBeamsToRemove = new List<LightBeam>();
            if (startingBeam == null)
            {
                lightBeams.Add(new LightBeam((-1, 0), Direction.Right));
            }
            else
            {
                lightBeams.Add(startingBeam);
            }

            var energizedCells = new HashSet<LightBeam>();

            while (lightBeams.Count > 0) 
            {
                for( int i =0; i < lightBeams.Count; i++)
                {
                    var lightBeam = lightBeams.ElementAt(i);
                    var newPos = TakeStep(lightBeam);
                    if (newPos.x >= 0 && newPos.x < input[0].Length && newPos.y >= 0 && newPos.y < input.Length)
                    {
                        var newDirections = CalcNextDirection(input[newPos.y].ElementAt(newPos.x), lightBeam.direction);
                        var newLightBeam = new LightBeam(newPos, newDirections.direction);
                        if(energizedCells.Add(newLightBeam))
                        {
                            newLightBeams.Add(newLightBeam);
                            lightBeamsToRemove.Add(lightBeam);

                            if (newDirections.direction2 != Direction.None)
                            {
                                var newLightBeamFromSplit = new LightBeam(newPos, newDirections.direction2);
                                if (energizedCells.Add(newLightBeamFromSplit))
                                {
                                    newLightBeams.Add(newLightBeamFromSplit);
                                }
                                else
                                {
                                    lightBeamsToRemove.Add(lightBeam);
                                }
                            }
                        }
                        else
                        {
                            lightBeamsToRemove.Add(lightBeam);
                        }
                    }
                    else
                    {
                        lightBeamsToRemove.Add(lightBeam);
                    }
                }

                lightBeams.RemoveWhere(lb => lightBeamsToRemove.Contains(lb));
                foreach( var newLightbeam in newLightBeams)
                {
                    if (!lightBeams.Contains(newLightbeam)){
                        lightBeams.Add(newLightbeam);
                    }
                }
                lightBeamsToRemove.Clear();
                newLightBeams.Clear();
            }

            var result = energizedCells.GroupBy(x => x.position).Count();
            Console.WriteLine(result);

            return result;

            (int x, int y) TakeStep(LightBeam lightBeam)
            {
                switch (lightBeam.direction)
                {
                    case Direction.Up:
                        return (lightBeam.position.x, lightBeam.position.y - 1);
                        break;
                    case Direction.Down:
                        return (lightBeam.position.x, lightBeam.position.y + 1);
                        break;
                    case Direction.Left:
                        return (lightBeam.position.x - 1, lightBeam.position.y);
                        break;
                    case Direction.Right:
                        return (lightBeam.position.x + 1, lightBeam.position.y);
                        break;
                    default:
                        return (-1, -1);
                        break;
                }
            }

            (Direction direction, Direction direction2) CalcNextDirection(char tile , Direction currDirection)
            {
                Direction newDirection = currDirection;
                Direction newDirection2 = Direction.None;

                switch (tile)
                {
                    case '.':
                        break;
                    case '/':
                        if (currDirection == Direction.Up)
                        {
                            newDirection = Direction.Right;
                        }
                        else if (currDirection == Direction.Down)
                        {
                            newDirection = Direction.Left;
                        }
                        else if (currDirection == Direction.Left)
                        {
                            newDirection = Direction.Down;
                        }
                        else if (currDirection == Direction.Right)
                        {
                            newDirection = Direction.Up;
                        }
                        break;
                    case '\\':
                        if (currDirection == Direction.Up)
                        {
                            newDirection = Direction.Left;
                        }
                        else if (currDirection == Direction.Down)
                        {
                            newDirection = Direction.Right;
                        }
                        else if (currDirection == Direction.Left)
                        {
                            newDirection = Direction.Up;
                        }
                        else if (currDirection == Direction.Right)
                        {
                            newDirection = Direction.Down;
                        }
                        break;
                    case '|':
                        if (currDirection == Direction.Left || currDirection == Direction.Right)
                        {
                            newDirection = Direction.Up;
                            newDirection2 = Direction.Down;
                        }
                        break;
                    case '-':
                        if (currDirection == Direction.Up || currDirection == Direction.Down)
                        {
                            newDirection = Direction.Left;
                            newDirection2 = Direction.Right;
                        }
                        break;
                    default:
                        break;
                }

                return (newDirection, newDirection2);
            }
        }

        public static void EnergizedTiles16Part2()
        {
            var input = Inputs.Input16.input.Replace("\n", "").Split("\r");
            var height = input.Count();
            var weight = input[0].Count();

            var currentMaxEnergizedCells = 0;

            for( int i =0; i < height; i++)
            {
                currentMaxEnergizedCells = Math.Max(currentMaxEnergizedCells,
                    Math.Max(EnergizedTiles16Part1(new LightBeam((-1, i), Direction.Right)), EnergizedTiles16Part1(new LightBeam((weight, i), Direction.Left))));
            }

            for (int i = 0; i < weight; i++)
            {
                currentMaxEnergizedCells = Math.Max(currentMaxEnergizedCells,
                    Math.Max(EnergizedTiles16Part1(new LightBeam((i, -1), Direction.Down)), EnergizedTiles16Part1(new LightBeam((i, height), Direction.Up))));
            }

            Console.WriteLine(currentMaxEnergizedCells);
        }

        public class HeatLoss
        {
            public (int x, int y) position;
            public int totalHeatLost;

            public HeatLoss()
            {

            }

            public HeatLoss((int x, int y) position, int totalHeatLoss, Direction direction)
            {
                this.position.x = position.x;
                this.position.y = position.y;
                this.totalHeatLost = totalHeatLoss;
            }

            public override string ToString() => $"{position.x} {position.y} - {totalHeatLost}";
            public override bool Equals(object obj)
            {
                var other = (obj as HeatLoss);
                return other.position == position && other.totalHeatLost == totalHeatLost;
            }
            public override int GetHashCode()
            {
                var hashCode = position.GetHashCode();
                return hashCode;
            }
        }

        public static void ClumsyCruciblesAndHeatLoss17Part1()
        {
            var input = Inputs.Input17.input.Replace("\n", "").Split("\r");

            var allPathsMinHeatLoss = new Dictionary<(int x, int y), int>();
        }
    }
}
