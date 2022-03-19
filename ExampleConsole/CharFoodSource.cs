using ABCNet;
using System;

namespace ExampleConsole;

internal class CharFoodSource : IFoodSource
{
    public CharFoodSource(char @char)
    {
        Char = @char;
    }

    public char Char { get; set; }
    public int TrialsCount { get; set; }
    public double Fitness { get; set; }
    public bool IsAbandoned { get; set; }

    public double CalculateDistance(IFoodSource other)
    {
        return Math.Abs(Char - ((CharFoodSource)other).Char);
    }

    public double CalculateFitness(Bee bee)
    {
        return 'z' - Char;
    }

    public override string ToString()
    {
        return Char.ToString();
    }
}
