using System;
public abstract class Offer
{
    private DateTime expirationDate;
    public Offer(DateTime expirationDate)
    {
        this.expirationDate = expirationDate;
    }
    public DateTime ExpirationDate
    {
        get
        {
            return expirationDate;
        }
        set
        {
            expirationDate = value;
        }
    }

    //step methods
    public abstract bool DoesSatisfyCondition(Check check);
    public abstract int CalcPoints(Check check);
    public bool IsOfferValid()
    {
        if (expirationDate > DateTime.Now)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void TryToApply(Check check) //template method, that contains functions calls
    {
        if (IsOfferValid()) //step1
        {
            if (DoesSatisfyCondition(check)) //step2
            {
                check.addPoints(CalcPoints(check)); //step3
            }

        }
    }
}
