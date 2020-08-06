
public class AnyGoodsOffer : Offer {
    public int totalCost;
    public int points;

    public AnyGoodsOffer(int totalCost, int points) {
        this.totalCost = totalCost;
        this.points = points;
    }

      public override void apply(Check check) {
        if (totalCost <= check.getTotalCost())
             check.addPoints(points);
    }
}
