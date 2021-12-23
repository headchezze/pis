using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface.Формы
{
    public partial class AutorizationSys : Form
    {
        public AutorizationSys()
        {
            InitializeComponent();
        }

        private void CloseAutorizBut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
