namespace Caliburn.Silverlight.NavigationShell.Framework.Services
{
    using System;
    using System.IO;
    using System.Windows;

    public class ResourceManager : IResourceManager
    {
        public Stream GetStream(string relativeUri, string assemblyName)
        {
            var resource =
                Application.GetResourceStream(new Uri(assemblyName + ";component/" + relativeUri, UriKind.Relative))
                ?? Application.GetResourceStream(new Uri(relativeUri, UriKind.Relative));

            return (resource != null)
                       ? resource.Stream
                       : null;
        }
    }
}