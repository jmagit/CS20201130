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
    public partial class frmPrincipal : Form {
        public frmPrincipal() {
            InitializeComponent();
        }

        private void btnModal_Click(object sender, EventArgs e) {
            var frm = new frmOtro();
            //frm.Parent = this;
            if (frm.ShowDialog() == DialogResult.OK) {
                MessageBox.Show("Dice OK");
            } else {
                MessageBox.Show("Cancelado");
            }
        }

        private void btnModeless_Click(object sender, EventArgs e) {
            var frm = new frmOtro();
            frm.Show(this);
            //MessageBox.Show("Continuo");
        }
        private void btnJugar_Click(object sender, EventArgs e) {
            var frm = new frmJuego();
            frm.Show(this);
        }

        private void btnDemo_Click(object sender, EventArgs e) {
            wbNavegador.Navigate(txtDireccion.Text);
        }

        private void txtDireccion_Leave(object sender, EventArgs e) {
            btnDemo_Click(sender, e);
        }
    }
}
