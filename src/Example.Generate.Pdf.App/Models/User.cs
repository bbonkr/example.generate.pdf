namespace Example.Generate.Pdf.App.Models;

public abstract class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FullName
    {
        get => $"{FirstName} {LastName}";
    }

    public string PhoneNumber { get; set; } = string.Empty;
}
