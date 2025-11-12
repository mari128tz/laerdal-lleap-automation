namespace LaerdalLLEAPTests.Tests
{
    public class LLEAPTests : BaseTest
    {
        [Test]
        public void Test1()
        {
            //Step 2
            HomePage.ClickInstructorApplication();
            //Step 3
            InstructorApp.ClickAddLicenseLater();
            //Step 4
            InstructorApp.ClickLocalComputer();
            //Step 5
            InstructorApp.ClickSimMan3GPlus();
            //Step 6
            InstructorApp.ClickManualMode();
            //Step 8
            InstructorApp.ClickTheme_HealthyPatient();
            //Step 9
            InstructorApp.ClickSelectThemeOk();
            //Step 9
            InstructorApp.ClickStartSession();
            //Step 10
            InstructorApp.MaximizeLLEAP();
            
            Assert.Pass("Successfully completed Test #1 steps 1-11");
        }
    }
}   