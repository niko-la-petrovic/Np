using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Np.AspNetCore.Authorization.OpenApi.Swagger.Configuration
{
    /// <summary>
    /// Represents a Swagger document license.
    /// </summary>
    public class License
    {
        /// <summary>
        /// License name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// URI to license.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// The equivalent OpenAPI license.
        /// </summary>
        public OpenApiLicense OpenApiLicense => new OpenApiLicense
        {
            Name = Name,
            Url = new Uri(Uri)
        };
    }
}
