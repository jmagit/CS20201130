using MiBiblioteca.Juegos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola {
    public class Program {
        static void Main(string[] args) {
            //IJuego<JugadaGenerica> juego = new AdivinaElNumero();
            IJuego<JugadaAjedrez> juego = new Ajedrez();
            juego.Notificacion += (sender, e) => Console.WriteLine(e.Mensaje);
            while (!juego.HaFinalizado)
                try {
                    Console.Write(juego.Petición + " ");
                    juego.Jugar(Console.ReadLine());
                } catch (JuegoException ex) {
                    Console.WriteLine(ex.Message);
                }

            foreach (var item in juego)
                Console.Write(item + "\t");
            Console.WriteLine();
            for (var i = 1; i <= juego.Count; i++)
                Console.Write(juego[i] + "\t");
            Console.WriteLine();
 
            juego.Take(juego.Count - 1)
                .Where(j => int.Parse(j.Jugada) > 50)
                .Take(5)
                .ToList().ForEach(j => Console.Write(j + "\t"));
            Console.WriteLine();

            Console.WriteLine(juego.Last());

            Console.WriteLine(juego.Single(j => j.Id == 3));

            juego.Where(j => j.Turno == Turno.Negras).ToList().ForEach(j => Console.Write(j + "\t"));

            Console.ReadLine();

            juego.Select(j => new JugadaGenerica(j.Id, j.Jugada)).ToList().ForEach(j => Console.Write(j + "\t"));

            Console.ReadLine();
        }

        private static void Juego_Notificacion(object sender, NotificacionEventArgs e) {
            Console.WriteLine(e.Mensaje);
        }
    }
}
