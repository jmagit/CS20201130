using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewNext.Cursos.Demos {
    public class Elemento<T> {
        public T Id { get; set; }
        public string Texto { get; set; }
    }

    public class ElementoInt {
        public int Id { get; set; }
        public string Texto { get; set; }
    }
    public class ElementoChar {
        public char Id { get; set; }
        public string Texto { get; set; }
    }

    abstract class Persona {
        public void m() { }
    }

    class Alumno : Persona {

    }
    class Profesor : Persona {

    }

    class Participante<T> where T: Persona {
        public T Item { get; private set; }

        public Participante(T persona) {
            Item = persona;
        }

        void hazalgo() {
            Item.m();
        }
    }
    class Genericos {
        Elemento<int> provincia;
        Elemento<char> genero;
        Elemento<string> codigo;
        Elemento<int> estado;
        Participante<Profesor> profe = new Participante<Profesor>(new Profesor());
        
        List<Participante<Alumno>> alumnos;
        public void m() {
            // alumnos[0].Item;
        }
    }
}
