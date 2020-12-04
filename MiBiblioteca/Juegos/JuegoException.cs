using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MiBiblioteca.Juegos {
    public class JuegoException : Exception {
        public JuegoException(string message) : base(message) {
        }

        public JuegoException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}
