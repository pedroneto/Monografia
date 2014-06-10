using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.com.hp.hpl.jena.rdf.arp
{
    public interface StatementHandler
    {
        /** A triple in the file.
         * @param subj The subject.
         * @param pred The property.
         * @param obj The object.
         */
        public void statement(AResource subj, AResource pred, AResource obj);
        /** A triple in the file.
         * @param subj The subject.
         * @param pred The property.
         * @param lit The object.
         */
        public void statement(AResource subj, AResource pred, ALiteral lit);

    }
}
