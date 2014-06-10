using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.com.hp.hpl.jena.rdf.arp.ParseException;

namespace Framework.com.hp.hpl.jena.rdf.arp.impl
{
    public class DefaultErrorHandler : org.xml.sax.ErrorHandler {

        /** Creates new DefaultErrorHandler */
        public DefaultErrorHandler() {
            // no initialization            
            
        }

    
        public void error(org.xml.sax.SAXParseException e) throw org.xml.sax.SAXException {
            Console.SetError("Error: " + ParseException.Message(e));
        }
    
    
        public void fatalError(org.xml.sax.SAXParseException e) throw org.xml.sax.SAXException {
            Console.SetError("Fatal Error: " + ParseException.formatMessage(e));
            throw e;
        }
    
    
        public void warning(org.xml.sax.SAXParseException e) throw org.xml.sax.SAXException {
            Console.SetError("Warning: " + ParseException.formatMessage(e)); 
    //        e.printStackTrace();
        
        }
    
    }
}
