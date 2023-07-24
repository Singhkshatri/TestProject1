using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V111.DOM;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject1
{
    [TestClass]
    public class AutomationExercise
    {
        // Register User test case
        [TestMethod]
        public void Register_User()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            /*IWebElement actualhome = driver.FindElement(By.XPath("//h2[text()='Features Items']"));
            string actualhome = actualhome.Text;
            string Expectedhome = "Features Items";
            Assert.AreEqual(Expectedhome, actualhome);*/

            //The home page is visible successfully
            Boolean isDisplyed = driver.FindElement(By.XPath("//h2[text()='Features Items']")).Displayed;
            Assert.IsTrue(isDisplyed);

            //           if (isDisplyed)
            //           {
            //               Console.WriteLine("The home page is visible successfully");
            //           }
            //           else
            //           {
            //               Console.WriteLine("The home page is not visible successfully");
            //           }

            //Click on Sineup/Login page
            driver.FindElement(By.XPath("//a[text()=' Signup / Login']")).Click();

            //Verify 'New User Signup!' is visible
            Boolean signupbtn = driver.FindElement(By.XPath("//button[text()='Signup']")).Enabled;
            Assert.IsTrue(signupbtn);

            //Enter name and email address
            IWebElement name = driver.FindElement(By.XPath("//input[@name='name']"));
            name.SendKeys("Techno");

            //Date generation
            //DateOnly date = new DateOnly();
            //String timestamp = time.ToString().Replace(" ", "_").Replace(":", "_");

            //Time generation
            //TimeOnly time = new TimeOnly();
            //string timestamp = time.ToString().Replace(" ", "_").Replace(":", " "); 

            //Random NUmber Generation
            Random random = new Random();
            int randomNo = random.Next(1, 1500);

            IWebElement email = driver.FindElement(By.XPath("//div[@class='signup-form']//input[@name='email']"));
            email.SendKeys("techno" + randomNo + "@gmail.com");

            //Click 'Signup' button
            driver.FindElement(By.XPath("//button[text()='Signup']")).Click();

            // Verify that 'ENTER ACCOUNT INFORMATION' is visible
            Boolean accountinfo = driver.FindElement(By.XPath("//h2[@class='title text-center']//b[text()='Enter Account Information']")).Enabled;
            Assert.IsTrue(accountinfo);

            //Fill details: Title, Name, Email, Password, Date of birth
            IWebElement title = driver.FindElement(By.XPath("//input[@id='id_gender1']"));
            title.Click();

            IWebElement password = driver.FindElement(By.XPath("//input[@id='password']"));
            password.SendKeys("Techno879");

            SelectElement dateDW = new SelectElement(driver.FindElement(By.XPath("//select[@id='days']")));
            dateDW.SelectByText("15");

            SelectElement monthDW = new SelectElement(driver.FindElement(By.XPath("//select[@id='months']")));
            monthDW.SelectByIndex(8);

            SelectElement yearDW = new SelectElement(driver.FindElement(By.XPath("//select[@id='years']")));
            yearDW.SelectByIndex(30);

            //Select checkbox 'Sign up for our newsletter!'
            driver.FindElement(By.XPath("//input[@name='newsletter']")).Click();

            //Select checkbox 'Receive special offers from our partners!'
            driver.FindElement(By.XPath("//input[@name='optin']")).Click();

            //Fill details: First name, Last name, Company, Address, Address2, Country, State, City, Zipcode, Mobile Number
            IWebElement Fname = driver.FindElement(By.XPath("//input[@name='first_name']"));
            Fname.SendKeys("Techno");

            IWebElement Lname = driver.FindElement(By.XPath("//input[@name='last_name']"));
            Lname.SendKeys("879");

            IWebElement company = driver.FindElement(By.XPath("//input[@name='company']"));
            Fname.SendKeys("Techno Gamer");

            IWebElement address = driver.FindElement(By.XPath("//input[@id='address1']"));
            address.SendKeys("Street  3200 N.Expressway 83");

            SelectElement countryDW = new SelectElement(driver.FindElement(By.XPath("//select[@id='country']")));
            countryDW.SelectByText("United States");

            IWebElement state = driver.FindElement(By.XPath("//input[@id='state']"));
            state.SendKeys("Texas");

            IWebElement city = driver.FindElement(By.XPath("//input[@id='city']"));
            city.SendKeys("Brownsville");

            IWebElement zipcode = driver.FindElement(By.XPath("//input[@id='zipcode']"));
            zipcode.SendKeys("78526");

            IWebElement mobileNo = driver.FindElement(By.XPath("//input[@id='mobile_number']"));
            mobileNo.SendKeys("956 542 - 9550");

            //Click 'Create Account button'
            driver.FindElement(By.XPath("//button[text()='Create Account']")).Click();

            //Verify that 'ACCOUNT CREATED!' is visible
            Boolean accountcreated = driver.FindElement(By.XPath("//b[text()='Account Created!']")).Enabled;
            Assert.IsTrue(accountcreated);

            // Click 'Continue' button
            IWebElement continew = driver.FindElement(By.XPath("//a[text()='Continue']"));
            continew.Click();

            Thread.Sleep(5000);
            // Verify that 'Logged in as username' is visible
            Boolean loggeduName = driver.FindElement(By.XPath("//a[text()=' Logged in as ']")).Enabled;
            Assert.IsTrue(loggeduName);

            //Click 'Delete Account' button
            IWebElement accDelete = driver.FindElement(By.XPath("//a[text()=' Delete Account']"));
            accDelete.Click();

            //Verify that 'ACCOUNT DELETED!' is visible and click 'Continue' button
            Boolean Accdeleted = driver.FindElement(By.XPath("//b[text()='Account Deleted!']")).Enabled;

            //Browser is closed.
            driver.Quit();
        }


        // Test Case 2: Login User with correct email and password
        [TestMethod]
        public void Login_User_with_correct_email_and_password()
        {
            //Launch browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to url 'http://automationexercise.com'

            driver.Navigate().GoToUrl("https://www.automationexercise.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Verify that home page is visible successfully
            Boolean isDisplyed = driver.FindElement(By.XPath("//h2[text()='Features Items']")).Displayed;
            Assert.IsTrue(isDisplyed);

            //Click on 'Signup / Login' button
            driver.FindElement(By.XPath("//a[text()=' Signup / Login']")).Click();

            //Verify 'Login to your account' is visible
            Boolean loginVisibel = driver.FindElement(By.XPath("//button[text()='Login']")).Displayed;
            Assert.IsTrue(loginVisibel);

            // Enter correct email address and password
            IWebElement emailid = driver.FindElement(By.XPath("//form[@action='/login']//input[@type='email']"));
            emailid.SendKeys("techno@gmail.com");

            IWebElement passwd = driver.FindElement(By.XPath("//form[@action='/login']//input[@type='password']"));
            passwd.SendKeys("Techno879");

            //Click 'login' button
            IWebElement loginBtn = driver.FindElement(By.XPath("//button[text()='Login']"));
            loginBtn.Click();

            //Verify that 'Logged in as username' is visible
            Boolean loggeduName = driver.FindElement(By.XPath("//a[text()=' Logged in as ']")).Enabled;
            Assert.IsTrue(loggeduName); 

            //Click 'Delete Account' button
            IWebElement accDelete = driver.FindElement(By.XPath("//a[text()=' Delete Account']"));
            accDelete.Click();

            //Verify that 'ACCOUNT DELETED!' is visible and click 'Continue' button
            Boolean Accdeleted = driver.FindElement(By.XPath("//b[text()='Account Deleted!']")).Enabled;
            Assert.IsTrue(Accdeleted);

            //Browser is closed.
            driver.Quit();

        }

        //Test Case 3: Login User with incorrect email and password
        [TestMethod]
        public void Login_User_with_incorrect_email_and_password()
        {
            //Launch browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to url 'http://automationexercise.com'

            driver.Navigate().GoToUrl("https://www.automationexercise.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Verify that home page is visible successfully
            Boolean isDisplyed = driver.FindElement(By.XPath("//h2[text()='Features Items']")).Displayed;
            Assert.IsTrue(isDisplyed);

            //Click on 'Signup / Login' button
            driver.FindElement(By.XPath("//a[text()=' Signup / Login']")).Click();

            //Verify 'Login to your account' is visible
            Boolean loginVisibel = driver.FindElement(By.XPath("//button[text()='Login']")).Displayed;
            Assert.IsTrue(loginVisibel);

            // Enter incorrect email address and password
            IWebElement emailid = driver.FindElement(By.XPath("//form[@action='/login']//input[@type='email']"));
            emailid.SendKeys("techno@gmail.com");

            IWebElement passwd = driver.FindElement(By.XPath("//form[@action='/login']//input[@type='password']"));
            passwd.SendKeys("Techno879");

            //Click 'login' button
            IWebElement loginBtn = driver.FindElement(By.XPath("//button[text()='Login']"));
            loginBtn.Click();

            //Verify error 'Your email or password is incorrect!' is visible
            Boolean error = driver.FindElement(By.XPath("//p[text()='Your email or password is incorrect!']")).Displayed;
            Assert.IsTrue(error);

            //Browser is closed.
            driver.Quit();

        }
        //Test Case 4: Logout User
        [TestMethod]
        public void Logout_User()
        {
            //Launch browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to url 'http://automationexercise.com'

            driver.Navigate().GoToUrl("https://www.automationexercise.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Verify that home page is visible successfully
            Boolean isDisplyed = driver.FindElement(By.XPath("//h2[text()='Features Items']")).Displayed;
            Assert.IsTrue(isDisplyed);

            //Click on 'Signup / Login' button
            driver.FindElement(By.XPath("//a[text()=' Signup / Login']")).Click();

            // Enter correct email address and password
            IWebElement emailid = driver.FindElement(By.XPath("//form[@action='/login']//input[@type='email']"));
            emailid.SendKeys("techno@gmail.com");

            IWebElement passwd = driver.FindElement(By.XPath("//form[@action='/login']//input[@type='password']"));
            passwd.SendKeys("Techno879");

            //Click 'login' button
            IWebElement loginBtn = driver.FindElement(By.XPath("//button[text()='Login']"));
            loginBtn.Click();

            //Verify that 'Logged in as username' is visible
            Boolean loggeduName = driver.FindElement(By.XPath("//a[text()=' Logged in as ']")).Enabled;
            Assert.IsTrue(loggeduName);

            //Click 'Logout' button
            IWebElement logout = driver.FindElement(By.XPath("//a[text()=' Logout']"));
            logout.Click();

            //Verify that user is navigated to login page
            Boolean navigateedLogin = driver.FindElement(By.XPath(" //h2[text()='Login to your account']")).Displayed;
            Assert.IsTrue(navigateedLogin);

            //Browser is closed.
            driver.Quit();

        }

        //Test Case 5: Register User with existing email
        [TestMethod]
        public void Register_User_with_existing_email()
        {
            //Launch browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to url 'http://automationexercise.com'
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //The home page is visible successfully
            Boolean isDisplyed = driver.FindElement(By.XPath("//h2[text()='Features Items']")).Displayed;
            Assert.IsTrue(isDisplyed);

            //Click on Sineup/Login page
            driver.FindElement(By.XPath("//a[text()=' Signup / Login']")).Click();

            //Verify 'New User Signup!' is visible
            Boolean signupbtn = driver.FindElement(By.XPath("//button[text()='Signup']")).Enabled;
            Assert.IsTrue(signupbtn);

            //Enter name and already registered email address
            IWebElement sineupName = driver.FindElement(By.XPath("//input[@data-qa='signup-name']"));
            sineupName.SendKeys("techno");

            IWebElement sineupEmail = driver.FindElement(By.XPath("//input[@data-qa='signup-email']"));
            sineupEmail.SendKeys("techno@gmail.com");

            //Click 'Signup' button
            driver.FindElement(By.XPath("//button[text()='Signup']")).Click();

            //Verify error 'Email Address already exist!' is visible
            Boolean emailAlreadyexits = driver.FindElement(By.XPath("//p[text()='Email Address already exist!']")).Displayed;
            Assert.IsTrue(emailAlreadyexits);

            //Browser is closed.
            driver.Quit();

        }

        //Test Case 6: Contact Us Form
        [TestMethod]
        public void Contact_Us_Form()
        {
            //Launch browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to url 'http://automationexercise.com'
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //The home page is visible successfully
            Boolean isDisplyed = driver.FindElement(By.XPath("//h2[text()='Features Items']")).Displayed;
            Assert.IsTrue(isDisplyed);

            //Click on 'Contact Us' button
            IWebElement contactUs = driver.FindElement(By.XPath("//a[text()=' Contact us']"));
            contactUs.Click();

            //Verify 'GET IN TOUCH' is visible
            Boolean getInTouch = driver.FindElement(By.XPath("//h2[text()='Get In Touch']")).Displayed;
            Assert.IsTrue(getInTouch);

            //Enter name, email, subject and message
            IWebElement name = driver.FindElement(By.XPath("//input[@placeholder='Name']"));
            name.SendKeys("Techno");

            IWebElement email = driver.FindElement(By.XPath("//input[@placeholder='Email']"));
            email.SendKeys("Techno@gmail.com");

            IWebElement subject = driver.FindElement(By.XPath("//input[@placeholder='Subject']"));
            subject.SendKeys("Error");

            IWebElement message = driver.FindElement(By.XPath("//textarea[@placeholder='Your Message Here']"));
            message.SendKeys("\r\nHow to Copy Error Message to Clipboard\r\nOften we face errors on our PCs which, with a quick web search on the error text, are easily resolvable. Did you know you can copy the contents of an error message (or any dialog box) to your clipboard? When you're faced with an error, press Ctrl+C to copy the error title and text to your clipboard.");

            //Upload file
            //IWebElement uploadFile = driver.FindElement(By.XPath("//input[@name='upload_file']"));
            //uploadFile.SendKeys("C:\\Users\\Harshitha\\Pictures\\Screenshots\\Automation_Exercise");

            //IWebElement uploadFile = driver.FindElement(By.XPath("//input[@name='upload_file']"));
            //string filepath = "C:\\Users\\Harshitha\\Downloads\\Automation_Exercise";
            //uploadFile.SendKeys(filepath);

            //Click 'Submit' button
            IWebElement submit = driver.FindElement(By.XPath("//input[@name='submit']"));
            submit.Click();

            //Click OK button
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            //Verify success message 'Success! Your details have been submitted successfully.' is visible
            Boolean verrifySuccess = driver.FindElement(By.XPath("//div[@class='col-sm-8'] //div[contains(text(), 'Success! ')]")).Displayed;
            Assert.IsTrue(verrifySuccess);

            //Click 'Home' button and verify that landed to home page successfully
            IWebElement homeBtn = driver.FindElement(By.XPath("//a[text()=' Home']"));
            homeBtn.Click();

            Boolean homePageLanded = driver.FindElement(By.XPath("//h2[text()='Features Items']")).Displayed;
            Assert.IsTrue(homePageLanded);

            //Browser is closed.
            driver.Quit();

        }

        //Test Case 7: Verify Test Cases Page
        [TestMethod]
        public void Verify_Test_Cases_Page()
        {
            //Launch browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to url 'http://automationexercise.com'
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //The home page is visible successfully
            Boolean isDisplyed = driver.FindElement(By.XPath("//h2[text()='Features Items']")).Displayed;
            Assert.IsTrue(isDisplyed);

            //Click on 'Test Cases' button
            IWebElement testCase = driver.FindElement(By.XPath("//a[text()=' Test Cases']"));
            testCase.Click();

            //Verify user is navigated to test cases page successfully
            Boolean navigatedTestCasePage = driver.FindElement(By.XPath("//b[text()='Test Cases']")).Displayed;
            Assert.IsTrue(navigatedTestCasePage);

            //Browser is closed.
            driver.Quit();

        }

        //Test Case 8: Verify All Products and product detail page

        [TestMethod]
        public void Verify_All_Products_and_product_detail_page()
        {
            //Launch browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to url 'http://automationexercise.com'
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //The home page is visible successfully
            Boolean isDisplyed = driver.FindElement(By.XPath("//h2[text()='Features Items']")).Displayed;
            Assert.IsTrue(isDisplyed);

            //Click on 'Products' button
            IWebElement product = driver.FindElement(By.XPath("//a[text()=' Products']"));
            product.Click();

            //Verify user is navigated to ALL PRODUCTS page successfully
            Boolean navigatedProduct = driver.FindElement(By.XPath("//input[@id='search_product']")).Displayed;
            Assert.IsTrue(navigatedProduct);

            //The products list is visible
            Boolean ProductList = driver.FindElement(By.XPath("//input[@id='search_product']")).Displayed;
            Assert.IsTrue(ProductList);

            //Click on 'View Product' of first product
            IWebElement viewProduct = driver.FindElement(By.LinkText("View Product"));
            viewProduct.Click();

            //User is landed to product detail page
            Boolean landedProduct = driver.FindElement(By.XPath("//a[text()='Write Your Review']")).Displayed;
            Assert.IsTrue(landedProduct);

            //Verify that detail is visible: product name, category, price, availability, condition, brand
            Boolean detailsVisible = driver.FindElement(By.XPath("//div[@class='product-information']")).Displayed;
            Assert.IsTrue(detailsVisible);

            //Browser is closed.
            driver.Quit();

        }

        //Test Case 9: Search Product
        [TestMethod]
        public void Search_Product()
        {
            //Launch browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to url 'http://automationexercise.com'
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //The home page is visible successfully
            Boolean isDisplyed = driver.FindElement(By.XPath("//h2[text()='Features Items']")).Displayed;
            Assert.IsTrue(isDisplyed);

            //Click on 'Products' button
            IWebElement product = driver.FindElement(By.XPath("//a[text()=' Products']"));
            product.Click();

            //Verify user is navigated to ALL PRODUCTS page successfully
            Boolean navigatedProduct = driver.FindElement(By.XPath("//input[@id='search_product']")).Displayed;
            Assert.IsTrue(navigatedProduct);

            //Enter product name in search input and click search button
            IWebElement serchInput = driver.FindElement(By.XPath("//input[@id='search_product']"));
            serchInput.SendKeys("Jeans");

            IWebElement serchbtn = driver.FindElement(By.XPath("//button[@id='submit_search']"));
            serchbtn.Click();

            // Verify 'SEARCHED PRODUCTS' is visible
            Boolean serchedProduct = driver.FindElement(By.XPath("//div[@class='productinfo text-center']//p[text()='Soft Stretch Jeans']")).Displayed;
            Assert.IsTrue(serchedProduct);

            //Verify all the products related to search are visible
            Boolean simillarProduct = driver.FindElement(By.XPath("//div[@class='productinfo text-center']//p[contains(text(),'Jeans')]")).Displayed;
            Assert.IsTrue(simillarProduct);

            //Browser is closed.
            driver.Quit();

        }
        //Test Case 10: Verify Subscription in home page
        [TestMethod]
        public void Verify_Subscription_in_home_page()
        {
            //Launch browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to url 'http://automationexercise.com'
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //The home page is visible successfully
            Boolean isDisplyed = driver.FindElement(By.XPath("//h2[text()='Features Items']")).Displayed;
            Assert.IsTrue(isDisplyed);

            //Scroll down to footer
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,350)", "");

            //Verify text 'SUBSCRIPTION'
            Boolean isSubscription = driver.FindElement(By.XPath("//h2[text()='Subscription']")).Displayed;
            Assert.IsTrue(isSubscription);

            //Enter email address in input and click arrow button
            IWebElement enterEmailAdd = driver.FindElement(By.XPath("//input[@id='susbscribe_email']"));
            enterEmailAdd.SendKeys("Techno@gmail.com");

            IWebElement clickArrowBtn = driver.FindElement(By.XPath("//button[@id='subscribe']"));
            clickArrowBtn.Click();

            //Verify success message 'You have been successfully subscribed!' is visible
            Boolean SuccessSubscription = driver.FindElement(By.XPath("//div[text()='You have been successfully subscribed!']")).Displayed;
            Assert.IsTrue(SuccessSubscription);
            
            //Browser is closed.
            driver.Quit();

        }

        //Test Case 11: Verify Subscription in Cart page
        [TestMethod]
        public void Verify_Subscription_in_Cart_page()
        {
            //Launch browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to url 'http://automationexercise.com'
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //The home page is visible successfully
            Boolean isDisplyed = driver.FindElement(By.XPath("//h2[text()='Features Items']")).Displayed;
            Assert.IsTrue(isDisplyed);

            //Click 'Cart' button
            IWebElement cartBtn = driver.FindElement(By.LinkText("Cart"));
            cartBtn.Click();

            //Scroll down to footer
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,350)", "");

            //Verify text 'SUBSCRIPTION'
            Boolean isSubscription = driver.FindElement(By.XPath("//h2[text()='Subscription']")).Displayed;
            Assert.IsTrue(isSubscription);

            //Enter email address in input and click arrow button
            IWebElement enterEmailAdd = driver.FindElement(By.XPath("//input[@id='susbscribe_email']"));
            enterEmailAdd.SendKeys("Techno@gmail.com");

            IWebElement clickArrowBtn = driver.FindElement(By.XPath("//button[@id='subscribe']"));
            clickArrowBtn.Click();

            //Verify success message 'You have been successfully subscribed!' is visible
            Boolean SuccessSubscription = driver.FindElement(By.XPath("//div[text()='You have been successfully subscribed!']")).Displayed;
            Assert.IsTrue(SuccessSubscription);

            //Browser is closed.
            driver.Quit();

        }

        //Test Case 12: Add Products in Cart
        [TestMethod]
        public void Add_Products_in_Cart()
        {
            //Launch browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to url 'http://automationexercise.com'
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //The home page is visible successfully
            Boolean isDisplyed = driver.FindElement(By.XPath("//h2[text()='Features Items']")).Displayed;
            Assert.IsTrue(isDisplyed);

            //Click 'Products' button
            IWebElement productBtn = driver.FindElement(By.LinkText(" Products"));
            productBtn.Click();

            //Hover over first product and click 'Add to cart'
            IWebElement addToCart1 = driver.FindElement(By.XPath("//div[@class='product-overlay']//a[@data-product-id='1']"));
            addToCart1.Click();

            //Click 'Continue Shopping' button
            IWebElement continueShopping1 = driver.FindElement(By.XPath("//button[text()='Continue Shopping']"));
            continueShopping1.Click();

            //Hover over second product and click 'Add to cart'
            IWebElement addToCart2 = driver.FindElement(By.XPath("//div[@class='product-overlay']//a[@data-product-id='2']"));
            addToCart2.Click();

            IWebElement continueShopping2 = driver.FindElement(By.XPath("//button[text()='Continue Shopping']"));
            continueShopping2.Click();

            //Click 'View Cart' button
            IWebElement viewCart = driver.FindElement(By.LinkText(" Cart"));
            viewCart.Click();

            //Verify both products are added to Cart
            Boolean verifyProductAddToCart = driver.FindElement(By.XPath("//table[@id='cart_info_table']")).Displayed;
            Assert.IsTrue(verifyProductAddToCart);

            //Verify their prices, quantity and total price




        }


    }

}
