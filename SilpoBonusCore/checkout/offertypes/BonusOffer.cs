using System;
using System.Collections.Generic;
using System.Text;


public class BonusOffer : Offer
{
    IReward reward;
    public BonusOffer(DateTime expirationDate, ICondition condition, IReward reward) : base(expirationDate, condition)
    {
        this.reward = reward;
    }

    public override void Apply(Check check)
    {
       check.addPoints(reward.CalculatePoint(check));
    }
}

