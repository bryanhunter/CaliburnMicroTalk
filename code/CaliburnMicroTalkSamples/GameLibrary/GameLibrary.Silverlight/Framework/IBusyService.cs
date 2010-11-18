namespace GameLibrary.Framework
{
    public interface IBusyService
    {
        void MarkAsBusy(object sourceViewModel, object busyViewModel);
        void MarkAsNotBusy(object sourceViewModel);
    }
}