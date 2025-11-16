using LaerdalLLEAPTests.Pages;

namespace LaerdalLLEAPTests.Tests
{
    public class LLEAPTests : BaseTest
    {
        [Test]
        public void Test1()
        {
            //Step 1 
                //Verification
            Assert.That(Driver, Is.Not.Null, " The application wasn't launched.");
            
            //Step 2 ✓
                //Action
            InstructorAppDriver = HomePage.ClickInstructorApplication();
            InstructorApp = new InstructorAppBoot(InstructorAppDriver);
                //Verification
                var isInstructorAppRunning = HomePage.IsInstructorAppRunning(InstructorAppDriver);
                Assert.That(isInstructorAppRunning.Displayed, Is.True, "Instructor application wasn't launched.");
                
            //Step 3 ✓
                //Action
            InstructorApp.ClickAddLicenseLater();
                //Verification
                var isLicenseScreenHandled = InstructorApp.IsLicenseScreenHandled(InstructorAppDriver);
                Assert.That(isLicenseScreenHandled.Displayed, Is.True, "License screen was not handled.");
                
            //Step 4 ✓
                //Action
            InstructorApp.ClickLocalComputer();
                //Verification
            var isLocalComputerScreenHandled = InstructorApp.IsLocalComputerScreenHandled(InstructorAppDriver);
            Assert.That(isLocalComputerScreenHandled.Displayed, Is.True, "Local computer screen was not handled.");
            
            //Step 5 ✓
                //Action
            InstructorApp.ClickSimMan3GPlus();
                //Verification
                var isSimManSelected =  InstructorApp.IsSimManSelected(InstructorAppDriver);
                Assert.That(isSimManSelected.Displayed, Is.True, "SimMan selection screen was not handled");
                
            //Step 6 ✓
                //Action
            InstructorApp.ClickManualMode();
                //Verification
                var isManualModeSelected = InstructorApp.IsManualModeSelected(InstructorAppDriver);
                Assert.That(isManualModeSelected.Displayed, Is.True, "Manual mode was not selected");
                
            //Step 8 ✓
                //Action
            InstructorApp.ClickTheme_HealthyPatient();
                //Verification
                Assert.That(InstructorApp.IsHealthyPatientSelected(InstructorAppDriver), Is.True, "Healthy patient theme wasn't selected.");
                
            //Step 9 ✓
                //Action
            InstructorApp.ClickSelectThemeOk();
                //Verification
                var isSessionReadyToStart = InstructorApp.IsSessionReadyToStart(InstructorAppDriver);
                Assert.That(isSessionReadyToStart.Displayed, Is.True, "Session isn't open and ready to start.");
            
            //Step 10
                //Action
            InstructorApp.ClickStartSession();
                //Verification
                var wasSessionStarted = InstructorApp.WasSessionStarted(InstructorAppDriver);
                Assert.That(wasSessionStarted.Displayed, Is.True, "Session wasn't started.");
                
            //Step 11 ✓
                //Action
            InstructorApp.MaximizeLLEAP();
                //Verification
            Assert.That(InstructorApp.IsWindowMaximized(InstructorAppDriver), Is.True, "Window was not maximized.");
            
            //Step 12 ✓
                //Action
            var runningSession = new RunningSession(InstructorAppDriver);
            runningSession.SelectEyeState_Closed();
                //Verification
            Assert.That(runningSession.IsEyeStateClosed(InstructorAppDriver), Is.True, "Eye state not closed.");
            
            //Step 13 ✓
                //Action
            runningSession.SetLungCompliance();
            
            //Step14 ✓
                //Action
            runningSession.SetHR(100);
                //Verification
                Assert.That(runningSession.IsHR100(InstructorAppDriver), Is.True, "HR wasn't set to 100.");
                
            //Step 15 ✓
                //Action
            runningSession.SelectVocals_Coughing();
                //Verification
            Assert.That(runningSession.IsCoughingSelected(InstructorAppDriver), Is.True, "Coughing vocal is was not selected.");
                //Action
            runningSession.PlaySelectedVocals();
            //Step 16 ✓
                //Action
            runningSession.CloseApplicationWithX();
                //Verification
            Assert.That(runningSession.DidAppClose(InstructorAppDriver) , Is.True, "Apppl");
            
            Assert.Pass("Successfully completed Test #1!");
        }

        [Test]
        public void Test2()
        {
            //Step 1 
            //Verification
            Assert.That(Driver, Is.Not.Null, " The application wasn't launched.");
            
        }
        
    }
    
}