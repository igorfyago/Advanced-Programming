using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterfaceSegregation.Configuration3
{
    [TestClass]
    public class AboutPageShould
    {
        [TestMethod]
        public void DisplayApplicationNameFromFile()
        {
            // TODO: Fix
             //still works via file
            var aboutPage = new AboutPage(); // -- hard to TEST!  Need app.config set up just so.
            var textWriter = new StringWriter();
            aboutPage.Render(textWriter);

            var output = textWriter.ToString();

            Assert.AreEqual("Interface Segregation By Steve Smith", output);
        }

        class Settings : IApplicationIdentitySettings
        {
            public string ApplicationName
            {
                get { return "TEST APP NAME"; }
            }

            public string AuthorName
            {
                get { return "TEST AUTHOR NAME"; }
            }
        }

        [TestMethod]
        public void DisplayApplicationNameNoFile()
        {
            // now works without file
            var aboutPage = new AboutPage(new Settings()); 
            var textWriter = new StringWriter();
            aboutPage.Render(textWriter);

            var output = textWriter.ToString();

            Assert.AreEqual("TEST APP NAME By TEST AUTHOR NAME", output);
        }
    }
}
