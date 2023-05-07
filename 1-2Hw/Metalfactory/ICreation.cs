using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalfactory
{
    interface  ICreation
    {
        public void Concentrate();
        public void Forming();
        public void Melt();
        public Ingot Result();
    }
}
