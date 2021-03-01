using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ExpositTestTask.PageObjects.Pages
{
    public class PersonalDetailsPage
    {
        private readonly IWebDriver _driver;

        public PersonalDetailsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "personal_txtEmpFirstName")]
        private IWebElement _firstNameField;

        [FindsBy(How = How.Id, Using = "personal_txtEmpLastName")]
        private IWebElement _lastNameField;

        [FindsBy(How = How.Id, Using = "personal_txtEmployeeId")]
        private IWebElement _employeeIdField;

        public string GetFirstName()
        {
            return _firstNameField.GetAttribute("value");
        }

        public string GetLastName()
        {
            return _lastNameField.GetAttribute("value");
        }

        public string GetEmployeeId()
        {
            return _employeeIdField.GetAttribute("value");
        }
    }
}
