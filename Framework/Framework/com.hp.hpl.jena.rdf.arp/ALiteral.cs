using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.com.hp.hpl.jena.rdf.arp.impl;

namespace Framework.com.hpl.hp.jena.rdf.arp
{
    public interface ALiteral : ANode
    {
        String getDatatypeURI();
        String getLang();
        String getParseType();
        bool isWellFormedXML();
        String toString();
    }
}
