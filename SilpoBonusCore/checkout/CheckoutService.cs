using System;
using System.Collections;
using System.Collections.Generic;
public class CheckoutService
{

    private Check check ;
    public List<Offer> Offers { get; set; } = new List<Offer>();

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
        Offers.Add(offer);
    }

    public void ApplyOffers()
    {
        foreach (Offer offer in Offers)
        {
            offer.useOffer(check);
        }
    }
}

