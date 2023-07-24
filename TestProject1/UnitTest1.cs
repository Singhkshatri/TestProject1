using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // Login test case
        [TestMethod]
        public void Login_page()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.nopcommerce.com/en";
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("//span[text()='My account ']")).Click();
            driver.FindElement(By.XPath("//span[text()='Log in']")).Click();
            driver.FindElement(By.XPath("//input[@class='username']")).SendKeys("SinghKshatri");
            driver.FindElement(By.XPath("//input[@class='password']")).SendKeys("123654");
            driver.FindElement(By.XPath("//div[@class='custom-control custom-checkbox']")).Click();
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            IWebElement actual = driver.FindElement(By.XPath("//div[@class='home-banner-button']//a[text()='View demo']"));
            String Actual = actual.Text;
            string Expected = "VIEW DEMO";
            Assert.AreEqual(Expected, Actual);

            Thread.Sleep(3000);
            driver.Quit();

        }
        //Registration Test Case
        [TestMethod]
        public void Registration_Page()
        {
            IWebDriver driver = new ChromeDriver(); 
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.nopcommerce.com/en");

            driver.FindElement(By.XPath("//span[text()='My account ']")).Click();
            driver.FindElement(By.XPath("//span[text()='Register']")).Click();
            driver.FindElement(By.XPath("//input[@id='FirstName']")).SendKeys("Singh");
            driver.FindElement(By.XPath("//input[@id='LastName']")).SendKeys("Kshatri");
            driver.FindElement(By.XPath("//input[@id='Email']")).SendKeys("Kshatri@gmail.com");
            driver.FindElement(By.XPath("//input[@id='ConfirmEmail']")).SendKeys("Kshatri@gmail.com");
            driver.FindElement(By.XPath("//input[@id='Username']")).SendKeys("K.Singh");
            driver.FindElement(By.XPath("//input[@id='check-availability-button']")).Click();
            //select country region
            SelectElement dropdown = new SelectElement(driver.FindElement(By.XPath("//select[@id='CountryId']")));
            dropdown.SelectByValue("334");
            //select time zone
            SelectElement TimeZone = new SelectElement(driver.FindElement(By.XPath("//select[@id='TimeZoneId']")));
            TimeZone.SelectByText("(UTC-10:00) Hawaii");
            driver.FindElement(By.XPath("//input[@name='Password']")).SendKeys("123654");
            driver.FindElement(By.XPath("//input[@name='ConfirmPassword']")).SendKeys("123654");
            //select Details_CompanyIndustryId
            SelectElement CompanyIndustryId = new SelectElement(driver.FindElement(By.XPath("//select[@id='Details_CompanyIndustryId']")));
            CompanyIndustryId.SelectByText("I am student");
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            IWebElement actual= driver.FindElement(By.XPath("//h2[contains(text(), 'Almost done!')]"));
            String Actual = actual.Text;
            string Expected = "Almost done! To complete your nopCommerce registration, we just need to verify your email address. You have just been sent an email to confirm your email address. Open the email, and click the link to confirm your address.";
            Assert.AreEqual(Expected, Actual);

        }

        //cogmento Login & companies creation Test Case
        [TestMethod]
        public void CRM_login()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://ui.cogmento.com/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);

            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("bhavanisingh.kshatri@gmail.com");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("12345");
            driver.FindElement(By.XPath("//div[text()='Login']")).Click();

//            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
//            wait.Until(ExpectedConditions.ElementVisable);
            // Navigate to Main menu to Find Companies
            IWebElement menu = driver.FindElement(By.XPath("//div[@id='main-nav']"));
            Actions action = new Actions(driver);
            action.MoveToElement(menu).Build().Perform();
            IWebElement companies = driver.FindElement(By.XPath("//span[contains(text(),'Companies')]"));
            companies.Click();

            //Creating new Companie
            driver.FindElement(By.XPath("//button[text()='Create']")).Click();
            driver.FindElement(By.XPath("//div[@class='ui right corner labeled input']//input[@name='name']")).SendKeys("SeleniumAutomation");
            driver.FindElement(By.XPath("//button[contains(@class, 'toggle button')]")).Click();
            driver.FindElement(By.XPath("//div[text()='Select users allowed access.']")).SendKeys("K.Singh");
            driver.FindElement(By.XPath("//input[@name='address']")).SendKeys("2/21 Brodipet");
            driver.FindElement(By.XPath("//input[@name='city']")).SendKeys("Hydrabad");
            driver.FindElement(By.XPath("//input[@name='state']")).SendKeys("Telengana");
            driver.FindElement(By.XPath("//input[@name='zip']")).SendKeys("85698");
            driver.FindElement(By.XPath("//div[@name='country']")).SendKeys("India");
            driver.FindElement(By.XPath("//div[@name='hint']//input[@class='search']")).SendKeys("India");
            driver.FindElement(By.XPath("//input[@placeholder='Number']")).SendKeys("123456789");
            driver.FindElement(By.XPath("//input[@placeholder='Home, Work, Mobile...']")).SendKeys("D.NO:100/108");
            driver.FindElement(By.XPath("//input[@placeholder='Email address']")).SendKeys("kshatrisingh@gmail.com");
            driver.FindElement(By.XPath("//input[@placeholder='Personal email, Business, Alt...']")).SendKeys("kshatrisingh@gmail.com");
            driver.FindElement(By.XPath("//label //div[@role='combobox']")).SendKeys("All izz Well");
            driver.FindElement(By.XPath("//textarea[@name='description']")).SendKeys("This Companies are Highly Moderated & very Work Culture based companie");
            driver.FindElement(By.XPath("")).SendKeys("");




        }

    }
}