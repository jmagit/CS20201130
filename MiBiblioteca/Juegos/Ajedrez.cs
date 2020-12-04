using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBiblioteca.Juegos {
    public enum Turno {
        Blancas,
        Negras
    }

    public class JugadaAjedrez : IJugada {
        public int Id { get; }
        public string Jugada { get; }
        public Turno Turno { get; }
        public JugadaAjedrez(int id, Turno turno, string jugada) {
            Id = id;
            Turno = turno;
            Jugada = jugada;
        }

        public override string ToString() {
            return $"{Id} {Enum.GetName(typeof(Turno), Turno)} {Jugada}";
        }
    }
    public class Ajedrez : JuegoBase<JugadaAjedrez> {

        Turno turno = Turno.Blancas;
        int fake = 10;

        public override string Petición => $"Juegan las {turno}. Dame jugada: ";

        public override bool EsValido(string jugada) {
            return true;
        }

        public override void Inicializa() {
            fake = 10;
            turno = Turno.Blancas;
        }

        public override void Jugar(string jugada) {
            Add(new JugadaAjedrez(Count + 1, turno, jugada));
            if (--fake == 0 || jugada?.ToUpper() == "FIN") {
                HaFinalizado = true;
                OnNotification(new NotificacionEventArgs { Mensaje = "Partida finalizada en tablas." });
                OnFinalizado();
            } else if (jugada?.ToUpper() == "JAQUE MATE") {
                HaFinalizado = true;
                OnNotification(new NotificacionEventArgs { Mensaje = $"Ganan las {turno}." });
                OnFinalizado();

            } else {
                turno = turno == Turno.Blancas ? Turno.Negras : Turno.Blancas;
            }
        }
    }
}
