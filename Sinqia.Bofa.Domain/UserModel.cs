using System.ComponentModel.DataAnnotations;

namespace Sinqia.Bofa.Domain
{
    public class UserModel
    {
        #region constructor

        public UserModel() { }

        public UserModel(string? name = null, string? password = null, string? email = null) 
        {
            Name = name;
            Password = password;
            Email = email;
        }

        #endregion

        #region properties

        public string? Name { get; private set; }

        public string? Password { get; private set; }

        public string? Email { get; private set; }

        #endregion
    }
}
