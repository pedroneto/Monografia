using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.com.hp.hpl.jena.rdf.arp
{
    public interface ExtendedHandler
    {
        /** After this call, no more triples will be reported
	 * which use <code>bnode</code>.
	 * This is called exactly once for each blank nodes. 
	 * Whether this includes nodes  with an <code>rdf:nodeID</code>
	 * is controlled by {@link #discardNodesWithNodeID}.
	 *
	 *<p>
	 *The contract is robust against syntax errors in input, 
	 *and exceptions being thrown by the StatementHandler.
	 *  @param bnode A blank node going out of scope.
	 */
        public void endBNodeScope(AResource bnode);
        /**
         * This method is used to modify the behaviour
         * of ARP concerning its reporting of bnode scope
         * {@link #endBNodeScope}.
         * <p>
         * If this returns true then blank nodes with an <code>rdf:nodeID</code>
         *  are not reported as they go out of scope at the end
         * of file. This eliminates the unbounded memory cost
         * of remembering such nodes.
         * <p>
         * If this returns false then the contract of 
         * {@link #endBNodeScope} is honoured uniformly
         * independent of whether a blank node has a nodeID or not.
         * <p>
         * If this method returns different values during the parsing
         * of a single file, then the behaviour is undefined.
         * @return Desired behaviour of endBNodeScope.
         */
        public bool discardNodesWithNodeID();

        /**
         * Called when the &lt;rdf:RDF&gt; tag is seen.
         * (Also called when there is an implicit start of RDF content
         * when the file consists only of RDF but omits the rdf:RDF tag).
         */
        public void startRDF();

        /**
         * Called when the &lt;/rdf:RDF&gt; tag is seen.
         * (Also called when there is an implicit end of RDF content
         * e.g. when the file consists only of RDF but omits the rdf:RDF tag,
         * or if there is an unrecoverable syntax error mid-file).
         *<p>
         *Robust against syntax errors in input, 
         *and exceptions being thrown by the StatementHandler. 
         */
        public void endRDF();
	
    }
}
