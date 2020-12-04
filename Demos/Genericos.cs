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

    public class Direccion {
        public String Calle { get; set; }
        public String Localidad { get; set; }

    }
    public class Asignatura {
        public int Id { get; set; }
        public String Nombre { get; set; }

    }
    public abstract class Persona {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }

        public List<String> Telefonos { get; set; }
        public List<Direccion> Direcciones { get; set; }

        public static bool operator == (Persona item1, Persona item2) {
            if (item1 == null || item2 == null) return false;
            return item1.Id == item2.Id;
        }
        public static bool operator !=(Persona item1, Persona item2) {
            return !(item1 == item2);
        }

        public static bool operator ==(Persona item1, int id) {
            // p == 4
            // NO 4 == p
            if (item1 == null) return false;
            return item1.Id == id;
        }
        public static bool operator !=(Persona item1, int id) {
            if (item1 == null) return false;
            return item1.Id != id;
        }

        // override object.Equals
        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            return this.Id == (obj as Persona).Id;
        }

        // override object.GetHashCode
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }

    public class Alumno : Persona {
        public List<decimal> Notas { get; set; }

    }
    class Profesor : Persona {
        public List<Asignatura> Asignaturas { get; set; }
    }

    class Participante<T> where T: Persona {
        public T Item { get; private set; }

        public Participante(T persona) {
            Item = persona;
        }

        void hazalgo() {

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
