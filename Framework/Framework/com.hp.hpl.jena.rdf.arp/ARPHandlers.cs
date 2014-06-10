﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.com.hp.hpl.jena.rdf.arp.impl;

namespace Framework.com.hp.hpl.jena.rdf.arp
{
    class ARPHandlers
    {        
        /**
         * Do not use this constructor.
         * An example of not using this constructor is as follows.
         * <br/>
         * Deprecated usage:
         * <br/>
         * <pre>
            ARP arp = new ARP();
            ARPHandlers handlers = new ARPHandlers();
            handlers.setStatementHandler(new MyStatementHandler());
         </pre>
         <br/>
         * Preferred code:
         * <br/>
         * <pre>
            ARP arp = new ARP();
            ARPHandlers handlers = arp.getHandlers();
            handlers.setStatementHandler(new MyStatementHandler());
         </pre>
         */
        //*@ deprecated Use {@link ARPConfig#getHandlers()}
        private ARPHandlers() {}
    
        /** Internal use only */
        public static ARPHandlers createNewHandlers() { return new ARPHandlers() ; }

        private ErrorHandler errorHandler = new DefaultErrorHandler();

        private ExtendedHandler scopeHandler = XMLHandler.nullScopeHandler;

        private StatementHandler statementHandler = XMLHandler.nullStatementHandler;

        private NamespaceHandler nameHandler = new NamespaceHandler() {

            @Override
            public void startPrefixMapping(String prefix, String uri) {

            }

            @Override
            public void endPrefixMapping(String prefix) {

            }
        };

        /**
         * Sets the ExtendedHandler that provides the callback mechanism for bnodes
         * as they leave scope, and for the start and end of rdf:RDF elements.
         * <p>
         * See note about large files in {@link ARP} class documentation.
         * 
         * @param sh
         *            The handler to use.
         * @return The old handler.
         */
        public ExtendedHandler setExtendedHandler(ExtendedHandler sh) {
            ExtendedHandler old = scopeHandler;
            scopeHandler = sh;
            return old;
        }

        /**
         * Sets the NamespaceHandler that provides the callback mechanism for XML
         * namespace declarations.
         * 
         * @param sh
         *            The handler to use.
         * @return The old handler.
         */
        public NamespaceHandler setNamespaceHandler(NamespaceHandler sh) {
            NamespaceHandler old = nameHandler;
            nameHandler = sh;
            return old;
        }

        /**
         * Sets the StatementHandler that provides the callback mechanism for each
         * triple in the file.
         * 
         * @param sh
         *            The statement handler to use.
         * @return The old statement handler.
         */
        public StatementHandler setStatementHandler(StatementHandler sh) {
            StatementHandler old = statementHandler;
            statementHandler = sh;
            return old;
        }

        /**
         * Sets the error handler, for both XML and RDF parse errors. XML errors are
         * reported by Xerces, as instances of SAXParseException; the RDF errors are
         * reported from ARP as instances of ParseException. Code that needs to
         * distingusih between them may look like:
         * 
         * <pre>
         *    void error( SAXParseException e ) throws SAXException {
         *      if ( e instanceof com.hp.hpl.jena.rdf.arp.ParseException ) {
         *           ...
         *      } else {
         *           ...
         *      }
         *    }
         * </pre>
         * 
         * <p>
         * See the ARP documentation for ErrorHandler for details of the
         * ErrorHandler semantics (in particular how to upgrade a warning to an
         * error, and an error to a.errorError).
         * </p>
         * <p>
         * The Xerces/SAX documentation for ErrorHandler is available on the web.
         * </p>
         * 
         * @param eh
         *            The error handler to use.
         * @return The previous error handler.
         */
        public ErrorHandler setErrorHandler(ErrorHandler eh) {
            ErrorHandler old = errorHandler;
            errorHandler = eh;
            return old;
        }

        /**
         * Gets the current error handler.
         */
        public ErrorHandler getErrorHandler() {
            return errorHandler;
        }

        /**
         * Gets the current namespace handler.
         */
        public NamespaceHandler getNamespaceHandler() {
            return nameHandler;
        }

        /**
         * Gets the current extended handler.
         */
        public ExtendedHandler getExtendedHandler() {
            return scopeHandler;
        }

        /**
         * Gets the current statement handler.
         */
        public StatementHandler getStatementHandler() {
            return statementHandler;
        }
    }
}
