using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.com.hp.hpl.jena.assembler
{
    public interface Assembler
    {
        static Assembler content;
        static Assembler defaultModel;
        static Assembler documentManager;
        static Assembler fileManager;
        static Assembler fileModel;
        //static com.hp.hpl.jena.assembler.assemblers.AssemblerGroup	general 
        static Assembler infModel;
        static Assembler locationMapper;
        static Assembler memoryModel;
        static Assembler modelSource;
        static Assembler ontModel;
        static Assembler ontModelSpec;
        static Assembler prefixMapping;
        static Assembler reasonerFactory;
        static Assembler ruleSet;
        static Assembler unionModel;

        Object open( Assembler a, Resource root, Mode mode )
        {
            return null;
        }

        Object open( Assembler a, Resource root )
        {
            return null;
        }

        Object open( Resource root )
        {
            return null;
        }

        Model openModel( Resource root )
        {
            return null;
        }

        Model openModel(Resource root, Mode mode)
        {
            return null;
        }
    }

}
