using otra = ViewNext.Cursos.MiBiblioteca;
using ViewNext.Cursos.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewNext.Validadores;

using static System.Math;

namespace ViewNext.Cursos.Demos {
    delegate void Notificar(object sender, EventArgs ev);


    public class Punto {
        public int X { get; set; }
        public int Y { get; set; }
        public Punto(int x, int y) {
            X = x;
            Y = y;
        }

        public static Punto operator +(Punto p1, Punto p2) {
            return new Punto(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Punto operator +(Punto p1, int delta) {
            p1.X += delta;
            p1.Y += delta;
            return p1;
        }
        public static Punto operator +(int delta, Punto p1) {
            p1.X += delta;
            p1.Y += delta;
            return p1;
        }
    }
    enum Dias : short { Lunes = 1, Martes, Domingo = 0 }

    class MiClase : IDisposable {
        private int count;
        public otra.OtraClase Demo { get; set; }
        public string Nombre { get; set; }
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

        private bool isDispose = false;
        public void Dispose() {
            // Liberar
            isDispose = true;
        }

        ~MiClase() {
            if (!isDispose) {
                Dispose();
            }
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
        public static void parametros(MiClase r, ref int edad) {
            r.Nombre = "Don Jose";
            edad = 88;

        }
        static void Main(string[] args) {
            var c = new MiClase();
            OtraClase cc = new OtraClase();
            Dame fn = c.getCount;
            Dias d = Dias.Lunes;
            var nombres = Enum.GetNames(typeof(Dias));
            Punto p1, p2 = new Punto(1, 3);
            p1 = new Punto(2, 3);
            Punto p3 = p1 + (p2 + 2);

            Persona p;
            c.Nombre = "Don Pepito";
            int años = 9;
            var aux = c;

            parametros(c, ref años);
            Console.WriteLine("Hola " + c.Nombre + " tienes " + años);
            var resl = c == aux;

            p1 = p2;
            p2.X = 3;
            //cc.GetType()
#if DEBUG
            Operacion calc = c.Suma;
#else
            Operacion calc = Divide;
#endif
            calc = delegate (double a, double b) { return a * b; };
            calc = (a, b) => a * b;
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

            if (cc is IDisposable) {
                (cc as IDisposable).Dispose();
            }
            cad = c?.Demo?.Nombre?.ToLower();
            var cad2 = (cad ?? "Vacio").ToLower();
            if (ValidacionesCadenas.LongMax(cad, 15)) {

            }
            if (cad.LongMax(15)) {

            }

            List<Alumno> alumnos = new List<Alumno>();
            // ...
            bool paginar = true;
            int numPag = 7, filas = 10;
            var consulta = alumnos
                .Where(a => a.Nombre.StartsWith("P") && a.Direcciones.Any(x => x.Calle.StartsWith(@"C\")));
            if (paginar)
                consulta = consulta.Skip(numPag * filas).Take(filas);
            consulta = consulta.OrderBy(a => a.Apellidos);
            // ..
            var alm = consulta.Select(a => new { nom = a.Nombre, a.Apellidos }).ToList();
            var uno = consulta.Select(a => new { nom = a.Nombre, a.Apellidos })
                .FirstOrDefault(a => a.nom != null);

            var numDir = consulta.Select(a => a.Direcciones.Count).Sum();
            numDir = consulta.Sum(a => a.Direcciones.Count);

            var otraConsulta = from a in alumnos
                               where a.Apellidos == "Garcia"
                               orderby a.Nombre
                               select a;

            string s1 = "Uno";
            string s2 = "Uno";

            Console.ReadLine();
        }
    }
}

