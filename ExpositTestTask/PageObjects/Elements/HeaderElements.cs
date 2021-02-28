using System.Threading;
using ExpositTestTask.PageObject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace ExpositTestTask.PageObject.Elements
{
    public class HeaderElements
    {
        private IWebDriver _driver;

        public HeaderElements(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "menu_pim_viewPimModule")]
        private IWebElement _pimList;

        [FindsBy(How = How.Id, Using = "menu_pim_addEmployee")]
        private IWebElement _addEmployeeLink;

        [FindsBy(How = How.Id, Using = "menu_pim_viewEmployeeList")]
        private IWebElement _employeeListLink;

        public AddEmployeePage GoToAddEmployeePage()
        {
            var actions = new Actions(_driver);
            actions.MoveToElement(_pimList);
            actions.Perform();
            _addEmployeeLink.Click();

            return new AddEmployeePage(_driver);
        }

        public EmployeeInformation GoToEmployeeInformationPage()
        {
            var actions = new Actions(_driver);
            actions.MoveToElement(_pimList);
            actions.Perform();
            _employeeListLink.Click();
            Thread.Sleep(500);

            return new EmployeeInformation(_driver);
        }
    }
}
