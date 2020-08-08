using System;
using System.Collections.Generic;
using System.Text;


public class ByTotalCost : ICondition
{
    int neededTotalCost;
    public ByTotalCost(int neededTotalCost) //: base(expirationDate)
    {
        this.neededTotalCost = neededTotalCost;
    }

    public bool DoesSatisfyCondition(Check check) //should be bool
    {
        return (neededTotalCost <= check.getTotalCost());
    }
}

