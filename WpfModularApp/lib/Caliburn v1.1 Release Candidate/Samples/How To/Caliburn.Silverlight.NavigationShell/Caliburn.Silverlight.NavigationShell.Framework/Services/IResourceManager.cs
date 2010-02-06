namespace Caliburn.Silverlight.NavigationShell.Framework.Services
{
    using System.IO;

    public interface IResourceManager 
    {
        Stream GetStream(string relativeUri, string assemblyName);
    }
}