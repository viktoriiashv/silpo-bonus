using System;
using Xunit;
public class CheckoutServiceTest {

private Product milk_7;
    private CheckoutService checkoutService;
    private Product bread_3;

    
    public void TestInitialize() {
        checkoutService = new CheckoutService();
        checkoutService.openCheck();
        milk_7 = new Product(7, "Milk");
        bread_3 = new Product(3, "Bread");
    }
    

    [Fact]
    void closeCheck__withOneProduct() {
        TestInitialize();
        checkoutService.addProduct(milk_7);
        Check check = checkoutService.closeCheck();
        Assert.Equal(check.getTotalCost(), 7);
    }

    [Fact]
    void closeCheck__withTwoProducts() {
        TestInitialize();
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        Check check = checkoutService.closeCheck();
        Assert.Equal(check.getTotalCost(), 10);
    }

    [Fact]
    void addProduct__whenCheckIsClosed__opensNewCheck() {
        TestInitialize();
        checkoutService.addProduct(milk_7);
        Check milkCheck = checkoutService.closeCheck();
        Assert.Equal(milkCheck.getTotalCost(), 7);

        checkoutService.addProduct(bread_3);
        Check breadCheck = checkoutService.closeCheck();
        Assert.Equal(breadCheck.getTotalCost(), 3);
    }
    [Fact]
    void closeCheck__calcTotalPoints() {
        TestInitialize();
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        Check check = checkoutService.closeCheck();
        Assert.Equal(check.getTotalCost(), 10);
    }

    [Fact]
    void useOffer__addOfferPoints() {
      TestInitialize();
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);

        checkoutService.useOffer(new AnyGoodsOffer(6, 2));
        Check check = checkoutService.closeCheck();
        Assert.Equal(check.getTotalPoints(), 12);
        
    }

    [Fact]
    void useOffer__whenCostLessThanRequired__doNothing() {
        TestInitialize();
        checkoutService.addProduct(bread_3);

        checkoutService.useOffer(new AnyGoodsOffer(6, 2));
        Check check = checkoutService.closeCheck();
        Assert.Equal(check.getTotalPoints(), 3);
    }


}