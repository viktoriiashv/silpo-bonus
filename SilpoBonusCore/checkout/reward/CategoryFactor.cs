using System;
using System.Collections.Generic;
using System.Text;
public class CategoryFactor : IReward
{
    int factor;
    Category category;

    public CategoryFactor(int factor, Category category)
    {
        this.factor = factor;
        this.category = category;
    }

    public int CalculatePoint(Check check)
    {
        return check.getCostByCategory(category) * (factor - 1);
    }
}

