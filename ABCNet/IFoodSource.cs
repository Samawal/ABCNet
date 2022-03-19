using System;
using System.Collections.Generic;
using System.Text;

namespace ABCNet
{
    public interface IFoodSource
    {
        //T Data { get; set; }
        int TrialsCount { get; set; }
        double Fitness { get; set; }
        bool IsAbandoned { get; set; }
        double CalculateDistance(IFoodSource other);
        double CalculateFitness(Bee bee);
    }
}