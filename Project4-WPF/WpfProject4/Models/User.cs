using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BCrypt.Net;

namespace WpfProject4.Models
{
    public class User
    {
        #region properties
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion

        #region methodes
        //Verifeer wachtwoord input en geef bool terug als ingevoerde wachtwoord overeenkomt met hash
        public bool VerifyLogin(string passwordInput)
        {
            bool succes = false;

            try
            {                
                succes = BCrypt.Net.BCrypt.Verify(passwordInput, this.Password);
            }
            catch (Exception)
            {
                MessageBox.Show("Fout opgetreden!\nNeem contact op met de service desk!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return succes;
        }
        #endregion
    }
}
