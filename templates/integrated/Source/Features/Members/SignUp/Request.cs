using MyProject;
using FluentValidation;

namespace Members.Signup;

sealed class Request
{
    //request dto shape is dictated by front-end team

    public User UserDetails { get; set; }
    public string Email { get; set; }
    public string BirthDay { get; set; }
    public string Gender { get; set; }
    public ContactDetails Contact { get; set; }
    public AddressDetails Address { get; set; }

    public sealed class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public sealed class ContactDetails
    {
        public string MobileNumber { get; set; }
        public bool Whatsapp { get; set; }
        public bool Viber { get; set; }
        public bool Telegram { get; set; }
    }

    public sealed class AddressDetails
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.UserDetails.FirstName).Length(3, 100).WithMessage("Invalid First Name!");
            RuleFor(x => x.UserDetails.LastName).Length(3, 100).WithMessage("Invalid Last Name!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email address is required!");
            RuleFor(x => x.BirthDay).Must(bDay => bDay.IsAValidBirthDay()).WithMessage("Birthday is required!");
            RuleFor(x => x.Gender).Must(gender => gender.IsAValidGender()).WithMessage("Gender is required!");
            RuleFor(x => x.Contact.MobileNumber).Must(mob => mob.IsAValidMobileNumber()).WithMessage("Invalid mobile number!");
            RuleFor(x => x.Address.Street).NotEmpty().WithMessage("Street is required!");
            RuleFor(x => x.Address.City).NotEmpty().WithMessage("City is required!");
            RuleFor(x => x.Address.State).NotEmpty().WithMessage("District is required!");
            RuleFor(x => x.Address.ZipCode).NotEmpty().WithMessage("Postal code is required!");
        }
    }
}