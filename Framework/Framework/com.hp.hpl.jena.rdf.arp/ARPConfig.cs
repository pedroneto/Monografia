using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.com.hpl.hp.jena.rdf.arp
{
    public interface ARPConfig
    {
        ARPHandlers getHandlers();
        void setHandlersWith(ARPHandlers handlers);
        ARPOptions getOptions();
        void setOptionsWith(ARPOptions opts);
    }
}
