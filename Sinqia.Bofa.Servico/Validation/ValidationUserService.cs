using FluentValidation;
using Sinqia.Bofa.Domain;
using Sinqia.Bofa.Service.Validation.Interface;
using System.Text.RegularExpressions;

namespace Sinqia.Bofa.Service.Validation
{
    public class ValidationUserService : AbstractValidator<UserModel>, IValidationUserService
    {
        #region constructors

        public ValidationUserService() 
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is mandatory");
            RuleFor(x => x.Password).NotNull().WithMessage("Passord is mandatory");
            RuleFor(x => x.Email).NotNull().WithMessage("Email is mandatory");
        }

        #endregion

        #region methods

        public string? ValidateEmail(string email)
        {
            var emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$";

            if (!Regex.IsMatch(email, emailRegex))
                return "Invalid e-mail address";

            return string.Empty;
        }

        public string? ValidatePassword(string password) {

            var passwordRegex = @"^(?=.*\d).+$";

            if (password.Length < 8)
                return "Password must have, at least, 8 characters long";

            if (!Regex.IsMatch(password, passwordRegex))
                return "Password must contain at least one number";

            return string.Empty;

        }

        #endregion
    }
}
