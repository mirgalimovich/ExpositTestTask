using ExpositTestTask.PageObjects.Elements;
using ExpositTestTask.PageObjects.Pages;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ExpositTestTask
{
    [TestFixture]
    [Category("Employee creation")]
    public class OrangeHrmUiTests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void Init()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void NewEmployeeCorrectlyCreated()
        {
            new LoginPage(_driver).Login();

            var addEmployeePage = new HeaderElements(_driver).GoToAddEmployeePage();

            var generatedEmployeeId = addEmployeePage.GetEmployeeId();
            var generatedFirstName = CommonMethods.GenerateRandomString();
            var generatedLastName = CommonMethods.GenerateRandomString();

            addEmployeePage.EnterRequiredData(generatedFirstName, generatedLastName);
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
            new LoginPage(_driver).Login();

            var headerElement = new HeaderElements(_driver);
            var addEmployeePage = headerElement.GoToAddEmployeePage();

            var generatedFirstName = CommonMethods.GenerateRandomString();
            var generatedLastName = CommonMethods.GenerateRandomString();

            addEmployeePage.EnterRequiredData(generatedFirstName, generatedLastName);
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
        public void CleanUp()
        {
            _driver.Close();
        }
    }
}