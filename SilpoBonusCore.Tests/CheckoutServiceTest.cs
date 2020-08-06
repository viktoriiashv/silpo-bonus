using System;
using Xunit;
public class CheckoutServiceTest {

    [Fact]
    void closeCheck__withOneProduct() {
        CheckoutService checkoutService = new CheckoutService();
        checkoutService.openCheck();

        checkoutService.addProduct(new Product(7, "Milk"));
        Check check = checkoutService.closeCheck();

        Assert.Equal(check.getTotalCost(), 7);
    }

    [Fact]
    void closeCheck__withTwoProducts() {
        CheckoutService checkoutService = new CheckoutService();
        checkoutService.openCheck();

        checkoutService.addProduct(new Product(7, "Milk"));
        checkoutService.addProduct(new Product(3, "Bread"));
        Check check = checkoutService.closeCheck();
        Assert.Equal(check.getTotalCost(), 10);
    }
}
