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

    [Fact]
    void addProduct__whenCheckIsClosed__opensNewCheck() {
        CheckoutService checkoutService = new CheckoutService();

        checkoutService.addProduct(new Product(7, "Milk"));
        Check milkCheck = checkoutService.closeCheck();
        Assert.Equal(milkCheck.getTotalCost(), 7);

        checkoutService.addProduct(new Product(3, "Bred"));
        Check breadCheck = checkoutService.closeCheck();
        Assert.Equal(breadCheck.getTotalCost(), 3);
    }

}
