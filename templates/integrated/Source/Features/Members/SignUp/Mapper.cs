using Dom;

namespace Members.Signup;

sealed class Mapper : RequestMapper<Request, Member>
{
    public override Member ToEntity(Request r)
        => new()
        {
            FirstName = r.UserDetails.FirstName.TitleCase(),
            LastName = r.UserDetails.LastName.TitleCase(),
            Email = r.Email.LowerCase(),
            BirthDay = DateOnly.Parse(r.BirthDay),
            Gender = r.Gender.TitleCase(),
            MobileNumber = r.Contact.MobileNumber.Trim(),
            Address = new()
            {
                City = r.Address.City.TitleCase(),
                State = r.Address.State.TitleCase(),
                ZipCode = r.Address.ZipCode.Trim(),
                Street = r.Address.Street.Trim()
            }
        };
}