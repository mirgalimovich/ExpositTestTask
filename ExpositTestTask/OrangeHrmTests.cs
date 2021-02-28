using ExpositTestTask.PageObject.Elements;
using ExpositTestTask.PageObject.Pages;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ExpositTestTask
{
    [TestFixture]
    public class OrangeHrmTests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void NewEmployeeCorrectlyCreated()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.GoToPage();
            loginPage.EnterLogin();
            loginPage.EnterPassword();
            loginPage.Login();

            var headerElement = new HeaderElements(_driver);
            var addEmployeePage = headerElement.GoToAddEmployeePage();

            var generatedEmployeeId = addEmployeePage.GetEmployeeId();
            var generatedFirstName = CommonMethods.GenerateRandomString();
            var generatedLastName = CommonMethods.GenerateRandomString();

            addEmployeePage.EnterFirstName(generatedFirstName);
            addEmployeePage.EnterLastName(generatedLastName);
            var personalDetailsPage = addEmployeePage.Save();

            var actualFirstName = personalDetailsPage.GetFirstName();
            var actualLastName = personalDetailsPage.GetLastName();
            var actualEmployeeId = personalDetailsPage.GetEmployeeId();

            actualEmployeeId.Should().BeEquivalentTo(generatedEmployeeId);
            actualFirstName.Should().BeEquivalentTo(generatedFirstName);
            actualLastName.Should().BeEquivalentTo(generatedLastName);
        }

        [Test]
        public void CreatedEmployeeSuccessfullyAddedToEmployeeList()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.GoToPage();
            loginPage.EnterLogin();
            loginPage.EnterPassword();
            loginPage.Login();

            var headerElement = new HeaderElements(_driver);
            var addEmployeePage = headerElement.GoToAddEmployeePage();

            var generatedFirstName = CommonMethods.GenerateRandomString();
            var generatedLastName = CommonMethods.GenerateRandomString();

            addEmployeePage.EnterFirstName(generatedFirstName);
            addEmployeePage.EnterLastName(generatedLastName);
            var personalDetailsPage = addEmployeePage.Save();

            var firstName = personalDetailsPage.GetFirstName();
            var lastName = personalDetailsPage.GetLastName();
            var employeeId = personalDetailsPage.GetEmployeeId();

            var employeeInformationPage = headerElement.GoToEmployeeInformationPage();
            employeeInformationPage.SearchEmployeeByEmployeeId(employeeId);

            var actualFirstName = employeeInformationPage.GetFirstName();
            var actualLastName = employeeInformationPage.GetLastName();

            actualFirstName.Should().BeEquivalentTo(firstName);
            actualLastName.Should().BeEquivalentTo(lastName);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}