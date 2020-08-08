using System;
using System.Collections.Generic;
using System.Text;


public interface IDiscountRule
{
    int CalculateDiscount(Check check);
}

