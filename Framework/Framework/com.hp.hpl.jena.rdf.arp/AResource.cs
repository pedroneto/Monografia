using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.com.hp.hpl.jena.rdf.arp
{
    public interface AResource
    {
        String getAnonyousID();
        String getURI();
        Object getUserData();
        bool hasNodeId();
        bool isAnonimous();
        void setUserData( Object d );
    }
}
