using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeESI
{
    namespace dogma
    {
        public class Attributes
        {
            public int attribute_id { get; set; }
            public float value { get; set; }

            public Attributes()
            {
            }

            public override string ToString()
            {
                return $"attributeID: {attribute_id} value: {value}";
            }
        }


        public class Effects
        {
            public int effect_id { get; set; }
            public Boolean is_default { get; set; }

            public Effects()
            {
            }

            public override string ToString()
            {
                return $"effectID: {effect_id} isDefault {is_default}";
            }
        }
    }
}
