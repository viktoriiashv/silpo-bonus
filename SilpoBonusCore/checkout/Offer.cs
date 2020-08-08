using System;
public abstract class Offer
{
    private DateTime expirationDate;
    private ICondition condition;
    public Offer(DateTime expirationDate, ICondition condition)
    {
        this.expirationDate = expirationDate;
        this.condition = condition;
    }
    public bool IsOfferValid()
    {
        return expirationDate > DateTime.Now;
    }
    
    public abstract void Apply(Check check);

    public void useOffer(Check check)
    {
        if (IsOfferValid() && condition.DoesSatisfyCondition(check))
        {
            Apply(check);
        }
    }
}
