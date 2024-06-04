using FluentValidation;

namespace SayHello;

sealed class Request
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.FirstName).MinimumLength(3);
            RuleFor(x => x.LastName).MinimumLength(5);
        }
    }
}