namespace SchoolSystem.Models.Contracts
{
    /// <summary>
    /// Interface for Person with basic attributes - firstname and lastname
    /// </summary>
    public interface IPerson
    {
        string FirstName { get; set; }

        string LastName { get; set; }
    }
}
