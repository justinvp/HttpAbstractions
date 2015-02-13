// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNet.Http.Security;

namespace Microsoft.AspNet.Http
{
    public abstract class HttpResponse
    {
        // TODO - review IOwinResponse for completeness

        public abstract HttpContext HttpContext { get; }
        public abstract int StatusCode { get; set; }
        public abstract IHeaderDictionary Headers { get; }
        public abstract Stream Body { get; set; }

        public abstract long? ContentLength { get; set; }
        public abstract string ContentType { get; set; }

        public abstract IResponseCookies Cookies { get; }

        public abstract bool HeadersSent { get; }

        public abstract void OnSendingHeaders(Action<object> callback, object state);

        public virtual void Redirect(string location)
        {
            Redirect(location, permanent: false);
        }

        public abstract void Redirect(string location, bool permanent);

        public virtual void Challenge()
        {
            Challenge(new string[0]);
        }

        public virtual void Challenge(AuthenticationProperties properties)
        {
            Challenge(properties, new string[0]);
        }

        public virtual void Challenge(string authenticationScheme)
        {
            Challenge(new[] { authenticationScheme });
        }

        public virtual void Challenge(AuthenticationProperties properties, string authenticationScheme)
        {
            Challenge(properties, new[] { authenticationScheme });
        }

        public virtual void Challenge(params string[] authenticationSchemes)
        {
            Challenge((IEnumerable<string>)authenticationSchemes);
        }

        public virtual void Challenge(IEnumerable<string> authenticationSchemes)
        {
            Challenge(properties: null, authenticationSchemes:  authenticationSchemes);
        }

        public virtual void Challenge(AuthenticationProperties properties, params string[] authenticationSchemes)
        {
            Challenge(properties, (IEnumerable<string>)authenticationSchemes);
        }

        public abstract void Challenge(AuthenticationProperties properties, IEnumerable<string> authenticationSchemes);

        public virtual void SignIn(ClaimsIdentity identity)
        {
            SignIn(properties: null, identity: identity);
        }

        public virtual void SignIn(AuthenticationProperties properties, ClaimsIdentity identity)
        {
            SignIn(properties, new[] { identity });
        }

        public virtual void SignIn(params ClaimsIdentity[] identities)
        {
            SignIn(properties: null, identities: (IEnumerable<ClaimsIdentity>)identities);
        }

        public virtual void SignIn(IEnumerable<ClaimsIdentity> identities)
        {
            SignIn(properties: null, identities: identities);
        }

        public virtual void SignIn(AuthenticationProperties properties, params ClaimsIdentity[] identities)
        {
            SignIn(properties, (IEnumerable<ClaimsIdentity>)identities);
        }

        public abstract void SignIn(AuthenticationProperties properties, IEnumerable<ClaimsIdentity> identities);

        public virtual void SignOut()
        {
            SignOut(new string[0]);
        }

        public virtual void SignOut(string authenticationScheme)
        {
            SignOut(new[] { authenticationScheme });
        }

        public abstract void SignOut(IEnumerable<string> authenticationSchemes);
    }
}
