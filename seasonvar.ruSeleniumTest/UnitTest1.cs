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
            // �������� ����� 
            driver.Navigate().GoToUrl("http://seasonvar.ru/");
            // ������������ ���� �������� 
            driver.Manage().Window.Maximize();


            // ������� ������ ����� � ������� �� ���
            IWebElement signInButton = driver.FindElement(By.XPath("//a[@href = '/?mod=login']"));
            signInButton.Click();

            // �������� ������� WebDriverWait ��� �������� ��������� ��������� �� ��������.
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(driver => driver.FindElement(By.XPath("//input[@placeholder='E-mail']")));

            // ������� ���� ����� ������ � ������ �����.
            IWebElement loginField = driver.FindElement(By.XPath("//input[@placeholder='E-mail']"));
            loginField.Click();
            loginField.SendKeys(Login);

            // ������� ���� ����� ������ � ������ ������.
            IWebElement passwordField = driver.FindElement(By.XPath("//input[@type='password']"));
            passwordField.Click();
            passwordField.SendKeys(Password);

            // ������� ������ ����� � ������� �� ���.
            IWebElement loginButton = driver.FindElement(By.XPath("//button[@type='submit' and @class='btn']"));
            loginButton.Click();

            // �������� ��������� �������� � ������ ������������ ����� �����.
            IWebElement usernameElement = wait.Until(driver => driver.FindElement(By.XPath("//li[@class='headmenu-title']")));
            Assert.IsNotNull(usernameElement, "������� � ������ ������������ �� ������. ���� �� ��������.");
        }

        [Test]
        public void TestPart2_CheckPopupMenu() 
        {
            // �������� ������� WebDriverWait ��� ��������
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // ������� ��������� ������ Actions
            Actions actions = new Actions(driver);

            // ������� ������ ���� � ������� �� ���.
            IWebElement menuButton = driver.FindElement(By.XPath("//button[@type='submit' and @data-menu='head']"));
            menuButton.Click();
            // ������� �� ������ ���� � ������� ������ Click
            actions.Click(menuButton).Perform();

            // ������� ������� ������� � ���� � ������� �� ���.
            IWebElement premiumAccButton = driver.FindElement(By.XPath("//a[@href='/premium']"));
            premiumAccButton.Click();
            
        }



        [TearDown]
        public void TearDown() 
        {

            // ���� ���������� ����� ����������� ����� test1
            // ����� �� �����
            //driver.Quit();
        }

        
    }
}