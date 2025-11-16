using LaerdalLLEAPTests.Pages;
using LaerdalLLEAPTests.Utilities;
using System;

namespace LaerdalLLEAPTests.Tests
{
    public class LLEAPTests : BaseTest
    {
        [Test]
        public void Test1()
        {
            TestLogger.ClearLog("Test1");
            
            //Step 1 
            try
            {
                Assert.That(Driver, Is.Not.Null, " The application wasn't launched.");
                TestLogger.Log("Test1", " Step 1 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 1 Failed: {ex.Message}");
                throw;
            }
            
            //Step 2 ✓
            try
            {
                InstructorAppDriver = HomePage.ClickInstructorApplication();
                InstructorApp = new InstructorAppBoot(InstructorAppDriver);
                var isInstructorAppRunning = HomePage.IsInstructorAppRunning(InstructorAppDriver);
                Assert.That(isInstructorAppRunning.Displayed, Is.True, "Instructor application wasn't launched.");
                TestLogger.Log("Test1", " Step 2 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 2 Failed: {ex.Message}");
                throw;
            }
            
            //Step 3 ✓
            try
            {
                InstructorApp.ClickAddLicenseLater();
                var isLicenseScreenHandled = InstructorApp.IsLicenseScreenHandled(InstructorAppDriver);
                Assert.That(isLicenseScreenHandled.Displayed, Is.True, "License screen was not handled.");
                TestLogger.Log("Test1", " Step 3 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 3 Failed: {ex.Message}");
                throw;
            }
            
            //Step 4 ✓
            try
            {
                InstructorApp.ClickLocalComputer();
                var isLocalComputerScreenHandled = InstructorApp.IsLocalComputerScreenHandled(InstructorAppDriver);
                Assert.That(isLocalComputerScreenHandled.Displayed, Is.True, "Local computer screen was not handled.");
                TestLogger.Log("Test1", " Step 4 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 4 Failed: {ex.Message}");
                throw;
            }
            
            //Step 5 ✓
            try
            {
                InstructorApp.ClickSimMan3GPlus();
                var isSimManSelected =  InstructorApp.IsSimManSelected(InstructorAppDriver);
                Assert.That(isSimManSelected.Displayed, Is.True, "SimMan selection screen was not handled");
                TestLogger.Log("Test1", " Step 5 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 5 Failed: {ex.Message}");
                throw;
            }
            
            //Step 6 ✓
            try
            {
                InstructorApp.ClickManualMode();
                var isManualModeSelected = InstructorApp.IsManualModeSelected(InstructorAppDriver);
                Assert.That(isManualModeSelected.Displayed, Is.True, "Manual mode was not selected");
                TestLogger.Log("Test1", " Step 6 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 6 Failed: {ex.Message}");
                throw;
            }
            
            //Step 8 ✓
            try
            {
                InstructorApp.ClickTheme_HealthyPatient();
                Assert.That(InstructorApp.IsHealthyPatientSelected(InstructorAppDriver), Is.True, "Healthy patient theme wasn't selected.");
                TestLogger.Log("Test1", " Step 8 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 8 Failed: {ex.Message}");
                throw;
            }
            
            //Step 9 ✓
            try
            {
                InstructorApp.ClickSelectThemeOk();
                var isSessionReadyToStart = InstructorApp.IsSessionReadyToStart(InstructorAppDriver);
                Assert.That(isSessionReadyToStart.Displayed, Is.True, "Session isn't open and ready to start.");
                TestLogger.Log("Test1", " Step 9 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 9 Failed: {ex.Message}");
                throw;
            }
            
            //Step 10
            try
            {
                InstructorApp.ClickStartSession();
                var wasSessionStarted = InstructorApp.WasSessionStarted(InstructorAppDriver);
                Assert.That(wasSessionStarted.Displayed, Is.True, "Session wasn't started.");
                TestLogger.Log("Test1", " Step 10 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 10 Failed: {ex.Message}");
                throw;
            }
            
            //Step 11 ✓
            try
            {
                InstructorApp.MaximizeLLEAP();
                Assert.That(InstructorApp.IsWindowMaximized(InstructorAppDriver), Is.True, "Window was not maximized.");
                TestLogger.Log("Test1", " Step 11 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 11 Failed: {ex.Message}");
                throw;
            }
            
            //Step 12 ✓
            try
            {
                var runningSession = new RunningSession(InstructorAppDriver);
                runningSession.SelectEyeState_Closed();
                Assert.That(runningSession.IsEyeStateClosed(InstructorAppDriver), Is.True, "Eye state not closed.");
                TestLogger.Log("Test1", " Step 12 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 12 Failed: {ex.Message}");
                throw;
            }
            
            //Step 13 ✓
            try
            {
                var runningSession = new RunningSession(InstructorAppDriver);
                runningSession.SetLungCompliance();
                TestLogger.Log("Test1", " Step 13 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 13 Failed: {ex.Message}");
                throw;
            }
            
            //Step14 ✓
            try
            {
                var runningSession = new RunningSession(InstructorAppDriver);
                runningSession.SetHR(100);
                Assert.That(runningSession.IsHR100(InstructorAppDriver), Is.True, "HR wasn't set to 100.");
                TestLogger.Log("Test1", " Step 14 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 14 Failed: {ex.Message}");
                throw;
            }
            
            //Step 15 ✓
            try
            {
                var runningSession = new RunningSession(InstructorAppDriver);
                runningSession.SelectVocals_Coughing();
                Assert.That(runningSession.IsCoughingSelected(InstructorAppDriver), Is.True, "Coughing vocal is was not selected.");
                runningSession.PlaySelectedVocals();
                TestLogger.Log("Test1", " Step 15 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 15 Failed: {ex.Message}");
                throw;
            }
            
            //Step 16 ✓
            try
            {
                var runningSession = new RunningSession(InstructorAppDriver);
                runningSession.CloseApplicationWithX();
                Assert.That(runningSession.DidAppClose(InstructorAppDriver) , Is.True, "App wasn't closed.");
                TestLogger.Log("Test1", " Step 16 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test1", $"✗ Step 16 Failed: {ex.Message}");
                throw;
            }
            
            Assert.Pass("It is possible to run a session using Virtual SimMan3G without the license installed.");
        }

        [Test]
        public void Test2()
        {
            TestLogger.ClearLog("Test2");
            
            //Step 1 
            try
            {
                Assert.That(Driver, Is.Not.Null, " The application wasn't launched.");
                TestLogger.Log("Test2", " Step 1 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test2", $"✗ Step 1 Failed: {ex.Message}");
                throw;
            }
            var initialLogCount =  HomePage.LogCount();
            //Step 2
            try
            {
                HomePage.RightClickHelp();
                Assert.That(HomePage.WasHelpButtonRightClicked().Displayed, Is.True, "Help button was not right clicked.");
                TestLogger.Log("Test2", " Step 2 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test2", $"✗ Step 2 Failed: {ex.Message}");
                throw;
            }
            
            //Step 3
            try
            {
                HomePage.ClickCollectClientLogFiles();
                //Assert.That(WindowSwitcher.IsWindowPresent(Driver, "ClientLogCollect"), Is.True, "Log collection window isn't open.");
                TestLogger.Log("Test2", " Step 3 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test2", $"✗ Step 3 Failed: {ex.Message}");
                throw;
            }
            
            //Step 5
            try
            {
                Thread.Sleep(100000000);
                var finalLogCount = HomePage.LogCount();
                Assert.That(finalLogCount, Is.EqualTo(initialLogCount + 1), "Logs were not saved.");
                TestLogger.Log("Test2", " Step 5 - Pass");
            }
            catch (Exception ex)
            {
                TestLogger.Log("Test2", $"✗ Step 5 Failed: {ex.Message}");
                throw;
            }
        }
    }
}