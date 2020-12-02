using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiAplicacion {
    public partial class frmJuego : Form {
        public const int NUM_MIN = 1;
        public const int NUM_MAX = 100;
        public const int MAX_INTENTOS = 10;

        private int objetivo;
        private int intento;
        private bool finalizado;

        public frmJuego() {
            InitializeComponent();
            Inicializa();
        }

        private void Inicializa() {
            objetivo = (new Random()).Next(NUM_MIN, NUM_MAX);
            intento = 1;
            finalizado = false;
            lblResultado.Text = "";
            txtNumero.Text = "";
            txtNumero.Enabled = true;
            btnProbar.Text = "Probar";
            PonTitulo();
        }

        private void btnProbar_Click(object sender, EventArgs e) {
            if (finalizado) {
                MessageBox.Show("Falta introducir el número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNumero.Text)) {
                MessageBox.Show("Falta introducir el número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int numero;
            try {
                numero = int.Parse(txtNumero.Text);
            } catch (Exception ex) {
                MessageBox.Show("No es un número valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numero == objetivo) {
                MessageBox.Show($"Acertaste en el {intento} intento.", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                finalizado = true;
            } else if (intento++ == MAX_INTENTOS) { 
                MessageBox.Show($"No lo conseguiste, mi número era el {objetivo}", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                finalizado = true;
            } else {
                PonTitulo();
                lblResultado.Text = "El mio es " + (numero < objetivo ? "mayor" : "menor");
            }
            if (finalizado) {
                CambiaAOtra();
            }

        }

        private void CambiaAOtra() {
            btnProbar.Text = "Otra";
            txtNumero.Enabled = false;
            this.btnProbar.Click += new System.EventHandler(this.btnIniciar_Click);
            this.btnProbar.Click -= new System.EventHandler(this.btnProbar_Click);
        }

        private void PonTitulo() {
            lblTitulo.Text = $"Dame un número entre {NUM_MIN} y {NUM_MAX} ({intento} de {MAX_INTENTOS}):";
        }

        private void btnIniciar_Click(object sender, EventArgs e) {
            Inicializa();
            this.btnProbar.Click -= new System.EventHandler(this.btnIniciar_Click);
            this.btnProbar.Click += new System.EventHandler(this.btnProbar_Click);
        }
    }
}
