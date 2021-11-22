using Microsoft.Extensions.Configuration;
using Np.Security.Certificates.Enums;
using Np.Security.Models;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Np.Security.Certificates
{
    public class ConfigurationCertificateLoader
    {
        public static X509Certificate2 LoadFromSection(IConfigurationSection certSection)
        {
            X509Certificate2 cert = null;
            if (certSection != null && certSection.GetChildren().Any())
            {
                var certProviderTypeStr = certSection.GetSection("ProviderType").Get<string>();
                var certProviderType = Enum.Parse<CertificateProviderType>(certProviderTypeStr, true);

                CertificateSettings certSettings = null;
                switch (certProviderType)
                {
                    case CertificateProviderType.Base64:
                        certSettings = certSection.Get<CertificateSettingsBase64>();
                        break;
                    case CertificateProviderType.KeyStore:
                        certSettings = certSection.Get<CertificateSettingsKeyStore>();
                        break;
                    case CertificateProviderType.Pfx:
                        certSettings = certSection.Get<CertificateSettingsPfx>();
                        break;
                    case CertificateProviderType.Unknown:
                    default:
                        break;
                }
                cert = certSettings.Certificate;
            }

            return cert;
        }
    }
}
