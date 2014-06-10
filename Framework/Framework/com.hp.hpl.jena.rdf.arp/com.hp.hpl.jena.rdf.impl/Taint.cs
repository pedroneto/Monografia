using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.com.hp.hpl.jena.rdf.arp.com.hp.hpl.jena.rdf.impl
{
    public interface Taint
    {
        void taint();

        bool isTainted();
    }
}
