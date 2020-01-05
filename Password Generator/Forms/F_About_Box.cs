using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Generator.Forms
{
    partial class F_About_Box : Form
    {
        public F_About_Box()
        {
            InitializeComponent();
            this.LabelProductName.Text = Program.AssemblyProduct;
            this.LabelVersion.Text = $@"Version {Program.AssemblyVersion}";
            this.LabelCopyright.Text = Program.AssemblyCopyright;
            this.labelCompanyName.Text = Program.AssemblyCompany;
            this.textBoxDescription.Text = Program.AssemblyDescription;
        }
    }
}
