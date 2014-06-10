using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.com.hp.hpl.jena
{
    public class JenaRuntime : Object
    {
        public static String featureNoCharset;
        public static String featureNoSecurity;

        public JenaRuntime(){}

        public static String getMetadata( String key, String defaultValue ) 
        {
            return "";
        }

        public static void setFeature( String featureName ){}

        public static bool runUnder( String featureName )
        {
            return false;
        }

        public static bool runNotUnder(String featureName)
        {
            return false;
        }

        public static String getLineSeparator()
        {
            return "";
        }

        public static String getSystemProperty( String propName )
        {
            return "";
        }

        public static String getSystemProperty( String propName, String defaultValue )
        {
            return "";
        }

    }
}
