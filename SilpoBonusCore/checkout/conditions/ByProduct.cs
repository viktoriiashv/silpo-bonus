using System;
using System.Collections.Generic;
using System.Text;
public class ByProduct : ICondition
{
    Product product;
    public ByProduct(Product product)
    {
        this.product = product;
    }

    public bool DoesSatisfyCondition(Check check)
    {
        return (check.getProductCost(product) != 0);
    }
}

