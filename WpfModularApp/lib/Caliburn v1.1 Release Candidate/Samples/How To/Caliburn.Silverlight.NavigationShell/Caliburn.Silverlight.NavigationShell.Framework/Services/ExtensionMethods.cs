namespace Caliburn.Silverlight.NavigationShell.Framework.Services
{
    using System.IO;
    using System.Reflection;
    using System.Windows.Documents;
    using System.Windows.Markup;
    using System.Windows.Media.Imaging;

    public static class ExtensionMethods
    {
        public static string GetExecutingAssemblyName()
        {
            return GetAssemblyName(Assembly.GetExecutingAssembly());
        }

        public static string GetAssemblyName(this Assembly assembly)
        {
            string name = assembly.FullName;
            return name.Substring(0, name.IndexOf(','));
        }

        public static Stream GetStream(this IResourceManager resourceManager, string relativeUri)
        {
            return resourceManager.GetStream(relativeUri, GetExecutingAssemblyName());
        }

        public static BitmapImage GetBitmap(this IResourceManager resourceManager, string relativeUri, string assemblyName)
        {
            var s = resourceManager.GetStream(relativeUri, assemblyName);
            if (s == null) return null;

            using (s)
            {
                var bmp = new BitmapImage();
                bmp.SetSource(s);
                return bmp;
            }
        }

        public static BitmapImage GetBitmap(this IResourceManager resourceManager, string relativeUri)
        {
            return resourceManager.GetBitmap(relativeUri, GetExecutingAssemblyName());
        }

        public static string GetString(this IResourceManager resourceManager, string relativeUri, string assemblyName)
        {
            var s = resourceManager.GetStream(relativeUri, assemblyName);
            if (s == null) return null;
            using (var reader = new StreamReader(s))
            {
                return reader.ReadToEnd();
            }
        }

        public static string GetString(this IResourceManager resourceManager, string relativeUri)
        {
            return resourceManager.GetString(relativeUri, GetExecutingAssemblyName());
        }

        public static FontSource GetFontSource(this IResourceManager resourceManager, string relativeUri, string assemblyName)
        {
            var s = resourceManager.GetStream(relativeUri, assemblyName);
            if (s == null) return null;

            using (s)
            {
                return new FontSource(s);
            }
        }

        public static FontSource GetFontSource(this IResourceManager resourceManager, string relativeUri)
        {
            return resourceManager.GetFontSource(relativeUri, GetExecutingAssemblyName());
        }

        public static object GetXamlObject(this IResourceManager resourceManager, string relativeUri, string assemblyName)
        {
            string str = resourceManager.GetString(relativeUri, assemblyName);

            return (str == null)
                       ? null
                       : XamlReader.Load(str);
        }

        public static object GetXamlObject(this IResourceManager resourceManager, string relativeUri)
        {
            return resourceManager.GetXamlObject(relativeUri, GetExecutingAssemblyName());
        }
    }
}