using System;
using System.Collections.Generic;
using System.Text;


public class ByTrade : Offer
{
    public Trade trade;
    public int points;

    public ByTrade(Trade trade, int points, DateTime expirationDate) : base(expirationDate)
    {
        this.trade = trade;
        this.points = points;
    }

    public override bool DoesSatisfyCondition(Check check)
    {
        if (check.getCostByTrade(trade) != 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public override int CalcPoints(Check check)
    {
        return points;
    }

}

