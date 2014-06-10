using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.com.hp.hpl.jena.rdf.arp
{
    /**
     * Convenience generalization of all ARP handler interfaces.
     * Sample usage:
     * <pre>
     *    ARPHandler h = new ARPHandler() {
     *     // definitions
     *    };
     *    ARP arp = new ARP();
     *    arp.setStatementHandler(h);
     *    arp.setExtendedHandler(h);
     *    arp.setNamespaceHandler(h);
     * </pre>
    */
    public interface ARPEventHandler : StatementHandler, ExtendedHandler, NamespaceHandler 
    {
        // deliberately empty - add by adding additional super-interfaces.
    }
}
