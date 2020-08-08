using System;
using Xunit;
public class CheckoutServiceTest
{

    private Product milk_7;
    private CheckoutService checkoutService;
    private Product bread_3;


    public CheckoutServiceTest()
    {
        checkoutService = new CheckoutService();
        checkoutService.openCheck();
        milk_7 = new Product(7, "Milk", Category.MILK, Trade.Silpo);
        bread_3 = new Product(3, "Bread");
    }


    [Fact]
    void closeCheck__withOneProduct()
    {
        checkoutService.addProduct(milk_7);
        Check check = checkoutService.closeCheck();
        Assert.Equal(7, check.getTotalCost());
    }

    [Fact]
    void closeCheck__withTwoProducts()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        Check check = checkoutService.closeCheck();
        Assert.Equal(10, check.getTotalCost());
    }

    [Fact]
    void addProduct__whenCheckIsClosed__opensNewCheck()
    {
        checkoutService.addProduct(milk_7);
        Check milkCheck = checkoutService.closeCheck();
        Assert.Equal(7, milkCheck.getTotalCost());

        checkoutService.addProduct(bread_3);
        Check breadCheck = checkoutService.closeCheck();
        Assert.Equal(3, breadCheck.getTotalCost());
    }
    [Fact]
    void closeCheck__calcTotalPoints()
    {

        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        Check check = checkoutService.closeCheck();
        Assert.Equal(10, check.getTotalCost());
    }

    [Fact]
    void useOffer__addOfferPoints()
    {

        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);

        checkoutService.useOffer(new BonusOffer(new DateTime(2020, 8, 10), new ByTotalCost(9), new Flat(2)));
        Check check = checkoutService.closeCheck();
        Assert.Equal(12, check.getTotalPoints());

    }

    [Fact]
    void useOffer__whenCostLessThanRequired__doNothing()
    {
        checkoutService.addProduct(bread_3);

        checkoutService.useOffer(new BonusOffer(new DateTime(2020, 8, 10), new ByTotalCost(12), new Flat(2)));
        Check check = checkoutService.closeCheck();
        Assert.Equal(3, check.getTotalPoints());
    }

    [Fact]
    void useOffer__factorByCategory()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        checkoutService.useOffer(new BonusOffer(new DateTime(2020, 8, 10), new ByCategory(Category.MILK), new CategoryFactor(2, Category.MILK)));
        Check check = checkoutService.closeCheck();
        Assert.Equal(31, check.getTotalPoints());

    }

    [Fact]
    void useOffer__ExpiredDate()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);

        checkoutService.useOffer(new BonusOffer(new DateTime(2020, 8, 1), new ByTotalCost(12), new Flat(2)));
        Check check = checkoutService.closeCheck();
        Assert.Equal(17, check.getTotalPoints());

    }

    [Fact]
    public void useOffer_BeforeCheckCloseFactorByCategoryOffer()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        checkoutService.useOffer(new BonusOffer(new DateTime(2020, 8, 10), new ByTotalCost(12), new Flat(2)));

        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        Check check = checkoutService.closeCheck();
        Assert.Equal(22, check.getTotalPoints());
    }

    [Fact]
    public void useOffer_ByTotalCostFlat()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        BonusOffer offer = new BonusOffer(new DateTime(2020, 8, 10), new ByTotalCost(9), new Flat(10));
        checkoutService.useOffer(offer);
        Check check = checkoutService.closeCheck();
        Assert.Equal(20, check.getTotalPoints());
    }
    [Fact]
    public void useOffer_ByTotalCostFactor()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        BonusOffer offer = new BonusOffer(new DateTime(2020, 8, 10), new ByTotalCost(9), new Factor(2));
        checkoutService.useOffer(offer);
        Check check = checkoutService.closeCheck();
        Assert.Equal(20, check.getTotalPoints());
    }
    [Fact]
    public void useOffer_ByTotalCostCategoryFactor()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        BonusOffer offer = new BonusOffer(new DateTime(2020, 8, 10), new ByTotalCost(9), new CategoryFactor(2, Category.MILK));
        checkoutService.useOffer(offer);
        Check check = checkoutService.closeCheck();
        Assert.Equal(17, check.getTotalPoints());
    }

    [Fact]
    public void useOffer_ByTradeFlat()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        BonusOffer offer = new BonusOffer(new DateTime(2020, 8, 10), new ByTrade(Trade.Silpo), new Flat(5));
        checkoutService.useOffer(offer);
        Check check = checkoutService.closeCheck();
        Assert.Equal(15, check.getTotalPoints());
    }

    [Fact]
    public void useOffer_ByTradeFactor()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        BonusOffer offer = new BonusOffer(new DateTime(2020, 8, 10), new ByTrade(Trade.Silpo), new Factor(3));
        checkoutService.useOffer(offer);
        Check check = checkoutService.closeCheck();
        Assert.Equal(30, check.getTotalPoints());
    }

    [Fact]
    public void useOffer_ByProductFlat()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        BonusOffer offer = new BonusOffer(new DateTime(2020, 8, 10), new ByProduct(new Product(7, "Milk", Category.MILK, Trade.Silpo)), new Flat(5));
        checkoutService.useOffer(offer);
        Check check = checkoutService.closeCheck();
        Assert.Equal(15, check.getTotalPoints());
    }

    [Fact]
    public void useOffer_ByProductFactor()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        BonusOffer offer = new BonusOffer(new DateTime(2020, 8, 10), new ByProduct(new Product(7, "Milk", Category.MILK, Trade.Silpo)), new Factor(3));
        checkoutService.useOffer(offer);
        Check check = checkoutService.closeCheck();
        Assert.Equal(30, check.getTotalPoints());
    }

    [Fact]
    public void useOffer_ByCategoryFlat()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        BonusOffer offer = new BonusOffer(new DateTime(2020, 8, 10), new ByCategory(Category.MILK), new Flat(5));
        checkoutService.useOffer(offer);
        Check check = checkoutService.closeCheck();
        Assert.Equal(15, check.getTotalPoints());
    }

    [Fact]
    public void useOffer_ByCategoryFactor()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        BonusOffer offer = new BonusOffer(new DateTime(2020, 8, 10), new ByCategory(Category.MILK), new Factor(3));
        checkoutService.useOffer(offer);
        Check check = checkoutService.closeCheck();
        Assert.Equal(30, check.getTotalPoints());
    }

    [Fact]
    public void useOffer_ByCategoryCategoryFactor()
    {
        checkoutService.addProduct(milk_7);
        checkoutService.addProduct(bread_3);
        BonusOffer offer = new BonusOffer(new DateTime(2020, 8, 10), new ByCategory(Category.MILK), new CategoryFactor(2, Category.MILK));
        checkoutService.useOffer(offer);
        Check check = checkoutService.closeCheck();
        Assert.Equal(17, check.getTotalPoints());
    }
    [Fact]
    public void useOffer_Percent()
    {
        checkoutService.addProduct(new Product(8, "Milk", Category.MILK, Trade.Silpo));
        checkoutService.addProduct(new Product(8, "Milk", Category.MILK, Trade.Silpo));
        checkoutService.addProduct(bread_3);
        DiscountOffer offer = new DiscountOffer(new DateTime(2020, 8, 10), new ByProduct(new Product(8, "Milk", Category.MILK, Trade.Silpo)), new Percent(50, new Product(8, "Milk", Category.MILK, Trade.Silpo)));
        checkoutService.useOffer(offer);
        Check check = checkoutService.closeCheck();
        Assert.Equal(15, check.getTotalCost());
    }
    [Fact]
    public void useOffer_Gift()
    {
        checkoutService.addProduct(new Product(8, "Milk", Category.MILK, Trade.Silpo));
        checkoutService.addProduct(new Product(8, "Milk", Category.MILK, Trade.Silpo));
        checkoutService.addProduct(bread_3);
        DiscountOffer offer = new DiscountOffer(new DateTime(2020, 8, 10), new ByProduct(new Product(8, "Milk", Category.MILK, Trade.Silpo)), new Gift(1, new Product(8, "Milk", Category.MILK, Trade.Silpo)));

        checkoutService.useOffer(offer);
        Check check = checkoutService.closeCheck();
        Assert.Equal(12, check.getTotalCost());
    }



}