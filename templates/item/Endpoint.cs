﻿using FastEndpoints;

namespace FeatureName;

#if (useAttributes)
[HttpPost("api/route/here")]
#endif
#if (useMapper)
sealed class Endpoint : Endpoint<Request, Response, Mapper>
#else
sealed class Endpoint : Endpoint<Request, Response>
#endif
{
#if (!useAttributes)
    public override void Configure()
    {
        Post("api/route/here");
    }
#endif

    public override Task HandleAsync(Request req, CancellationToken ct)
    {
        return Send.OkAsync(Response, ct);
    }
}