using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
public class Check
{
    public List<Product> products { get; set; } = new List<Product>();

    private int points = 0;
    public int SumOfDiscount { get; set; } = 0;
    public int getTotalCost()
    {
        int totalCost = 0;
        foreach (Product product in this.products)
        {
            totalCost += product.price;
        }
        totalCost -= SumOfDiscount;
        return totalCost;
    }
    internal void addProduct(Product product)
    {
        products.Add(product);
    }
    public int getTotalPoints()
    {
        return getTotalCost() + points;
    }

    internal void addPoints(int points)
    {
        this.points += points;
    }
    internal int getCostByCategory(Category category)
    {
        return products
            .Where(product => product.category.Equals(category))
            .Sum(product => product.price);
    }

    internal int getCostByTrade(Trade trade)
    {
        return products
            .Where(product => product.trade.Equals(trade))
            .Sum(product => product.price);
    }

    internal int getCostByProduct(Product product)
    {
        return products
            .Where(p => p.Equals(product))
            .Sum(p => p.price);

    }

    internal int getCategoryCost(Category category)
    {
        return products
            .Where(product => product.category.Equals(category)).First().price;
    }

    internal int getTradeCost(Trade trade)
    {
        return products
            .Where(product => product.trade.Equals(trade)).First().price;
    }

    internal int getProductCost(Product product)
    {
        return products.Where(p => p.Equals(product)).First().price;
    }




}
