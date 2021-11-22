using Np.Security.Certificates.Enums;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Np.Security.Models
{
    public class CertificateSettingsKeyStore : CertificateSettings
    {
        private X509Certificate2 certificate;

        public override CertificateProviderType ProviderType => CertificateProviderType.KeyStore;

        /// <summary>
        /// Case-insensitive members of System.Security.Cryptography.X509Certificates.StoreName
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// Case-insensitive members of System.Security.Cryptography.X509Certificates.StoreLocation
        /// </summary>
        public string StoreLocation { get; set; }
        /// <summary>
        /// Case-insensitive members of System.Security.Cryptography.X509Certificates.X509FindType
        /// </summary>
        public string FindType { get; set; }
        public string FindValue { get; set; }

        public override X509Certificate2 Certificate
        {
            get
            {
                if (certificate is null)
                {
                    var storeName = Enum.Parse<StoreName>(StoreName, true);
                    var storeLocation = Enum.Parse<StoreLocation>(StoreLocation, true);
                    using var store = new X509Store(storeName, storeLocation, OpenFlags.ReadOnly);

                    var validOnly = false;
                    var findType = Enum.Parse<X509FindType>(FindType, validOnly);
                    var certCollection = store.Certificates.Find(findType, FindValue, validOnly);

                    if (certCollection.Count < 1)
                    {
                        certCollection = store.Certificates.Find(findType, FindValue.ToUpper(), validOnly);
                        if (certCollection.Count < 1)
                        {
                            certCollection = store.Certificates.Find(findType, FindValue.ToLower(), validOnly);
                            if (certCollection.Count < 1)
                                throw new InvalidOperationException(nameof(certCollection));
                        }
                    }

                    certificate = certCollection[0];
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
