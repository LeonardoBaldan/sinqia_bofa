namespace Sinqia.Bofa.Service.Validation.Interface
{
    public interface IValidationUserService
    {
        #region methods

        string? ValidateEmail(string email);

        string? ValidatePassword(string password);

        #endregion
    }
}
