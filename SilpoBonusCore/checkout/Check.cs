using System.Collections;
using System.Collections.Generic;
public class Check {
    private List<Product> products = new List<Product>();
    private int points = 0;


    public int getTotalCost() {
        int totalCost = 0;
        foreach (Product product in this.products) {
            totalCost += product.price;
        }
        return totalCost;
    }
    internal void addProduct(Product product) {
        products.Add(product);
    }
    public int getTotalPoints() {
        return getTotalCost() + points;
    }

    internal void addPoints(int points) {
        this.points += points;
    }


}
