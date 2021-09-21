using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Np.AspNetCore.Authorization.OpenApi.Swagger.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerDocSettings
    {
        /// <summary>
        /// Document version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Dcument title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Document description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// URI to the Terms of Service for using the document.
        /// </summary>
        public string TermsOfServiceUri { get; set; }

        /// <summary>
        /// Contact.
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// License.
        /// </summary>
        public License License { get; set; }
    }
}
