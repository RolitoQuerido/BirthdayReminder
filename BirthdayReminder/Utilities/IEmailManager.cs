namespace BirthdayReminder.Utilities
{
    public interface IEmailManager
    {
        void SendBirthdayEmail(string body);
    }
}