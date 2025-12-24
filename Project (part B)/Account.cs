namespace Project__part_B_
{
    public class Account
    {
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public DateTime CreatedAt { get; private set; }

        private string Password;

        public Account(string email, string username, string password)
        {
            Email = email;
            Username = username;
            CreatedAt = DateTime.Now;
            Password = password;
        }

        public bool CheckPassword(string password)
        {
            return Password == password;
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            if (!CheckPassword(oldPassword))
                throw new ArgumentException("Невірний поточний пароль");

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
                throw new ArgumentException("Новий пароль занадто короткий");

            Password = newPassword;
        }

        public void ChangeUsername(string newUsername)
        {
            if (string.IsNullOrWhiteSpace(newUsername))
                throw new ArgumentException("Імʼя користувача не може бути порожнім");

            Username = newUsername;
        }
    }
}
