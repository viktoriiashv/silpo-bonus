using System;
using Xunit;
public class CheckoutServiceTest {

private Product milk_7;
    private CheckoutService checkoutService;
    private Product bread_3;

    
    public CheckoutServiceTest() {
        checkoutService = new CheckoutService();
        checkoutService.openCheck();
        milk_7 = new Product(7, "Milk", Category.MILK, Trade.Silpo);
        bread_3 = new Product(3, "Bread");
    }


    [Fact]
    void closeCheck__withOneProduct() {
        checkoutService.addProduct(milk_7);
        Check check = checkoutService.closeCheck();
        Assert.Equal(7, check.getTotalCost());
    }

    [Fact]
    void closeCheck__withTwoProducts() {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        Check check = checkoutService.closeCheck();
        Assert.Equal(10, check.getTotalCost());
    }

    [Fact]
    void addProduct__whenCheckIsClosed__opensNewCheck() {
        checkoutService.addProduct(milk_7);
        Check milkCheck = checkoutService.closeCheck();
        Assert.Equal(7, milkCheck.getTotalCost());

        checkoutService.addProduct(bread_3);
        Check breadCheck = checkoutService.closeCheck();
        Assert.Equal(3, breadCheck.getTotalCost());
    }
    [Fact]
    void closeCheck__calcTotalPoints() {
        
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        Check check = checkoutService.closeCheck();
        Assert.Equal(10, check.getTotalCost());
    }

    [Fact]
    void useOffer__addOfferPoints() {
      
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);

        checkoutService.useOffer(new AnyGoodsOffer(6, 2, new DateTime(2020, 8, 10)));
        Check check = checkoutService.closeCheck();
        Assert.Equal(12, check.getTotalPoints());
        
    }

    [Fact]
    void useOffer__whenCostLessThanRequired__doNothing() {
        checkoutService.addProduct(bread_3);

        checkoutService.useOffer(new AnyGoodsOffer(6, 2, new DateTime(2020,8,10)));
        Check check = checkoutService.closeCheck();
        Assert.Equal(3, check.getTotalPoints());
    }
    
    [Fact]
    void useOffer__factorByCategory() {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);

        checkoutService.useOffer(new FactorByCategoryOffer(Category.MILK, 2, new DateTime(2020, 8, 10)));
        Check check = checkoutService.closeCheck();
        Assert.Equal(31, check.getTotalPoints());
        
        }

    [Fact]
    void useOffer__ExpiredDate()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);

        checkoutService.useOffer(new FactorByCategoryOffer(Category.MILK, 4, new DateTime(2020, 8, 1)));
        Check check = checkoutService.closeCheck();
        Assert.Equal(17, check.getTotalPoints());

    }

    [Fact]
    public void useOffer_BeforeCheckCloseFactorByCategoryOffer()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);

        checkoutService.useOffer(new FactorByCategoryOffer(Category.MILK, 2, new DateTime(2020, 8, 10)));

        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        Check check = checkoutService.closeCheck();
        Assert.Equal(34, check.getTotalPoints());
    }

    [Fact]
    public void useOffer_BeforeCheckCloseAnyGoodsOffer()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);

        checkoutService.useOffer(new AnyGoodsOffer(10, 5, new DateTime(2020, 8, 10)));

        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);

        checkoutService.useOffer(new AnyGoodsOffer(15, 5, new DateTime(2020, 8, 10)));
        Check check = checkoutService.closeCheck();
        Assert.Equal(30, check.getTotalPoints());
    }

    [Fact]
    public void useOffer_ByTrade()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);

        checkoutService.useOffer(new ByTrade(Trade.Silpo, 10, new DateTime(2020, 8, 10)));
        Check check = checkoutService.closeCheck();
        Assert.Equal(20, check.getTotalPoints());
    }



}