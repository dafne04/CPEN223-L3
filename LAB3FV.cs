// Lab 3
// Student name: Dafne Naz Birsay
// Student number: 89220925

using System;
using System.Collections.Generic;

Console.WriteLine("CPEN223 Lab 3");

//Testing: Write some test cases to test well all methods you are to implement    
//         This is to demonstrates what test cases you have considered
//TODO 
// bool actual = SensorAnalyzer.IsUsableReading(21.5, 0.0, 50.0);
// Console.WriteLine($"Expected: True, Actual: {actual}");
Console.WriteLine("\n--- Testing IsUsableReading ---");
bool actual = SensorAnalyzer.IsUsableReading(21.5, 0.0, 50.0);
Console.WriteLine($"Expected: True, Actual: {actual}");
Console.WriteLine($"Expected: False, Actual: {SensorAnalyzer.IsUsableReading(-2.0, 0.0, 50.0)}");
Console.WriteLine($"Expected: False, Actual: {SensorAnalyzer.IsUsableReading(double.NaN, 0.0, 50.0)}");

Console.WriteLine("\n--- Testing CleanReadings ---");
double[] readingsArr = { 20.0, double.NaN, 20.5, double.PositiveInfinity, -5.0, 21.0 };
List<double> cleaned = SensorAnalyzer.CleanReadings(readingsArr, 0.0, 50.0);
Console.WriteLine($"Expected: 20, 20.5, 21 | Actual: {string.Join(", ", cleaned)}");

Console.WriteLine("\n--- Testing ContainsApproximately ---");
List<double> values = new() { 0.1 + 0.2 };
Console.WriteLine($"Expected: True, Actual: {SensorAnalyzer.ContainsApproximately(values, 0.3, 1e-12)}");

Console.WriteLine("\n--- Testing MovingAverage ---");
List<double> ma1 = new() { 1.0, 2.0, 3.0, 4.0 };
Console.WriteLine($"Expected: 1.5, 2.5, 3.5 | Actual: {string.Join(", ", SensorAnalyzer.MovingAverage(ma1, 2))}");

Console.WriteLine("\n--- Test: Empty collection ---");
List<double> emptyList = new();
List<double> cleanEmpty = SensorAnalyzer.CleanReadings(emptyList, 0, 100);
List<double> maEmpty = SensorAnalyzer.MovingAverage(emptyList, 3);
Console.WriteLine($"CleanReadings (Empty): Expected Count 0, Actual Count: {cleanEmpty.Count}");
Console.WriteLine($"MovingAverage (Empty): Expected Count 0, Actual Count: {maEmpty.Count}");


//end Testing code

//Do not change the program skeleton
public static class SensorAnalyzer
{
    public static bool IsUsableReading(
        double reading, double minimum, double maximum)
    {
       //checks the value for exceptions and prints an argument exception 
        if(minimum > maximum || !double.IsFinite(minimum) || !double.IsFinite(maximum)){
        throw new ArgumentException("Not usable sensor reading");
    
    }
    //checks for values usable for reading
    if(double.IsFinite(reading) && reading <= maximum && reading >= minimum){
        return true;
    }
    
    return false;
    }

    public static List<double> CleanReadings(
        IReadOnlyList<double> readings, double minimum, double maximum)
    {
        //checks if the list is empty and prints a message if so
        if(readings == null){
            throw new ArgumentException("Couldn't collect readings");
        }
        //checks for exception vales 
        if(minimum > maximum || !double.IsFinite(minimum) || !double.IsFinite(maximum)){
            throw new ArgumentException("Couldn't collect readings");
        }
        
        //returns a new list after not modifying input collection
        var newList = new List<double>();
        
        foreach (double r in readings)
        {
            if (IsUsableReading(r, minimum, maximum)){
                newList.Add(r);
            }
        }
        return newList;
    
    }

    public static bool ContainsApproximately(
        IReadOnlyList<double> readings, double target, double tolerance)
    {
        //checks for exceptions 
        if(readings == null || !double.IsFinite(target) || !double.IsFinite(tolerance) || tolerance < 0.0){
            throw new ArgumentException("Couldn't find the value");
        }
        // returns true if the collection contains at least one finite value 
        foreach(double r in readings){
            if(double.IsFinite(r) && Math.Abs(r - target) <= tolerance){
                 return true;
            }

        }
        return false;
       
    }

    public static List<double> MovingAverage(
        IReadOnlyList<double> readings, int windowSize)
    {
        //checks if the list is empty
        if (readings == null){
            throw new ArgumentException("Readings collection cannot be null.");
        }
        //checks for the conditions to calculate mean 
        if (windowSize <= 0)
        {
            throw new ArgumentException("windowSize must be greater than zero.");
        }

        foreach (double r in readings){
            if (!double.IsFinite(r)){
                throw new ArgumentException("Readings contain NaN or infinite values.");
            }
        }

        if (windowSize > readings.Count){
            return new List<double>();
        }
        
        //calculates mean and returns that value 
        List<double> result = new List<double>();
        for (int i = 0; i <= readings.Count - windowSize; i++){
            double sum = 0.0;
            for (int j = i; j < i + windowSize; j++){
                sum += readings[j];
            }
            result.Add(sum / windowSize);
        }

        return result;
    }
}
       
    
