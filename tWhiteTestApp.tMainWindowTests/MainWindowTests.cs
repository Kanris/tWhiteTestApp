using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.Factory;

namespace tWhiteTestApp.tMainWindowTests
{
    [TestClass]
    public class MainWindowTests
    {
        [TestMethod]
        public void PerformCalculation()
        {
            var applicationDirectory = TestContext.TestDeploymentDir;

            var applicationPath = Path.Combine(applicationPath, "foo.exe");
            Application application = Application.Launch(applicationPath);
            Window window = application.GetWindow("bar", InitializeOption.NoCache);
        }
    }
}
