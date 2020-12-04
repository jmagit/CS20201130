using MiBiblioteca.Juegos;
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
    public partial class frmJuegoConClase : Form {
        private readonly IJuego<JugadaGenerica> juego = new AdivinaElNumero();

        public frmJuegoConClase() {
            InitializeComponent();
            juego.Notificacion += Juego_Notificacion;
            juego.Finalizado += Juego_Finalizado;
            Inicializa();
        }

        private void Juego_Notificacion(object sender, NotificacionEventArgs e) {
            switch (e.Tipo) {
                case NotificacionTipo.Importante:
                    MessageBox.Show(e.Mensaje, "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case NotificacionTipo.Aviso:
                    MessageBox.Show(e.Mensaje, "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        private void Juego_Finalizado(object sender, EventArgs e) {
            CambiaAOtra();
        }


        private void Inicializa() {
            juego.Inicializa();
            lblResultado.Text = "";
            txtNumero.Text = "";
            txtNumero.Enabled = true;
            btnProbar.Text = "Probar";
            lblTitulo.Text = juego.Petición;
        }

        private void btnProbar_Click(object sender, EventArgs e) {
            try {
                juego.Jugar(txtNumero.Text);
                lblTitulo.Text = juego.Petición;
                lblResultado.Text = juego.Resultado;
            } catch (JuegoException ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CambiaAOtra() {
            btnProbar.Text = "Otra";
            txtNumero.Enabled = false;
            this.btnProbar.Click -= new System.EventHandler(this.btnProbar_Click);
            this.btnProbar.Click += new System.EventHandler(this.btnIniciar_Click);
        }

        private void btnIniciar_Click(object sender, EventArgs e) {
            Inicializa();
            this.btnProbar.Click -= new System.EventHandler(this.btnIniciar_Click);
            this.btnProbar.Click += new System.EventHandler(this.btnProbar_Click);
        }

    }
}
