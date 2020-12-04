using System;
using System.Collections;
using System.Collections.Generic;

namespace MiBiblioteca.Juegos {
    public abstract class JuegoBase<T> : IJuego<T> where T : IJugada {
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

        protected virtual void OnFinalizado() {
            Finalizado?.Invoke(this, new EventArgs());
        }

        protected virtual void OnNotification(NotificacionEventArgs ev) {
#pragma warning disable IDE1005 // La invocación del delegado se puede simplificar.
            if (Notificacion != null)
                Notificacion(this, ev);
#pragma warning restore IDE1005 // La invocación del delegado se puede simplificar.
        }

        #endregion
        #region Cache de jugadas
        private List<T> partida = new List<T>();
        protected void Add(T jugada) {
            partida.Add(jugada);
        }
        protected void Clear() {
            partida.Clear();
        }
        public int Count => partida.Count;
        public T this[int index] {
            get {
                if (0 < index && index <= Count)
                    if (partida[index - 1] is ICloneable)
                        return (T)(partida[index - 1] as ICloneable).Clone();
                    else
                        return partida[index - 1];
                throw new IndexOutOfRangeException();
            }
        }
        public IEnumerator<T> GetEnumerator() {
            foreach (T item in partida)
                yield return item;

            //var rslt = new List<T>();
            //for (int i = 1; i <= Count; i++) {
            //    rslt.Add(this[i]);
            //}
            //return rslt.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
        #endregion
    }
}