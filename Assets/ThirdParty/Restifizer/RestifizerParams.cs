using UnityEngine;
using System.Collections;

namespace Restifizer
{
    public interface RestifizerParams
    {
        string GetClientId();

        string GetClientSecret();

        string GetAccessToken();

        JWT.JwtHashAlgorithm GetJWTAlgorithm();

        string GetJWTSecret();

        string GetJWTToken();
    }
}
