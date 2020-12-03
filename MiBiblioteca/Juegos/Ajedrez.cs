using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBiblioteca.Juegos {
    public class Ajedrez : JuegoBase {
        enum Turno {
            Blancas,
            Negras
        }

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
            if(--fake == 0 || jugada?.ToUpper() == "FIN") {
                HaFinalizado = true;
                OnNotification(new NotificacionEventArgs { Mensaje = "Partida finalizada en tablas." });
                OnFinalizado();
            } else if(jugada?.ToUpper() == "JAQUE MATE") {
                 HaFinalizado = true;
               OnNotification(new NotificacionEventArgs { Mensaje = $"Ganan las {turno}." });
                OnFinalizado();

            } else {
                turno = turno == Turno.Blancas ? Turno.Negras : Turno.Blancas;
            }
        }
    }
}
