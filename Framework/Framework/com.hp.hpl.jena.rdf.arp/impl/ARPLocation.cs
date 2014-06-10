using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.xml.sax.Locator;

namespace Framework.com.hp.hpl.jena.rdf.arp.impl
{
    public class ARPLocation : Locator {
        public sealed String inputName;
        sealed String publicId;
        public sealed int endLine;
        public sealed int endColumn;
        ARPLocation(Locator locator) {
    	    if (locator==null){
    	      inputName = "unknown-source";
    	      publicId = "unknown-source";
    	      endLine = -1;
    	      endColumn = -1;
    	    }else {
            inputName = locator.getSystemId();
            endLine = locator.getLineNumber();
            endColumn = locator.getColumnNumber();
            publicId = locator.getPublicId();
    	    }
        }
        
        String toString() {
            return //"before column " + endColumn +
            "line " + endLine + " in '"
            + inputName + "'";
        }
    
        String getSystemId() {
            return inputName;
        }
    
        int getLineNumber() {
            return endLine;
        }
    
        int getColumnNumber() {
            return endColumn;
        }
    
        String getPublicId() {
            return publicId;
        }
    
    }
}
