using Metalfactory.MetalsOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Metalfactory
{
    public class Director
    {
        ICreation worker = new Worker();

        public Director(Worker cw) {
            worker = cw;
        }

        public Ingot CreateFullIngot()
        {
            worker.Melt();
            worker.Forming();
            worker.Concentrate();
            return worker.Result();
        }

        public Ingot CreateMeltIngot()
        {
            worker.Forming();
            worker.Melt();
            return worker.Result();
        }

        public Ingot Melt()
        {
            worker.Melt();
            return worker.Result();
        }
    }
}
