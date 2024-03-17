using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace seasonvar.ruSeleniumTest
{
    public class Tests
    {
        // Declaring the driver variable to control the web browser
        static IWebDriver driver; // Let's make it static to continue with test2. 

        string Login = "yakipov.aset@gmail.com";
        string Password = "MLN0115QWErt";

        [SetUp]
        public void Setup()
        {
            // Checking if a browser instance has already been initialized
            if (driver == null)
            {
                // Driver initialization 
                driver = new ChromeDriver();
            }
            
        }

        [Test]
        public void TestPart1_LoginAndCheckUser()
        {
            // Opening the site 
            driver.Navigate().GoToUrl("http://seasonvar.ru/");
            // Maximum browser window
            driver.Manage().Window.Maximize();


            // Find the login button and click on it.
            IWebElement signInButton = driver.FindElement(By.XPath("//a[@href = '/?mod=login']"));
            signInButton.Click();

            // Create a WebDriverWait object to wait for elements to appear on the page.
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(driver => driver.FindElement(By.XPath("//input[@placeholder='E-mail']")));

            // Find the login input field and enter your login.
            IWebElement loginField = driver.FindElement(By.XPath("//input[@placeholder='E-mail']"));
            loginField.Click();
            loginField.SendKeys(Login);

            // Find the password entry field and enter the password.
            IWebElement passwordField = driver.FindElement(By.XPath("//input[@type='password']"));
            passwordField.Click();
            passwordField.SendKeys(Password);

            // Find the login button and click on it.
            IWebElement loginButton = driver.FindElement(By.XPath("//button[@type='submit' and @class='btn']"));
            loginButton.Click();

            // Waiting for the username element to appear after login.
            IWebElement usernameElement = wait.Until(driver => driver.FindElement(By.XPath("//li[@class='headmenu-title']")));
            Assert.IsNotNull(usernameElement, "Username element not found. Login failed.");
        }

        [Test]
        public void TestPart2_CheckPopupMenu() 
        {
            // Creating a WebDriverWait object to wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Create an instance of the Actions class
            Actions actions = new Actions(driver);

            // Find the menu button and click on it.
            IWebElement menuButton = driver.FindElement(By.XPath("//button[@type='submit' and @data-menu='head']"));
            menuButton.Click();
            // Click on the menu button using the Click method
            actions.Click(menuButton).Perform();

            // Find Premium Account in the menu and click on it.
            IWebElement premiumAccButton = driver.FindElement(By.XPath("//a[@href='/premium']"));
            premiumAccButton.Click();
            
        }



        [TearDown]
        public void TearDown() 
        {

            // надо доработать выход срабатывает после test1
            // Выход из теста
            //driver.Quit();
        }

        
    }
}