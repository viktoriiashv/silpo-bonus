using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class ByCategory : ICondition
{
    Category category;
    public ByCategory(Category category)
    {
        this.category = category;
    }

    public bool DoesSatisfyCondition(Check check)
    {
        return check.getCategoryCost(category) != 0;
    }
}

