using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDomain
{
    public class Brand
    {
        public int id;
        public string name;

        public override string ToString()
        {
            return name;
        }
        public int GetID()
        {
            return id;
        }
    }
}
