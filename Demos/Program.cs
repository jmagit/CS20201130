using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos {
    delegate void Notificar(object sender, EventArgs ev);

    class MiClase {
        private int count;

        public Notificar onChange { get; set; }

        #region Propiedades
        public int Count {
            get {
                return count;
            }
            set {
                if (count != value) {
                    count = value;
                    if (onChange != null)
                        onChange(this, new EventArgs());
                }
            }
        }
        /// <summary>
        /// Informa si está vacío
        /// </summary>
        public bool EstaVacio {
            get {
                return count == 0;
            }
        }

        private int valor;

        public int Valor {
            get { return valor; }
            set {
                if (value < 0)
                    throw new Exception("Valor negativo");
                valor = value;
            }
        }
        #endregion

        #region Propiedades en Java
        public int getCount() { return count; }
        public void setCount(int value) { count = value; }
        #endregion
        public double Suma(double a, double b) {
            return a + b;
        }
    }
    delegate int Dame();
    delegate double Operacion(double a, double b);

    class Program {
        public static double Divide(double a, double b) {
            return a / b;
        }

        private static void Mio(object sender, EventArgs ev) {
            Console.WriteLine("El valor es " + ((MiClase)sender).Valor + " unidades");
            Console.WriteLine("c:\\nada\\otro\\dir");
            Console.WriteLine(@"c:\nada\otro\dir");
            Console.WriteLine($"El valor es {((MiClase)sender).Valor + 1} unidades");
        }
        static void Main(string[] args) {
            var c = new MiClase();
            Dame fn = c.getCount;

#if DEBUG
            Operacion calc = c.Suma;
#else
            Operacion calc = Divide;
#endif
            // ...
            var i = calc(2, 2);

            if (c.getCount() == 0) {
                c.setCount(1);
            }

            c.onChange = Mio;

            if (c.EstaVacio) {
                c.Count = 1;
            }
        }
    }
}

