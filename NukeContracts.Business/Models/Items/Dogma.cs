using System.Collections.Generic;

namespace NukeContracts.Business.Models.Items
{
    public class Dogma
    {
        public List<Dogma_attributes> attributes { get; set; }
        public List<Dogma_effects> effects { get; set; }

        public Dogma()
        {
        }
    }

    public class Dogma_attributes
    {
        public int attribute_id { get; set; }
        public decimal value { get; set; }

        public Dogma_attributes()
        {
        }
    }

    public class Dogma_effects
    {
        public int effect_id { get; set; }
        public bool is_default { get; set; }

        public Dogma_effects()
        {
        }
    }
}
