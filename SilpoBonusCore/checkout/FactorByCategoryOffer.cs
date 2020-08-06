using System;
using System.Linq;
public class FactorByCategoryOffer : Offer
{
    public Category category;
    public int factor;

    public FactorByCategoryOffer(Category category, int factor, DateTime expirationDate) : base(expirationDate)
    {
        this.category = category;
        this.factor = factor;
    }

    public override bool DoesSatisfyCondition(Check check)
    {
        if (check.getCostByCategory(category) != 0)
        {
            return true;
        }
        else
        {
            Console.WriteLine(this.category + " is not in check so there no double points");
            return false;

        }


    }
    public override int CalcPoints(Check check)
    {
        int points = check.getCostByCategory(category);
        return (points * (factor - 1));

    }


}
