using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBiblioteca.Juegos {
    public class JugadaGenerica : IJugada, ICloneable {
        public int Id { get; }
        public string Jugada { get; set; }

        public JugadaGenerica(int id, string jugada) {
            Id = id;
            Jugada = jugada;
        }

        public override string ToString() {
            return $"{Id} {Jugada}";
        }

        public object Clone() {
            return this.MemberwiseClone();
        }
    }

    public class AdivinaElNumero: JuegoBase<JugadaGenerica> {
        #region Constantes públicas
        public readonly int NUM_MIN = 1;
        public readonly int NUM_MAX = 100;
        public readonly int MAX_INTENTOS = 10;
        #endregion
        #region Atributos
        private int objetivo;
        private int intento;
        private readonly Random rnd = new Random();
        #endregion
        #region Propiedades
        public override string Petición {
            get {
#if DEBUG
                return $"Dame un número entre {NUM_MIN} y {NUM_MAX} ({intento} de {MAX_INTENTOS}) [{objetivo}]:";
#else
                return $"Dame un número entre {NUM_MIN} y {NUM_MAX} ({intento} de {MAX_INTENTOS}):";
#endif
            }
        }

        #endregion
        #region Métodos públicos
        public AdivinaElNumero(int min = 1, int max = 100, int intentos = 10) {
            NUM_MIN = min;
            NUM_MAX = max;
            MAX_INTENTOS = intentos;
            Inicializa();
        }
        public override void Inicializa() {
            objetivo = rnd.Next(NUM_MIN, NUM_MAX);
            intento = 1;
            HaFinalizado = false;
            Clear();
        }

        public override bool EsValido(string jugada) {
            if (HaFinalizado) {
                Resultado = "Falta introducir el número";
                return false;
            }
            if (string.IsNullOrWhiteSpace(jugada)) {
                Resultado = "Falta introducir el número"; ;
                return false;
            }
            try {
                int.Parse(jugada);
            } catch (Exception) {
                Resultado = "No es un número valido";
                return false;
            }
            return true;
        }

        public override void Jugar(string jugada) {
            if (EsInvalido(jugada))
                throw new JuegoException(Resultado);
            int.TryParse(jugada, out int numero);
            Add(new JugadaGenerica(Count + 1, jugada));
            if (numero == objetivo) {
                Resultado = $"Acertaste en el {intento} intento.";
                HaFinalizado = true;
                OnNotification(new NotificacionEventArgs { Mensaje = Resultado, Tipo = NotificacionTipo.Importante });
            } else if (intento++ == MAX_INTENTOS) {
                Resultado = $"No lo conseguiste, mi número era el {objetivo}";
                HaFinalizado = true;
                OnNotification(new NotificacionEventArgs { Mensaje = Resultado, Tipo = NotificacionTipo.Aviso });
            } else {
                Resultado = "El mio es " + (numero < objetivo ? "mayor" : "menor");
                OnNotification(new NotificacionEventArgs { Mensaje = Resultado, Tipo = NotificacionTipo.Informacion });
            }
            if (HaFinalizado) {
                OnFinalizado();
            }

        }

        #endregion
    }
}
