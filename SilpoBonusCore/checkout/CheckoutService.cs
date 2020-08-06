using System;
using System.Collections;
using System.Collections.Generic;
public class CheckoutService
{

    private Check check;

    public void openCheck()
    {
        check = new Check();
    }

    public void addProduct(Product product)
    {
        if (check == null)
        {
            openCheck();
        }
        check.addProduct(product);
    }


    public Check closeCheck()
    {   
        ApplyOffers();
        Check closedCheck = check;
        check = null;
        return closedCheck;

    }

    public void useOffer(Offer offer)
    {
        check.Offers.Add(offer);
        //offer.TryToApply(check);
    }

    public void ApplyOffers() {
        foreach (Offer offer in check.Offers)
        {
            bool isSucceed = offer.TryToApply(check);
            if (!isSucceed) //in case we wont print or return something
            {   
                Console.WriteLine(offer.GetType() + "Can't be used");
            }
        }
    }
}

