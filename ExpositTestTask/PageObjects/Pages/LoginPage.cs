using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ExpositTestTask.PageObject.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "txtUsername")]
        private IWebElement _loginInputField;

        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement _passwordInputField;

        [FindsBy(How = How.Id, Using = "btnLogin")]
        private IWebElement _loginButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[2]/span")]
        private IWebElement _credentialsField;

        private (string, string) GetUsernameAndPassword()
        {
            var rawText = _credentialsField.Text;
            var indexOfSeparator = rawText.IndexOf('|');
            var indexOfClosingParenthesis = rawText.IndexOf(')');
            var startIndexOfUsername = rawText.IndexOf(": ", StringComparison.Ordinal) + 2;
            var startIndexOfPassword = rawText.LastIndexOf(": ", StringComparison.Ordinal) + 2;

            var username = rawText.Substring(startIndexOfUsername, indexOfSeparator - startIndexOfUsername - 1);
            var password = rawText.Substring(startIndexOfPassword, indexOfClosingParenthesis - startIndexOfPassword - 1);

            return (username, password);
        }

        public void GoToPage()
        {
            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/auth/login");
        }

        public void EnterLogin()
        {
            _loginInputField.SendKeys(GetUsernameAndPassword().Item1);
        }

        public void EnterPassword()
        {
            _passwordInputField.SendKeys(GetUsernameAndPassword().Item2);
        }

        public void Login()
        {
            _loginButton.Click();
        }
    }
}
