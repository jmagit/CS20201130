using MiBiblioteca.Juegos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola {
    class Program {
        static void Main(string[] args) {
            //IJuego juego = new AdivinaElNumero();
            IJuego juego = new Ajedrez();
            juego.Notificacion += Juego_Notificacion;
            while (!juego.HaFinalizado)
                try {
                    Console.Write(juego.Petición + " ");
                    juego.Jugar(Console.ReadLine());
                } catch (JuegoException ex) {
                    Console.WriteLine(ex.Message);
                }
            Console.ReadLine();
        }

        private static void Juego_Notificacion(object sender, NotificacionEventArgs e) {
            Console.WriteLine(e.Mensaje);
        }
    }
}
