using System;

namespace MiBiblioteca.Juegos {
    public abstract class JuegoBase : IJuego {
        #region Propiedades
        public bool HaFinalizado { get; protected set; }
        public string Resultado { get; protected set; }
        public abstract string Petición { get; }
        #endregion
        #region Métodos públicos
        public bool EsInvalido(string jugada) {
            return !EsValido(jugada);
        }
        public abstract bool EsValido(string jugada);
        public abstract void Inicializa();
        public abstract void Jugar(string jugada);
        #endregion
        #region Eventos
        public event Action<object, NotificacionEventArgs> Notificacion;
        public event Action<object, EventArgs> Finalizado;

        protected void OnFinalizado() {
            Finalizado?.Invoke(this, new EventArgs());
        }

        protected void OnNotification(NotificacionEventArgs ev) {
#pragma warning disable IDE1005 // La invocación del delegado se puede simplificar.
            if (Notificacion != null)
                Notificacion(this, ev);
#pragma warning restore IDE1005 // La invocación del delegado se puede simplificar.
        }

        #endregion
    }
}