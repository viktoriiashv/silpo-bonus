using System;
using System.Collections.Generic;
using System.Text;


public class Percent : IDiscountRule
{
    int percent;
    Product product;
    public Percent(int percent, Product product)
    {
        this.percent = percent;
        this.product = product;
    }
    public int CalculateDiscount(Check check)
    {
        return check.getProductCost(product) * percent / 100; // change to getcostbyproduct in case we need apply offer for all matching products
    }

}

