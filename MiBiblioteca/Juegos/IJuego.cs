using System;
using System.Collections.Generic;

namespace MiBiblioteca.Juegos {
    public enum NotificacionTipo {
        Aviso,
        Error,
        Informacion,
        Importante
    }
    public class NotificacionEventArgs : EventArgs {
        public string Mensaje { get; set; }
        public NotificacionTipo Tipo { get; set; } = NotificacionTipo.Informacion;
    }

    public interface IJugada { }

    /// <summary>
    /// Interfaz paras juegos simples
    /// </summary>
    public interface IJuego<T> : IEnumerable<T> where T: IJugada {
        /// <summary>
        /// Informa si la partida ha finalizado
        /// </summary>
        bool HaFinalizado { get; }
        /// <summary>
        /// Texto para la petición de la jugada
        /// </summary>
        string Petición { get; }
        /// <summary>
        /// Resultado de la última jugada
        /// </summary>
        string Resultado { get; }

        /// <summary>
        /// Notifica que la partida ha finalizado
        /// </summary>
        event Action<object, EventArgs> Finalizado;
        /// <summary>
        /// Notifica un mensaje para el usuario.
        /// </summary>
        event Action<object, NotificacionEventArgs> Notificacion;

        /// <summary>
        /// Informa de si la jugada es invalida
        /// </summary>
        /// <param name="jugada">Cadena con la jugada en el formato propio del juego</param>
        /// <returns>true si NO es valida</returns>
        bool EsInvalido(string jugada);
        /// <summary>
        /// Informa de si la jugada es valida
        /// </summary>
        /// <param name="jugada">Cadena con la jugada en el formato propio del juego</param>
        /// <returns>true si es valida</returns>
        bool EsValido(string jugada);
        /// <summary>
        /// Inicializa el juego y deja la partida lista para empezar a jugar.
        /// </summary>
        void Inicializa();
        /// <summary>
        /// Realiza una jugada
        /// </summary>
        /// <param name="jugada">Cadena con la jugada en el formato propio del juego</param>
        /// <exception cref="MiBiblioteca.Juegos.JuegoException">El formato de la jugada es incorrecto o no se puede realizar.</exception>
        [Obsolete(message: "Este ya no se usa")]
        void Jugar(string jugada);

        /// <summary>
        /// Número de jugadas de la partida
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Valor de la jugada indicada
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T this[int index] { get; }
    }
}