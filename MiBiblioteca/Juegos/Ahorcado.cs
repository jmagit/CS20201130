using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBiblioteca.Juegos {
    public class Ahorcado : JuegoBase<JugadaGenerica> {
        private string objetivo;
        private int intento;

        public override string Petición => throw new NotImplementedException();
//  O
// /|\
// / \
        public override bool EsValido(string jugada) {
            throw new NotImplementedException();
        }

        public override void Inicializa() {
            throw new NotImplementedException();
        }

        public override void Jugar(string jugada) {
            throw new NotImplementedException();
        }
    }
}
