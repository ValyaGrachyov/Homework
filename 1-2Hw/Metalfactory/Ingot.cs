using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalfactory
{
    public class Ingot
    {
        ArrayList process = new ArrayList();
        public void Add(object action)
        {
            process.Add(action);
        }
    }
}
