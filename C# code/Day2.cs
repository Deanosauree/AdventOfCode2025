// See https://aka.ms/new-console-template for more information
//test
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

string finalInput = "959516-995437,389276443-389465477,683-1336,15687-26722,91613-136893,4-18,6736-12582,92850684-93066214,65-101,6868676926-6868700146,535033-570760,826141-957696,365650-534331,1502-2812,309789-352254,79110404-79172400,18286593-18485520,34376-65398,26-63,3333208697-3333457635,202007-307147,1859689-1936942,9959142-10053234,2318919-2420944,5142771457-5142940464,1036065-1206184,46314118-46413048,3367-6093,237-481,591751-793578";
string testInput = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

string[] thisInput = finalInput.Split(',');

Int64 Part1() {
    Int64 finalNumber = 0;
    foreach (string range in thisInput)
    {
        string[] split = range.Split("-");
        Int64 rangeStart = Int64.Parse(split[0]);
        Int64 rangeEnd = Int64.Parse(split[1]);
        Int64 currentNumber = rangeStart;
        while (currentNumber <= rangeEnd)
        {
            string currentToString = currentNumber.ToString();
            if (currentToString.Substring(0, currentToString.Length / 2) == currentToString.Substring(currentToString.Length / 2))
            {
                finalNumber += currentNumber;
            }
            currentNumber++;
        }
    }
    return finalNumber;
}
Int64 Part2()
{
    Int64 finalNumber = 0;
    foreach (string range in thisInput)
    {
        string[] split = range.Split("-");
        Int64 rangeStart = Int64.Parse(split[0]);
        Int64 rangeEnd = Int64.Parse(split[1]);
        Int64 currentNumber = rangeStart;
        
        while (currentNumber <= rangeEnd)
        {
            string currentToString = currentNumber.ToString();
            bool isRepeating = CheckIsRepeating(currentToString);
            
            if (isRepeating) 
            {
                finalNumber += currentNumber;

            }
            currentNumber++;


            
        }
    }
    return finalNumber;
}

bool CheckIsRepeating(string input)
{
    bool repeats = false;
    for (int i = 0; i <= (input.Length/2)-1; i++)
    {
        int stringLength = i + 1;
        List<String> myStrings = new List<string> { };
        for (int j = 0; j < (input.Length); j+=stringLength)
        {
            if (j + stringLength >= input.Length)
            {
                myStrings.Add(input.Substring(j));
            }
            else
            {
                myStrings.Add(input.Substring(j, stringLength));
            }
        }
        bool thisRepeats = true;
        for (int j = 0; j < (myStrings.Count - 1); j++)
        {
            if (!(myStrings[j] == myStrings[j+1]))
            {
                thisRepeats = false;
            }
        }
        repeats = thisRepeats;
        if (repeats)
        {
            break;
        }

    }

    return repeats;
}
Console.WriteLine(Part1());
Console.WriteLine(Part2());