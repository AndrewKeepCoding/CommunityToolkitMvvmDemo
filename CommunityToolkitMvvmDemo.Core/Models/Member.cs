namespace CommunityToolkitMvvmDemo.Core.Models;

public class Member(string firstName, string middleName, string lastName)
{
    public string FirstName { get; set; } = firstName;

    public string MiddleName { get; set; } = middleName;

    public string LastName { get; set; } = lastName;
}
