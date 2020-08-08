using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class ByTrade : ICondition
{
    Trade trade;
    public ByTrade(Trade trade)
    {
        this.trade = trade;
    }

    public bool DoesSatisfyCondition(Check check)
    {
        return check.getTradeCost(trade) != 0;
    }
}

