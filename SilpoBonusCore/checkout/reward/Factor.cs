using System;
using System.Collections.Generic;
using System.Text;

public class Factor : IReward
{
    int factor;


    public Factor(int factor)
    {
        this.factor = factor;

    }

    public int CalculatePoint(Check check)
    {
        return check.getTotalCost() * (factor - 1);
    }
}

