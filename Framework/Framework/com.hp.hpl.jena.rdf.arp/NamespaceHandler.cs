using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.com.hp.hpl.jena.rdf.arp
{
    public interface NamespaceHandler
    {
        /**
	    * A namespace prefix is being defined..
	    * 
	    * @param prefix
	    *            the name of the prefix (ie the X in xmlns:X=U)
	    * @param uri
	    *            the uri string (ie the U)
	    */
        public void startPrefixMapping(String prefix, String uri);
        /**
            * A namespace prefix is going out of scope.
            * There is no guarantee that start and end PrefixMapping
            * calls nest.
            * 
            * @param prefix
            *            the name of the prefix (ie the X in xmlns:X=U)
            * 
            * 
            */
        public void endPrefixMapping(String prefix);
    }
}
