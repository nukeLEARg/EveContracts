using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeESI
{
    class Header
    {

        public string name { get; set; }
        public string CacheControl { get; set; }
        public string ETag { get; set; }
        public string Expires { get; set; }
        public string LastModified { get; set; }
        public int XPages { get; set; }

        public override string ToString()
        {
            return " name:" + name + "CacheControl:" + CacheControl + "ETag:" + ETag + "Expires:" + Expires + "LastModified:" + LastModified + "XPages:" + XPages;
        }
    }
}
