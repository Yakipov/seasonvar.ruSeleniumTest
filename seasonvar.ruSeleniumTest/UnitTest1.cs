using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Numerics;
using System.Xml.Linq;


namespace seasonvar.ruSeleniumTest
{
    public class Tests
    {
        // Declaring the driver variable to control the web browser
        // Declared as static to ensure accessibility across multiple test methods.
        static IWebDriver driver;

        // Please provide valid login credentials for the website http://seasonvar.ru/
        string Login = "yakipov.aset@gmail.com"; // Replace existing 
        string Password = "MLN0115QWErt"; // Replace existing 

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
            // Opening the site and Maximum browser window
            driver.Navigate().GoToUrl("http://seasonvar.ru/");
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

            // Find the login button and click on it and waiting for the username element to appear after login.
            IWebElement loginButton = driver.FindElement(By.XPath("//button[@type='submit' and @class='btn']"));
            loginButton.Click();
            // Wait for the username element to appear after successful login.
            IWebElement usernameElement = wait.Until(driver => driver.FindElement(By.XPath("//li[@class='headmenu-title']")));
            // Check if the username element is not null to ensure successful login.
            Assert.IsNotNull(usernameElement, "Username element not found. Login failed.");
        }


        static void OpenMenuButton() 
        {
            // Method to open the menu by clicking the menu button using Actions class.
            Actions actions = new Actions(driver);
            
            IWebElement menuButton = driver.FindElement(By.XPath("//button[@type='submit' and @data-menu='head']"));
            menuButton.Click();
            
            actions.Click(menuButton).Perform();
        }

        [Test]
        public void TestPart2_CheckPopupMenu() 
        {
            // Test method to check the functionality of the popup menu.
            // It performs the following actions:
            // 1. Opens the menu by clicking the menu button.
            // 2. Clicks on various menu items and verifies the resulting URLs.
            // 3. Navigates back to the previous page after each click.
            // 4. Verifies the presence of certain elements on the page.
            // 5. Finally, clicks on the exit button to log out and asserts the presence of the sign-in button.
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            OpenMenuButton();
            
            
            IWebElement premiumAccButton = driver.FindElement(By.XPath("//a[@href='/premium']"));
            IWebElement elementPremiumAcc = wait.Until(driver => driver.FindElement(By.XPath("//a[@href='/premium']")));
            premiumAccButton.Click();

            
            string currentUrlPremiumAcc = driver.Url;
            Assert.That(currentUrlPremiumAcc, Is.EqualTo("http://seasonvar.ru/premium"), "The page URL is not what you expected.");

            
            driver.Navigate().Back();

            OpenMenuButton();

            IWebElement blogButton = driver.FindElement(By.XPath("//a[@href='/?mode=blog']"));
            IWebElement elementBlogButton = wait.Until(driver => driver.FindElement(By.XPath("//a[@href='/?mode=blog']")));
            blogButton.Click();

            
            string currentUrlBlog = driver.Url;
            Assert.That(currentUrlBlog, Is.EqualTo("http://seasonvar.ru/?mode=blog"), "The page URL is not what you expected.");

            driver.Navigate().Back();

            OpenMenuButton();

            IWebElement profileButton = driver.FindElement(By.XPath("//a[contains(i/@class, 'svico-user')]"));
            IWebElement elementProfileButton = wait.Until(driver => driver.FindElement(By.XPath("//a[contains(i/@class, 'svico-user')]")));
            profileButton.Click();

            
            IWebElement elementProfile = wait.Until(driver => driver.FindElement(By.XPath("//div[@class='pgs-profile-info']")));

            
            Assert.IsTrue(elementProfile.Displayed, "The element does not appear on the page.");

            driver.Navigate().Back();

            OpenMenuButton();

            IWebElement settingsButton = driver.FindElement(By.XPath("//a[@href='/?mod=settings']"));
            IWebElement elementSettingsButton = wait.Until(driver => driver.FindElement(By.XPath("//a[@href='/?mod=settings']")));
            settingsButton.Click();

            string currentUrlSettings = driver.Url;
            Assert.That(currentUrlSettings, Is.EqualTo("http://seasonvar.ru/?mod=settings#login-cfg"), "The page URL is not what you expected.");

            driver.Navigate().Back();

            OpenMenuButton();

            IWebElement ticketButton = driver.FindElement(By.XPath("//a[@href='/?mod=ticket' and contains(i/@class, 'svico-traffic-cone')]"));
            IWebElement elementTicketButton = wait.Until(driver => driver.FindElement(By.XPath("//a[@href='/?mod=ticket' and contains(i/@class, 'svico-traffic-cone')]")));
            ticketButton.Click();

            IWebElement elementTicketBuutton = wait.Until(driver => driver.FindElement(By.XPath("//a[@href='/?mod=ticket&action=add']")));
            Assert.IsTrue(elementTicketBuutton.Displayed, "The element does not appear on the page.");

            IWebElement ticketActionButton = driver.FindElement(By.XPath("//a[@href='/?mod=ticket&action=add']"));
            IWebElement elementTicketActionButton = wait.Until(driver => driver.FindElement(By.XPath("//a[@href='/?mod=ticket&action=add']")));
            ticketActionButton.Click();

            string currentUrlTicket = driver.Url;
            Assert.That(currentUrlTicket, Is.EqualTo("http://seasonvar.ru/?mod=ticket&action=add"), "The page URL is not what you expected.");

            driver.Navigate().Back();
            driver.Navigate().Back();

            OpenMenuButton();

            IWebElement answersButton = driver.FindElement(By.XPath("//a[@href='/?mod=answers']"));
            IWebElement elementAnswersButton = wait.Until(driver => driver.FindElement(By.XPath("//a[@href='/?mod=answers']")));
            answersButton.Click();

            string currentUrlAnswers = driver.Url;
            Assert.That(currentUrlAnswers, Is.EqualTo("http://seasonvar.ru/?mod=answers"), "The page URL is not what you expected.");

            driver.Navigate().Back();

            OpenMenuButton();

            IWebElement historyButton = driver.FindElement(By.XPath("//a[@href='/?mod=history']"));
            IWebElement elementHistoryButton = wait.Until(driver => driver.FindElement(By.XPath("//a[@href='/?mod=history']")));
            historyButton.Click();

            string currentUrlHistory = driver.Url;
            Assert.That(currentUrlHistory, Is.EqualTo("http://seasonvar.ru/?mod=history"), "The page URL is not what you expected.");

            driver.Navigate().Back();

            OpenMenuButton();

            IWebElement exitButton = driver.FindElement(By.XPath("//a[@href='/?mod=logout']"));
            IWebElement elementExitButton = wait.Until(driver => driver.FindElement(By.XPath("//a[@href='/?mod=logout']")));
            exitButton.Click();

            IWebElement elementSignInButton = wait.Until(driver => driver.FindElement(By.XPath("//a[@href = '/?mod=login']")));
            Assert.IsTrue(elementSignInButton.Displayed, "The element does not appear on the page.");

            driver.Quit();
        }
    }
}