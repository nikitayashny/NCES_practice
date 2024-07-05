using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Tls.Crypto;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace NCES_CP
{
    public partial class MainForm : Form
    {
        private string base64String;
        private string algorithm_name;
        private bool isDetached = true;
        private string signMethod = "AvPass";
        private bool isAC = false;
        private string base64Signature;
 
        public MainForm()
        {
            InitializeComponent();
        }
        private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "All Files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;

                byte[] fileBytes = File.ReadAllBytes(selectedFile);
                base64String = Convert.ToBase64String(fileBytes);

                label_file.Text = "Выбран файл " + selectedFile;
            }
        }
        private async void button_SignFile_Click(object sender, EventArgs e)
        {
            if (base64String == null)
            {
                MessageBox.Show("Выберите файл!");
                return;
            }
            if (isAC == true)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "All Files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedSertificate = openFileDialog.FileName;
                    byte[] fileBytes = File.ReadAllBytes(selectedSertificate);
                    string certificate = Convert.ToBase64String(fileBytes);

                    await HTTP.SignFile(base64String, textBox_result, isDetached, signMethod, isAC, certificate);
                }
            }
            else 
                await HTTP.SignFile(base64String, textBox_result, isDetached, signMethod, isAC);
        }
        private async void button_Check_Signature_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(base64String))
            {
                MessageBox.Show("Выберите файл!");
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "SGN files (*.sgn)|*.sgn",
                FilterIndex = 1,
                RestoreDirectory = true
            };


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedSignature = openFileDialog.FileName;

                byte[] fileBytes = File.ReadAllBytes(selectedSignature);
                base64Signature = Convert.ToBase64String(fileBytes);

            }
            await HTTP.VerifySignature(base64String, textBox_result, base64Signature, button_fullinfo);
        }
        private async void button_calculate_hash_Click(object sender, EventArgs e)
        {
            if (base64String != null)
            {
                algorithm_name = "hbelt";
                await HTTP.CalculateHash(base64String, textBox_result, algorithm_name);
            }
            else
                MessageBox.Show("Выберите файл");
        }
        private void button_fullinfo_Click(object sender, EventArgs e)
        {
            HTTP.ShowFullInfo();
        }
        private void textBox_result_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_result.Text.StartsWith("Подпись "))
                button_fullinfo.Visible = false;
        }

        #region radiobuttons
        private void radioButton_Detached_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Detached.Checked)
                isDetached = true;

        }
        private void radioButton_NotDetached_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_NotDetached.Checked)
                isDetached = false;
        }
        private void radioButton_idCard_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_idCard.Checked)
                signMethod = "idCard";
        }
        private void radioButton_AvPass_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_AvPass.Checked)
                signMethod = "AvPass";
        }
        private void radioButton_yes_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_yes.Checked)
                isAC = true;
        }
        private void radioButton_no_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_no.Checked)
                isAC = false;
        }
        #endregion
    }
}
