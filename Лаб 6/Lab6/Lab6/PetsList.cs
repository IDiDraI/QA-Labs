using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Lab5
{
    public class Pet
    {
        public string Name { get; set; }

        public string BirthDay { get; set; }

        public string Type { get; set; }
    }

    public class PetsList
    {
        public List<Pet> Pets;

        public PetsList(IConfigurationRoot configuration)
        {
            Pets = configuration.GetSection("pets").Get<List<Pet>>();
        }
    }
}
