using MiBiblioteca.Juegos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola {
    public class Program {
        static void Main(string[] args) {
            IJuego<JugadaGenerica> juego = new AdivinaElNumero();
            //IJuego<JugadaAjedrez> juego = new Ajedrez();
            juego.Notificacion += (sender, e) => Console.WriteLine(e.Mensaje);
            while (!juego.HaFinalizado)
                try {
                    Console.Write(juego.Petición + " ");
                    juego.Jugar(Console.ReadLine());
                } catch (JuegoException ex) {
                    Console.WriteLine(ex.Message);
                }

            foreach(var item in juego)
                Console.Write(item + "\t");
            Console.WriteLine();
            for(var i = 1; i <= juego.Count; i++)
                Console.Write(juego[i] + "\t");
            Console.WriteLine();

            Console.ReadLine();
        }

        private static void Juego_Notificacion(object sender, NotificacionEventArgs e) {
            Console.WriteLine(e.Mensaje);
        }
    }
}
