// Lab 3
// Student name:
// Student number:

using System;
using System.Collections.Generic;

Console.WriteLine("CPEN223 Lab 3");

bool actual = SensorAnalyzer.IsUsableReading(21.5, 0.0, 50.0);
Console.WriteLine($"Expected: True, Actual: {actual}");


//Testing: Write some test cases to test well all methods you are to implement    
//         This is to demonstrates what test cases you have considered
//TODO 
// bool actual = SensorAnalyzer.IsUsableReading(21.5, 0.0, 50.0);
// Console.WriteLine($"Expected: True, Actual: {actual}");


//end Testing code

//Do not change the program skeleton
public static class SensorAnalyzer
{
    public static bool IsUsableReading(
        double reading, double minimum, double maximum)
    {
        throw new NotImplementedException();
    }

    public static List<double> CleanReadings(
        IReadOnlyList<double> readings, double minimum, double maximum)
    {
        throw new NotImplementedException();
    }

    public static bool ContainsApproximately(
        IReadOnlyList<double> readings, double target, double tolerance)
    {
        throw new NotImplementedException();
    }

    public static List<double> MovingAverage(
        IReadOnlyList<double> readings, int windowSize)
    {
        throw new NotImplementedException();
    }
}
