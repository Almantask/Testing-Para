using System.Text.RegularExpressions;

namespace Example.Source._Validation
{
    // Variation 1.3
    public class UserValidator
    {
        public const int MaxUsernameLength = 25;

        public void ValidateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Username))
            {
                throw new ArgumentException("Must provide a username");
            }

            if(user.Username.Length > MaxUsernameLength) 
            {
                throw new ArgumentException($"Username is too long. Max length - {MaxUsernameLength}");
            }

            const string passwordRegex = "^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$";
            if (!Regex.IsMatch(user.Password, passwordRegex))
            {
                throw new ArgumentException("Weak password. Must contain at least:" +
                    "two upper case," +
                    "one special char," +
                    "two digits," +
                    "three lowercase" +
                    "8 symbols long");
            }
        }
    }
}
