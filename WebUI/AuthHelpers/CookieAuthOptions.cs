namespace WebUI.AuthHelpers
{
    public class CookieAuthOptions
    {
        public string? Name { get; set; }
        public string? LoginPath { get; set; }
        public string? LogOutPath { get; set; }
        public string? AccessDeniedPath { get; set; }
        public bool SlidingExpiration { get; set; }
        public int TimeOut { get; set; }
    }
}
