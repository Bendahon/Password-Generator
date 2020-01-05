using System.IO;
using System.Windows.Forms;

namespace Password_Generator.Classes
{
    public class ExportPasswords
    { 
        public ExportPasswords(string PasswordsText)
        {
            
            Export(PasswordsText);
        }

        public void Export(string PasswordText)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                ProcessDialog(PasswordText, fbd.SelectedPath);
            }
        }

        private void ProcessDialog(string Passwords, string FolderBrowserText)
        {
            string OutputPath = $@"{FolderBrowserText}\{Program.ExportingPasswordFileName()}";
            if (File.Exists(OutputPath))
            {
                DialogResult dr = MessageBox.Show(Program.FileAlreadyExists_Overwrite(), Program.ProgramNameAndVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.OK)
                {
                    WriteFile(Passwords, OutputPath);
                }
                else
                {
                    return;
                }
            }
            else
            {
                WriteFile(Passwords, OutputPath);
            }
        }

        private static void WriteFile(string Passwords, string OutputPath)
        {
            using (StreamWriter sw = new StreamWriter(OutputPath))
            {
                sw.Write(Passwords);
            }
        }
    }
}
