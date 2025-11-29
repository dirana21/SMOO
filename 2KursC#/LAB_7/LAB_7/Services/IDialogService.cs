namespace LAB_7.Services
{
    public interface IDialogService
    {
        bool Confirm(string message, string title);
        void ShowError(string message, string title);
    }
}
