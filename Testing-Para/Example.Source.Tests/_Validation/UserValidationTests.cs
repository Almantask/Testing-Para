using FluentAssertions;
using System.Text.RegularExpressions;

namespace Example.Source._Validation
{
    public class UserValidationTests
    {
        private readonly UserValidator _validator;
        private readonly User _user;

        private const string validPassword = "AB!12abc";
        private const string validUsername = "Kai";

        public UserValidationTests()
        {
            _validator = new UserValidator();
            _user = new User
            {
                Username = validUsername,
                Password = validPassword
            };
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("12345678901234567890123456")]
        public void Validate_WhenInvalidUsername_Throws(string invalidUsername)
        {
            _user.Username = invalidUsername;

            Action validate = () => _validator.ValidateUser(_user);

            validate.Should().Throw<ArgumentException>();
        }

        // No need overly too many combos
        [Theory]
        [InlineData("", "empty")]
        [InlineData(null, "no password")]
        [InlineData("AAAAAAA", "at least 8 symbols required")]
        [InlineData("AAAAAAAA", "at least 2 digits required")]
        [InlineData("AAAAAA11", "at least 3 lowercase required")]
        [InlineData("aaaAAA11", "special character required")]
        [InlineData("aaaa!A11", "at least 2 uppercase required")]
        public void Validate_WhenWeakPassword_Throws(string weakPassword, string because)
        {
            _user.Password = weakPassword;

            Action validate = () => _validator.ValidateUser(_user);

            validate.Should().Throw<ArgumentException>(because);
        }

        [Fact]
        public void Validate_WhenValid_DoesNotThrow()
        {
            var user = new User
            {
                Username = validUsername,
                Password = validPassword
            };

            Action validate = () => _validator.ValidateUser(user);

            validate.Should().NotThrow();
        }

        //public const int MaxUsernameLength = 25;

        //public void ValidateUser(User user)
        //{
        //    if (string.IsNullOrEmpty(user.Username))
        //    {
        //        throw new ArgumentException("Must provide a username");
        //    }

        //    if(user.Username.Length > MaxUsernameLength) 
        //    {
        //        throw new ArgumentException($"Username is too long. Max length - {MaxUsernameLength}");
        //    }

        //    const string passwordRegex = "^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$";
        //    if (Regex.IsMatch(user.Username, passwordRegex))
        //    {
        //        throw new ArgumentException("Weak password. Must contain at least:" +
        //            "two upper case," +
        //            "one special char," +
        //            "two digits," +
        //            "three lowercase" +
        //            "8 symbols long");
        //    }
        //}
    }
}
