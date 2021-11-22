using Np.Security.Certificates.Enums;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Np.Security.Models
{
    public class CertificateSettingsPfx : CertificateSettings
    {
        private X509Certificate2 certificate;

        public override CertificateProviderType ProviderType => CertificateProviderType.Pfx;

        public string FilePath { get; set; }
        public string Password { get; set; }
        public string PasswordFilePath { get; set; }

        public override X509Certificate2 Certificate
        {
            get
            {
                if (certificate == null)
                {
                    string password = Password;
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(PasswordFilePath))
                            password = File.ReadAllText(PasswordFilePath);

                        var cert = new X509Certificate2(FilePath, password);
                        certificate = cert;
                    }
                    catch (CryptographicException ex)
                    {
                        throw new InvalidOperationException($"Failed to open PFX certificate at {FilePath}", ex);
                    }
                }

                return certificate;
            }
        }

        public override void Dispose()
        {
            certificate?.Dispose();
        }
    }
}
