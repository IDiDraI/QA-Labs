using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Lab7
{
    public class Owner
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }
    }

    public class OwnersList
    {
        public List<Owner> Owners;

        public OwnersList(IConfigurationRoot configuration)
        {
            Owners = configuration.GetSection("owners").Get<List<Owner>>();
        }
    }
}
