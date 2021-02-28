using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ExpositTestTask.PageObject.Pages
{
    public class AddEmployeePage
    {
        private IWebDriver _driver;

        public AddEmployeePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement _firstNameInputField;

        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement _lastNameInputField;

        [FindsBy(How = How.Id, Using = "btnSave")]
        private IWebElement _saveButton;

        [FindsBy(How = How.Id, Using = "employeeId")]
        private IWebElement _employeeIdField;

        public void EnterFirstName(string firstName)
        {
            _firstNameInputField.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            _lastNameInputField.SendKeys(lastName);
        }

        public string GetEmployeeId()
        {
            return _employeeIdField.GetAttribute("value");
        }

        public PersonalDetailsPage Save()
        {
            _saveButton.Click();

            return new PersonalDetailsPage(_driver);
        }
    }
}
