namespace Caliburn.Silverlight.NavigationShell.Framework
{
    public interface IDataCentric<TData>
    {
        void LoadData(TData data);
    }
}