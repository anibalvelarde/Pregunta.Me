using Spackle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.UnitTests
{
    public class Singleton
    {
        private RandomObjectGenerator _rog = null;
        private static Singleton instance = null;
        // adding locking object
        private static readonly object syncRoot = new object();
        private Singleton() { }

        public RandomObjectGenerator Rog { get { return _rog; } }

        public static Singleton Instance
        {
            get
            {
                // Locking ensures that only one thread will create an instance .
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Singleton() { _rog = new RandomObjectGenerator() };
                    }
                    return instance;
                }
            }
        }
    }
}
