
using System;

public class AnyGoodsOffer : Offer
{
    public int totalCost;
    public int points;

    public AnyGoodsOffer(int totalCost, int points, DateTime expirationDate) : base(expirationDate)
    {
        this.totalCost = totalCost;
        this.points = points;
    }

    public override bool DoesSatisfyCondition(Check check)
    {
        return totalCost <= check.getTotalCost();
    }
    public override int CalcPoints(Check check)
    {
        return points;
    }
}
