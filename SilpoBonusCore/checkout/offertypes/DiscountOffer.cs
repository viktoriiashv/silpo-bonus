using System;
using System.Collections.Generic;
using System.Text;

public class DiscountOffer : Offer
{
    IDiscountRule discountRule;

    public DiscountOffer(DateTime expirationDate, ICondition condition, IDiscountRule discountRule) : base(expirationDate, condition)
    {
        this.discountRule = discountRule;
    }

    public override void Apply(Check check)
    {
        check.SumOfDiscount += discountRule.CalculateDiscount(check);
       
    }
}

