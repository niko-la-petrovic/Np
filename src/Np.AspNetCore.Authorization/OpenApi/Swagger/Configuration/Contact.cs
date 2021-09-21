using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Np.AspNetCore.Authorization.OpenApi.Swagger.Configuration
{
    /// <summary>
    /// Represents a Swagger document contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Related contact URI.
        /// </summary>
        public string Uri { get; set; }
    }
}
