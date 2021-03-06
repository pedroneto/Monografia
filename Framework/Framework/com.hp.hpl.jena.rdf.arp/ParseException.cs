﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.xml.sax.SAXParseException;
using Framework.com.hp.hpl.jena.rdf.arp.impl.ARPLocation;

namespace Framework.com.hp.hpl.jena.rdf.arp
{
    public class ParseException : SAXParseException,
        ARPErrorNumbers {

    /**
     * 
     */
    private static sealed long serialVersionUID = -5986976549492477885L;
    sealed int id;

    protected ParseException(int id, ARPLocation where, String msg) 
        :base(msg, where.inputName, null, where.endLine, where.endColumn){
        this.id = id;
        
    }



    public ParseException(int id, ARPLocation where, Exception e) 
        :base(e.Message, where.inputName, null, where.endLine, where.endColumn,e){
        if (getCause()==null)
            initCause(e);
        this.id = id;
    }


    /**
     * The error number (from {@link ARPErrorNumbers}) related to this
     * exception.
     * 
     * @return The error number.
     */
    public int getErrorNumber() {
        return id;
    }

    /**
     * Is this error an RDF syntax error.
     * A syntax error indicates that well-formed XML,
     * uses RDF properties and attributes, and whitespace
     * and XML elements, in a way that does not conform with
     * the RDF/XML Syntax (Revised) specification.
     * (Currently most such errors have code
     * {@link ARPErrorNumbers#ERR_SYNTAX_ERROR},
     * but this may change in the future).
     * @return True if this is a syntax error
     */
    public bool isSyntaxError() {
        switch (id) {
        case ERR_SYNTAX_ERROR:
        case ERR_BAD_RDF_ELEMENT:
        case ERR_BAD_RDF_ATTRIBUTE:
        case ERR_LI_AS_TYPE:
        case ERR_NOT_WHITESPACE:
            return true;
        }
        return false;
    }

    SAXParseException rootCause() {
        Exception e = getException();
        return e == null ? this : (SAXParseException) e;
    }

    


    private bool promoteMe;

    /**
     * Intended for use within an RDFErrorHandler. This method is untested.
     * Marks the exception to be promoted to be thrown from the parser's entry
     * method.
     */
    public void promote() {
        promoteMe = true;
    }


    /**
     * The message without location information. Use either the formatMessage
     * method, or the SAXParseException interface, to access the location
     * information.
     * 
     * @return The exception message.
     */
    
    public String getMessage() {
        // turn 1 to W001
        // turn 204 to E204
        String idStr = id != 0 ? "{" + (id < 200 ? "W" : "E")
                + ("" + (1000 + id)).substr(1) + "} " : "";
        
            return idStr + super.getMessage();
    }



    /**
     * Calls e.getMessage() and also accesses line and column information for
     * SAXParseException's.
     * 
     * @return e.getMessage() possibly prepended by error location information.
     * @param e
     *            The exception to describe.
     */
    static public String formatMessage(Exception e) {
        String msg = e.Message();
        if (msg == null)
            msg = e.toString();
        if (!(e instanceof SAXParseException))
            return msg;
        SAXParseException sax = (SAXParseException) e;
        String file = sax.getSystemId();
        if (file == null)
            file = sax.getPublicId();
        String rslt = file == null ? "" : file;
        if (sax.getLineNumber() == -1)
            return (file != null ? (file + ": ") : "") + msg;

        if (sax.getColumnNumber() == -1) {
            return rslt + "(line " + sax.getLineNumber() + "): " + msg;
        }
        return rslt + "(line " + sax.getLineNumber() + " column " + sax.getColumnNumber()
                + "): " + msg;

    }

    public bool isPromoted() {
        return promoteMe;
    }



    /**
     * The  string from
     * {@link ARPErrorNumbers} associated with an integer error code
     * @param errNo An error code from {@link ARPErrorNumbers}.
     * @return The field name from {@link ARPErrorNumbers} with this error number, or null
     */
    static public String errorCodeName(int errNo) {
        Class<?> c = ARPErrorNumbers.class;
        java.lang.reflect.Field flds[] = c.getDeclaredFields();
        for (int i = 0; i < flds.length; i++) {
            try {
                if (flds[i].getInt(null) == errNo)
                    return flds[i].getName();
            } catch (Exception e) {
                // ignore exceptions
            }
        }
        return null;
    }



    /**
     * The integer code associated with a string from
     * {@link ARPErrorNumbers}.
     * @param upper A field name from {@link ARPErrorNumbers}, (in upper case).
     * @return The integer value or -1, if none.
     */
    static public int errorCode(String upper) {
        Class<?> c = ARPErrorNumbers.class;
        try {
            java.lang.reflect.Field fld = c.getField(upper);
            return fld.getInt(null);
        } catch (Exception e) {
            return -1;
        }
    }
}
