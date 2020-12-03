using System;

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

    public interface IJuego {
        bool HaFinalizado { get; }
        string Petición { get; }
        string Resultado { get; }

        event Action<object, EventArgs> Finalizado;
        event Action<object, NotificacionEventArgs> Notificacion;

        bool EsInvalido(string jugada);
        bool EsValido(string jugada);
        void Inicializa();
        void Jugar(string jugada);
    }
}