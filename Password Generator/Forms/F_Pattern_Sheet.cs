using System;
using System.Windows.Forms;

namespace Password_Generator.Forms
{
    public partial class F_Pattern_Sheet : Form
    {
        public F_Pattern_Sheet()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
