using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ExpositTestTask.PageObject.Pages
{
    public class EmployeeInformation
    {
        private IWebDriver _driver;

        public EmployeeInformation(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "empsearch_id")]
        private IWebElement _searchEmployeeIdInputField;

        [FindsBy(How = How.Id, Using = "searchBtn")]
        private IWebElement _searchButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='resultTable']/tbody/tr/td[3]/a[1]")]
        private IWebElement _firstNameFromSearchResults;

        [FindsBy(How = How.XPath, Using = "//*[@id='resultTable']/tbody/tr/td[4]/a[1]")]
        private IWebElement _lastNameFromSearchResults;

        public void SearchEmployeeByEmployeeId(string employeeId)
        {
            _searchEmployeeIdInputField.SendKeys(employeeId);
            _searchButton.Click();
        }

        public string GetFirstName()
        {
            return _firstNameFromSearchResults.Text;
        }

        public string GetLastName()
        {
            return _lastNameFromSearchResults.Text;
        }
    }
}
