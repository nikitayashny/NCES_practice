﻿using System;
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
        private string selectedType;
        public MainForm()
        {
            InitializeComponent();
        }

        private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;

                byte[] fileBytes = File.ReadAllBytes(selectedFile);
                base64String = Convert.ToBase64String(fileBytes);

                label_file.Text = "Выбран файл " + selectedFile;
            }
        }

        private void radioButton_idCard_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_idCard.Checked)
            {
                selectedType = "idcard";
            }
        }

        private void radioButton_flesh_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_flash.Checked)
            {
                selectedType = "flash";
            }
        }

        private async void button_sign_Click(object sender, EventArgs e)
        {
            if (base64String == null)
            {
                MessageBox.Show("Выберите файл!");
                return;
            }
            if (selectedType == null)
            {
                MessageBox.Show("Выберите тип!");
                return;
            }
            //MessageBox.Show($"Всё хорошо, выбран тип {selectedType}, base64 {base64String}");
            await SendHttpRequestAsync();
        }

        private void button_Check_Signature_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Нет реализации");
        }

        private async Task SendHttpRequestAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var data = new StringContent($"{{\"data\": \"{base64String}\"}}", Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1:8084/sign", data);

                    //response.EnsureSuccessStatusCode();

                    string responseContent = await response.Content.ReadAsStringAsync();

                    label_result.Text = responseContent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
