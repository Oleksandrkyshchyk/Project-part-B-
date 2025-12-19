namespace Project__part_B_
{
    public class Account
    {
        public string Email { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public void ChangePassword(string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}