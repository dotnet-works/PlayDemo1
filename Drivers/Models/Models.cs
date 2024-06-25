namespace PlayDemo1.Drivers.Models
{
    public enum EBrowsersType
    {
        Default,
        Chromium,
        Firefox,
        WebKit,
    }

    public enum ECardsType
    {
        Default,
        // etc..
    }

    public class ConfigData
    {
        public string? BrowserName { get; set; }

        public string? FileName { get; set; }

        public string? ProjectRoot  { get; set; }




}






}