namespace AuthFinance.Services
{
    public class UsernameValidator
    {
        public static bool ValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            if (username.Length < 3)
                return false;

            var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9]+$");
            return regex.IsMatch(username);
        }
    }
}
