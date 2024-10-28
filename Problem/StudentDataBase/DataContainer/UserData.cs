using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.DataContainer
{
    internal abstract class UserData
    {
        public string? Role { get; protected set; }
        public string? Name { get; protected set; }
        public string? LastName { get; protected set; }
        public string? Address { get; protected set; }
        public const int NUMBER_OF_DIGITS_PESSEL = 11;
        public const int NUMBER_OF_DIGITS_ALBUM_NUMBER = 5;

        private string? _albumNumber;

        public string AlbumNumber
        {
            get { return _albumNumber ?? "Unknown"; }
            set
            {
                if (value.Length != NUMBER_OF_DIGITS_ALBUM_NUMBER || string.IsNullOrWhiteSpace(value))
                {
                    _albumNumber = "Unknown";
                }
                else
                {
                    _albumNumber = value;
                }
            }
        }

        private string? _pesselNumber;
        public string PesselNumber
        {
            get
            {
                if (_pesselNumber != null)
                    return _pesselNumber;
                else
                    return _pesselNumber = string.Empty;
            }
            set
            {
                if (value.Length != NUMBER_OF_DIGITS_PESSEL || value == null)
                {
                    _pesselNumber = "Unknown";
                }
                else
                {
                    _pesselNumber = value;
                }
            }
        }

        public string? Sex { get; set; }
        public string? Password { get; set; }
        public abstract void ShowInfo();
    }
}
