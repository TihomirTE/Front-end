namespace Academy.Models.Section_I
{
    using System;

    public abstract class User : IUser
    {
        private const int MinUserNameLength = 3;
        private const int MaxUserNameLength = 16;

        private string username;

        public User(string username)
        {
            this.username = Username;
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                if (value.Length < MinUserNameLength || value.Length > MaxUserNameLength)
                {
                    throw new ArgumentOutOfRangeException("User's username should be between 3 and 16 symbols long!");
                }

                username = value;
            }
        }
        
    }
}
