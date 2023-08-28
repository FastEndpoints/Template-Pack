#if (useValidator)
using FastEndpoints;

#endif
namespace FeatureName;

sealed class Request
{

}
#if (useValidator)

sealed class Validator : Validator<Request>
{
    public Validator()
    {
        
    }
}
#endif

sealed class Response
{
    public string Message => "This endpoint hasn't been implemented yet!";
}
