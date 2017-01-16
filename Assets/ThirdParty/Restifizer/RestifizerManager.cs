using UnityEngine;
using System.Collections;

namespace Restifizer
{
    public class RestifizerManager: MonoBehaviour, RestifizerParams
    {
		
        public string baseUrl;
        public MonoBehaviour errorHandler;
        public static RestifizerManager Instance;
		
        private string clientId;
        private string clientSecret;
        private string accessToken;

        private string jwtSecret;
        private JWT.JwtHashAlgorithm jwtAlgo;
        private string jwtToken;

        void Start()
        {
            Instance = this;
        }

        void Awake()
        {
            if (errorHandler != null && !(errorHandler is IErrorHandler))
            {
                Debug.LogError("Wrong ErrorHandler, it should implement IErrorHandler");
            }
        }

        public RestifizerManager ConfigClientAuth(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            return this;
        }

        public RestifizerManager ConfigBearerAuth(string accessToken)
        {
            this.accessToken = accessToken;
            return this;
        }

        public RestifizerManager ConfigJWTAuth(JWT.JwtHashAlgorithm algo, string secret)
        {
            this.jwtAlgo = algo;
            this.jwtSecret = secret;
            return this;
        }

        public RestifizerManager ConfigJWTToken(string token)
        {
            this.jwtToken = token;
            return this;
        }

        public RestifizerRequest ResourceAt(string resourceName)
        {
            RestifizerRequest restifizerRequest = new RestifizerRequest(this, (IErrorHandler)errorHandler);
            restifizerRequest.FetchList = true;
            restifizerRequest.Path += baseUrl + "/" + resourceName;
            return restifizerRequest;
        }
		
		
        /* RestifizerParams */
        public string GetClientId()
        {
            return clientId;
        }

        public string GetClientSecret()
        {
            return clientSecret;
        }

        public string GetAccessToken()
        {
            return accessToken;
        }

        public JWT.JwtHashAlgorithm GetJWTAlgorithm()
        {
            return jwtAlgo;
        }

        public string GetJWTSecret()
        {
            return jwtSecret;
        }

        public string GetJWTToken()
        {
            return jwtToken;
        }
    }
}
