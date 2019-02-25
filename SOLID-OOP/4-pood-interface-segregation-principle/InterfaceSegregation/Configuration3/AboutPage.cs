using System.IO;
using InterfaceSegregation.Configuration1;

namespace InterfaceSegregation.Configuration3
{
    public class AboutPage
    {
        private readonly IApplicationIdentitySettings _applicationIdentitySettings;

        public AboutPage(IApplicationIdentitySettings applicationIdentitySettings)
        {
            _applicationIdentitySettings = applicationIdentitySettings;
        }
        
        // TODO: Fix
        public AboutPage()
            : this(ConfigurationSettings.Settings)
        { }

        public void Render(TextWriter writer)
        {
            writer.Write("{0} By {1}",
                _applicationIdentitySettings.ApplicationName,
                _applicationIdentitySettings.AuthorName);
        }
    }

    public interface IApplicationIdentitySettings
    {
        string ApplicationName { get; }
        string AuthorName { get; }
    }
}