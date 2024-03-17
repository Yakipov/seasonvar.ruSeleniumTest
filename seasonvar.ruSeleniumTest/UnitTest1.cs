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
            // Открытие сайта 
            driver.Navigate().GoToUrl("http://seasonvar.ru/");
            // Максимальное окно браузера 
            driver.Manage().Window.Maximize();


            // Находим кнопку входа и кликаем по ней
            IWebElement signInButton = driver.FindElement(By.XPath("//a[@href = '/?mod=login']"));
            signInButton.Click();

            // Создание объекта WebDriverWait для ожидания появления элементов на странице.
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(driver => driver.FindElement(By.XPath("//input[@placeholder='E-mail']")));

            // Находим поле ввода логина и вводим логин.
            IWebElement loginField = driver.FindElement(By.XPath("//input[@placeholder='E-mail']"));
            loginField.Click();
            loginField.SendKeys(Login);

            // Находим поле ввода пароля и вводим пароль.
            IWebElement passwordField = driver.FindElement(By.XPath("//input[@type='password']"));
            passwordField.Click();
            passwordField.SendKeys(Password);

            // Находим кнопку входа и кликаем по ней.
            IWebElement loginButton = driver.FindElement(By.XPath("//button[@type='submit' and @class='btn']"));
            loginButton.Click();

            // Ожидание появления элемента с именем пользователя после входа.
            IWebElement usernameElement = wait.Until(driver => driver.FindElement(By.XPath("//li[@class='headmenu-title']")));
            Assert.IsNotNull(usernameElement, "Элемент с именем пользователя не найден. Вход не выполнен.");
        }

        [Test]
        public void TestPart2_CheckPopupMenu() 
        {
            // Создание объекта WebDriverWait для ожидания
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Создаем экземпляр класса Actions
            Actions actions = new Actions(driver);

            // Находим кнопку меню и кликаем по ней.
            IWebElement menuButton = driver.FindElement(By.XPath("//button[@type='submit' and @data-menu='head']"));
            menuButton.Click();
            // Кликаем на кнопку меню с помощью метода Click
            actions.Click(menuButton).Perform();

            // Находим Премиум аккаунт в меню и кликаем по ней.
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