namespace SayHello;

sealed class Request
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

sealed class Response
{
    public string Message { get; set; }
}
