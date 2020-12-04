using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewNext.Validadores {
    public static class ValidacionesCadenas {
        public static bool EstaVacia(this string cad) {
            return string.IsNullOrWhiteSpace(cad);
        }
        public static bool NoEstaVacia(this string cad) {
            return !EstaVacia(cad);
        }
        public static bool EsNIF(this string cad) {
            return true;
        }
        public static bool LongMax(this string cad, int len) {
            return EstaVacia(cad) || cad.Length <= 0;
        }
        public static bool EsPositivo(this int num) {
            return num > 0;
        }

    }
}
