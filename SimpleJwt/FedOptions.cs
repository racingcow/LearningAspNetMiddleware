using System;

namespace SimpleJwt
{
    public static class FedOptions
    {
        public const string ISSUER = "localhost";
        public const string AUDIENCE = "all";
        public static byte[] KeyBytes => Convert.FromBase64String("UHxNtYMRYwvfpO1dS5pWLKL0M2DgOj40EbN4SoBWgfc=");
    }
}
