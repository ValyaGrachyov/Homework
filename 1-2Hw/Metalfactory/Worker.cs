using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metalfactory.MetalsOperations;

namespace Metalfactory
{
    public class Worker : ICreation
    {
        Ingot ingot = new Ingot();

        
        public void Concentrate()   
        {
            ingot.Add(new Concentrate());
        }

        public void Forming()
        {
            ingot.Add(new Forming());
        }

        public void Melt()
        {
            ingot.Add(new Melt());            
        }

        public Ingot Result()
        {
            return ingot;
        }
    }    
}
