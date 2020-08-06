using System;
public class Product
{
    public int price;
    public string name;
    public Category category;
    public Product(int price, String name, Category category)
    {
        this.price = price;
        this.name = name;
        this.category = category;
    }

    public Product(int price, string name) : this(price, name, 0)
    {
        this.price = price;
        this.name = name;
    }


}
