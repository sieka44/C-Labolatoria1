using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labki3
{
    struct Complex<T,S> 
        where T: struct
        where S: struct
    {
        public T Real { get; set; }
        public S Imag { get; set; }

        public Complex(T real, S imag)
        {
            Real = real;
            Imag = imag;
        }

        public override string ToString()
        {
            return Real + " " + Imag + "i";
        }
        
    }
}
