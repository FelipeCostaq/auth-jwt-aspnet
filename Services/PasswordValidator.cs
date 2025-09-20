namespace AuthFinance.Services
{
    public class PasswordValidator
    {
        public static bool StrongPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (password.Length < 8)
                return false;

            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).+$");
            return regex.IsMatch(password);
        }
    }
}
