namespace BirthdayReminder.Utilities
{
    public interface IDocumentManager
    {
        string ReadFile(string path);
        void WriteFile(string path, string text);
    }
}