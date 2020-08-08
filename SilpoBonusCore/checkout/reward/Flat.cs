using System;
using System.Collections.Generic;
using System.Text;
public class Flat : IReward
{
    int amount;

    public Flat(int amount)
    {
        this.amount = amount;
    }

    public int CalculatePoint(Check check)
    {
        return amount;
    }
}

