using System;
using System.Windows.Forms;

namespace Password_Generator
{
    public partial class Form1 : Form
    {
        // NUD{Tab} = Number Up Down box
        // Radio{Tab} = Radio buttons
        // Btn{Tab} = Button
        // Chck{Tab} = Checkboxes
        // Txt{Tab} = Text Boxes
        // Group{Tab} = Group Boxes

        private readonly string CantGeneratePasswords = "Cant Generate Passwords";

        Classes.PasswordGeneratorOptions Pass_Options = new Classes.PasswordGeneratorOptions();

        public Form1()
        {
            InitializeComponent();
            this.Text = Program.ProgramNameAndVersion();
            // Start by selecting an option, can't cause weird errors then
            RadioOptionsStandard.Select();
        }

        #region Radio Buttons
        private void RadioOptionsStandard_CheckedChanged(object sender, EventArgs e)
        {
            GroupOptionsStandard.Enabled = RadioOptionsStandard.Checked;
            Pass_Options.SetStandardGeneration();
        }

        private void RadioOptionsPattern_CheckedChanged(object sender, EventArgs e)
        {
            GroupOptionsPattern.Enabled = RadioOptionsPattern.Checked;
            Pass_Options.SetPatternGeneration();
        }
        #endregion
        #region Required Methods
        private void GenerateButtonMethod()
        {
            this.Cursor = Cursors.WaitCursor;
            if (RadioOptionsStandard.Checked)
            {
                Std_GenerateSomePasswords();
            }
            else if (RadioOptionsPattern.Checked)
            {
                Pattern_GenerateSomePasswords();
            }
            this.Cursor = Cursors.Default;
        }

        private void Std_GenerateSomePasswords()
        {
            if (CheckIfCanGenerate())
            {
                // Get all the chars you've ticked boxes for
                Pass_Options.Std_GenerateCharSets();
                // Make new Password Gen class, pass in options
                Classes.PasswordGen PasswordGen = new Classes.PasswordGen(Pass_Options);
                // Generate password, switch to output box
                string OutputBoxText = PasswordGen.GenerateAPassword();
                TxtOutputBox.Text = OutputBoxText;
                SwitchTabs(1);
            }
        }

        private void Pattern_GenerateSomePasswords()
        {
            if (CheckIfCanGenerate())
            {
                // Pattern is changed LIVE in class
                Classes.PasswordGen PasswordGen = new Classes.PasswordGen(Pass_Options);
                // Generate Password, switch to output box
                string outputText = PasswordGen.GenerateAPassword();
                TxtOutputBox.Text = outputText;
                SwitchTabs(1);
            }
        }

        private bool CheckIfCanGenerate()
        {
            if (Pass_Options.CanGeneratePassword())
            {
                return true;
            }
            else
            {
                MessageBox.Show(CantGeneratePasswords, Program.ProgramNameAndVersion());
                return false;
            }
        }

        private void SwitchTabs(int tabno)
        {
            TabCtrlOptions.SelectedIndex = tabno;
        }
        #endregion
        #region CheckBoxes
        private void ChckOptionsSTDNumbers_CheckedChanged(object sender, EventArgs e)
        {
            // Live auditing of class
            if (ChckOptionsSTDNumbers.Checked)
            {
                Pass_Options.Numbers = true;
            }
            else
            {
                Pass_Options.Numbers = false;
            }
        }

        private void ChckOptionsSTDSpec_CheckedChanged(object sender, EventArgs e)
        {
            if (ChckOptionsSTDSpec.Checked)
            {
                Pass_Options.Special = true;
            }
            else
            {
                Pass_Options.Special = false;
            }
        }

        private void ChckOptionsSTDMisc_CheckedChanged(object sender, EventArgs e)
        {
            if (ChckOptionsSTDMisc.Checked)
            {
                Pass_Options.Misc = true;
            }
            else
            {
                Pass_Options.Misc = false;
            }
        }

        private void ChckOptionsSTDLetters_CheckedChanged(object sender, EventArgs e)
        {
            // This just needs to empty the upper and lower checks
            if (ChckOptionsSTDLetters.Checked)
            {
                ChckOptionsSTDLower.Enabled = true;
                ChckOptionsSTDUpper.Enabled = true;
            }
            else
            {
                ChckOptionsSTDLower.Checked = false;
                ChckOptionsSTDUpper.Checked = false;
                ChckOptionsSTDLower.Enabled = false;
                ChckOptionsSTDUpper.Enabled = false;
            }
        }

        private void ChckOptionsSTDUpper_CheckedChanged(object sender, EventArgs e)
        {
            if (ChckOptionsSTDUpper.Checked)
            {
                Pass_Options.Uppercase = true;
            }
            else
            {
                Pass_Options.Uppercase = false;
            }
        }

        private void ChckOptionsSTDLower_CheckedChanged(object sender, EventArgs e)
        {
            if (ChckOptionsSTDLower.Checked)
            {
                Pass_Options.Lowercase = true;
            }
            else
            {
                Pass_Options.Lowercase = false;
            }
        }
        #endregion
        #region Number Up Down Boxes
        private void NUDOptionsPassLength_ValueChanged(object sender, EventArgs e)
        {
            Pass_Options.PasswordLength = (int)NUDOptionsPassLength.Value;
        }
        private void NUDOptionsTotalToGenerate_ValueChanged(object sender, EventArgs e)
        {
            Pass_Options.TotalPasswords = (int)NUDOptionsTotalToGenerate.Value;
            NUDOptionsPattern.Value = NUDOptionsTotalToGenerate.Value;
        }
        private void NUDOptionsPattern_ValueChanged(object sender, EventArgs e)
        {
            Pass_Options.TotalPasswords = (int)NUDOptionsPattern.Value;
            NUDOptionsTotalToGenerate.Value = NUDOptionsPattern.Value;
        }
        #endregion
        #region Extra Forms
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.F_Pattern_Sheet ps = new Forms.F_Pattern_Sheet();
            ps.ShowDialog();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.F_About_Box ab = new Forms.F_About_Box();
            ab.ShowDialog();
        }
        #endregion
        #region Buttons

        private void BtnOutputLeft_Click(object sender, EventArgs e)
        {
            SwitchTabs(TabCtrlOptions.SelectedIndex -= 1);
        }

        private void BtnOptionsRight_Click(object sender, EventArgs e)
        {
            SwitchTabs(TabCtrlOptions.SelectedIndex += 1);
        }
        private void BtnOutputExport_Click(object sender, EventArgs e)
        {
            Classes.ExportPasswords export = new Classes.ExportPasswords(TxtOutputBox.Text);
        }
        private void BtnOptionsGenerate_Click(object sender, EventArgs e)
        {
            GenerateButtonMethod();
        }
        private void BtnOPGenerate_Click(object sender, EventArgs e)
        {
            GenerateButtonMethod();
        }
        #endregion
        #region Menu strip
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Text Boxes
        private void TxtOptionsPattern_TextChanged(object sender, EventArgs e)
        {
            Pass_Options.PatternString = TxtOptionsPattern.Text;
        }

        private void TxtOutputBox_TextChanged(object sender, EventArgs e)
        {
            // This is kind of pointless
            if (string.IsNullOrEmpty(TxtOutputBox.Text))
            {
                BtnOutputExport.Enabled = false;
            }
            else
            {
                BtnOutputExport.Enabled = true;
            }
        }
        #endregion
    }
}
