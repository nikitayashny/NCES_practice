using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace NCES_CP
{
    public partial class MainForm : Form
    {
        private string base64String;
        private string algorithm_name;
        private bool isDetached = true;
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
        private async void button_sign_Click(object sender, EventArgs e)
        {
            if (base64String == null)
            {
                MessageBox.Show("Выберите файл!");
                return;
            }
            await HTTP.SignFile(base64String, textBox_result, isDetached);
        }

        private async void button_Check_Signature_Click(object sender, EventArgs e)
        {
            if (base64String == null)
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
            await HTTP.VerifySignature(base64String, textBox_result, base64Signature);
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

        private async void button_sign_attr_Click(object sender, EventArgs e) 
        {
            if (base64String == null)
            {
                MessageBox.Show("Выберите файл!");
                return;
            }

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
                string sertificate = Convert.ToBase64String(fileBytes);
                await HTTP.SignFileAttr(base64String, textBox_result, isDetached, sertificate);
            }     
        }
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
    }
}
