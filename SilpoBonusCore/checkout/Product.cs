using System;
public class Product
{
    public int price;
    public string name;
    public Category category;
    public Trade trade;
    public Product(int price, String name, Category category, Trade trade)
    {
        this.price = price;
        this.name = name;
        this.category = category;
        this.trade = trade;
    }
    public Product(int price, string name, Trade trade) : this(price, name, 0, trade)
    {
        this.price = price;
        this.name = name;
        this.trade = trade;
    }
    public Product(int price, string name, Category category) : this(price, name, category, 0)
    {
        this.price = price;
        this.name = name;
        this.category = category;
    }

    public Product(int price, string name) : this(price, name, 0, 0)
    {
        this.price = price;
        this.name = name;
    }

    public override bool Equals(Object obj)
    {

        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Product p = (Product)obj;
            return (name == p.name) && (price == p.price) && (trade == p.trade) && (category == p.category);
        }
    }

}
