using Np.Security.Certificates.Enums;
using System;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Np.Security.Models
{
    public class CertificateSettingsBase64 : CertificateSettings
    {
        private X509Certificate2 certificate;

        public override CertificateProviderType ProviderType => CertificateProviderType.Base64;

        public string PublicKeyBase64 { get; set; }
        public string PrivateKeyBase64 { get; set; }
        public string Password { get; set; }

        public override X509Certificate2 Certificate
        {
            get
            {
                if (certificate == null)
                {
                    SecureString securePassword = null;
                    if (!string.IsNullOrWhiteSpace(Password))
                    {
                        securePassword = new SecureString();
                        Password.ToCharArray().ToList().ForEach(c => securePassword.AppendChar(c));
                        securePassword.MakeReadOnly();
                    }

                    string privateKeyStr = PrivateKeyBase64
                        .Replace("-----BEGIN PRIVATE KEY-----", null)
                        .Replace("-----END PRIVATE KEY-----", null);

                    using var rsa = RSA.Create();
                    if (securePassword is null)
                        rsa.ImportPkcs8PrivateKey(Convert.FromBase64String(privateKeyStr).ToArray()
                     , out _);
                    else
                        rsa.ImportEncryptedPkcs8PrivateKey(Password, Convert.FromBase64String(privateKeyStr).ToArray(), out _);

                    string publicKeyStr = PublicKeyBase64
                          .Replace("-----BEGIN CERTIFICATE-----", null)
                          .Replace("-----END CERTIFICATE-----", null);

                    using var pubCert = new X509Certificate2(Convert.FromBase64String(publicKeyStr));
                    using var withPrivCert = pubCert.CopyWithPrivateKey(rsa);
                    certificate = new X509Certificate2(withPrivCert.Export(X509ContentType.Pfx));
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
