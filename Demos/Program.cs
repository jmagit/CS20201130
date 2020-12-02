using otra=ViewNext.Cursos.MiBiblioteca;
using ViewNext.Cursos.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Math;

namespace ViewNext.Cursos.Demos {
    delegate void Notificar(object sender, EventArgs ev);

    struct Punto {
        public int X { get; set; }
        public int Y { get; set; }
        public Punto(int x, int y) {
            X = x;
            Y = y;
        }
    }
    enum Dias: short { Lunes = 1, Martes, Domingo = 0 }
    class MiClase {
        private int count;
        public otra.OtraClase Demo { get; set; }

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
            return Abs(a + b);
        }
    }
    delegate int Dame();
    delegate double Operacion(double a, double b);

    class Program {
        public static double Divide(double a, double b) {
            return a / b;
        }

        private static void Mio(object sender, EventArgs ev) {
            if (sender is MiClase)
                Console.WriteLine("El valor es " + (sender as MiClase).Valor + " unidades");
            Console.WriteLine("c:\\nada\\otro\\dir");
            Console.WriteLine(@"c:\nada\otro\dir");
            Console.WriteLine($"El valor es {((MiClase)sender).Valor + 1} unidades");
        }
        static void Main(string[] args) {
            var c = new MiClase();
            OtraClase cc = new OtraClase();
            Dame fn = c.getCount;
            Dias d = Dias.Lunes;
            var nombres = Enum.GetNames(typeof(Dias));
            Punto p1, p2 = new Punto(1,3);

            p1 = p2;
            p2.X = 3;
            //cc.GetType()
#if DEBUG
            Operacion calc = c.Suma;
#else
            Operacion calc = Divide;
#endif
            // ...
            var i = calc(2, 2) * 2;
            short corto = (short)i;
            int? conNulo = null;
            if (conNulo.HasValue) {
                var rslt = i + conNulo.Value;
            }

            if (c.getCount() == 0) {
                c.setCount(1);
            }

            Debug.WriteLine("Hola mundo");

            c.onChange = Mio;

            if (c.EstaVacio) {
                c.Count = 1;
            }
            string cad;
            if (c != null && c.Demo != null && c.Demo.Nombre != null)
                cad = c.Demo.Nombre.ToLower();
            else
                cad = null;

            cad = c?.Demo?.Nombre?.ToLower();
            var cad2 =(cad ?? "Vacio").ToLower();
            Console.ReadLine();
        }
    }
}

