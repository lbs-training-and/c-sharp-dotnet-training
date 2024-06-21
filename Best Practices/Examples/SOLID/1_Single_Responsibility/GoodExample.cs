// User.cs
public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
}

// UserRepository.cs
public class UserRepository
{
    public void SaveToDatabase(User user)
    {
        // Code to save user to database
    }
}

// EmailService.cs
public class EmailService
{
    public void SendEmail(User user)
    {
        // Code to send email to user
    }
}