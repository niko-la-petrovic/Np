using Np.Security.Certificates.Enums;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Np.Security.Models
{
    public abstract class CertificateSettings : IDisposable
    {
        public abstract CertificateProviderType ProviderType { get; }
        public abstract X509Certificate2 Certificate {get;}

        public abstract void Dispose();
    }
}
