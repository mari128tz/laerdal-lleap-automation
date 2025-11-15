using LaerdalLLEAPTests.Pages;

namespace LaerdalLLEAPTests.Tests
{
    public class LLEAPTests : BaseTest
    {
        [Test]
        public void Test1()
        {
            //Step 2 ✓
            InstructorAppDriver = HomePage.ClickInstructorApplication();
            //Step 3 ✓
            InstructorApp = new InstructorAppBoot(InstructorAppDriver);
            InstructorApp.ClickAddLicenseLater();
            //Step 4 ✓
            InstructorApp.ClickLocalComputer();
            //Step 5 ✓
            InstructorApp.ClickSimMan3GPlus();
            //Step 6 ✓
            InstructorApp.ClickManualMode();
            //Step 8 ✓
            InstructorApp.ClickTheme_HealthyPatient();
            //Step 9 ✓
            InstructorApp.ClickSelectThemeOk();
            //Step 10
            InstructorApp.ClickStartSession();
            //Step 11 ✓
            InstructorApp.MaximizeLLEAP();
            //Step 12 ✓
            var runningSession = new RunningSession(InstructorAppDriver);
            runningSession.SelectEyeState_Closed();
            //Step 13 ✓
            runningSession.SetLungCompliance(67);
            //Step14 ✓
            runningSession.SetHR(100);
            //Step 15 ✓
            runningSession.PlayVocals_Coughing();
            //Step 16 ✓
            InstructorApp.CloseApplicationWithX();
            
            Assert.Pass("Successfully completed Test #1!");
        }
    }
}