using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PseudoPaint
{
    public partial class Texto : Form
    {
        public Texto()
        {
            InitializeComponent();
        }
        public String sTexto = "";
        public int iFuente = 0;

        int mx = 0;
        int my = 0;
        private void Texto_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { mx = e.X; my = e.Y; }
            else { Left = Left + (e.X - mx); Top = Top + (e.Y - my); }
        }

        private void TbLetra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                if (TbTexto.Text != "" && TbLetra.Text != "")
                {
                    sTexto = TbTexto.Text;
                    iFuente = int.Parse(TbLetra.Text);
                    
                    this.Close();
                }
            }

        }
    }
}
