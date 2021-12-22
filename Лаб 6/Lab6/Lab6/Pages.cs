namespace Lab5
{
    public static class Pages
    {
        public static OwnerPage OwnerPage => new OwnerPage(TestBase.WebDriver);

        public static PetPage PetPage => new PetPage(TestBase.WebDriver);

        public static PetTypePage PetTypePage => new PetTypePage(TestBase.WebDriver);
    }
}
