using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Gift : IDiscountRule
{
    int giftCost;
    Product product;
    public Gift(int giftCost, Product product)
    {
        this.giftCost = giftCost;
        this.product = product;

    }
    public int CalculateDiscount(Check check)
    {
        return check.getProductCost(product) - giftCost;
    }
}
