namespace Dom;

sealed class Member : Entity
{
    public ulong MemberNumber { get; set; }
    public DateOnly SignupDate { get; set; }

    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Designation { get; set; }
    public string Email { get; init; }
    public DateOnly BirthDay { get; set; }
    public string Gender { get; set; }
    public string MobileNumber { get; init; }
    public Address Address { get; set; }
}