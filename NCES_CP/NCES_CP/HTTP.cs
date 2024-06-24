﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NCES_CP
{
    internal class HTTP
    {
        public static async Task SignFile(string base64String, TextBox textBox_result, bool isDetached)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var data = new StringContent($"{{\"data\": \"{base64String}\", \"isDetached\": \"{isDetached}\"}}", Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1:8084/sign_kta_cms", data);

                    string responseContent = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(responseContent);
                    if ((int)json["error"] == 931)
                    {
                        MessageBox.Show("Перезагрузите КП");
                        return;
                    }

                    // вывод в textBox
                    string formattedJson = json.ToString(Formatting.Indented);
                    textBox_result.Text = formattedJson;

                    // файл sgn
                    byte[] signatureBytes = Convert.FromBase64String((string)json["sig"]);
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        FileName = "signature.sgn",
                        Filter = "SGN files (*.sgn)|*.sgn"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        File.WriteAllBytes(filePath, signatureBytes);
                    }
                    else
                        MessageBox.Show("Ошибка сохранения подписи.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        public static async Task SignFileAttr(string base64String, TextBox textBox_result, bool isDetached, string sertificate)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var data = new StringContent($"{{\"data\": \"{base64String}\",\"AC\": \"{sertificate}\", \"isDetached\": \"{isDetached}\"}}", Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1:8084/sign_kta_cms_ac", data);

                    string responseContent = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(responseContent);
                    if ((int)json["error"] == 931)
                    {
                        MessageBox.Show("Перезагрузите КП");
                        return;
                    }

                    // вывод в textBox
                    string formattedJson = json.ToString(Formatting.Indented);
                    textBox_result.Text = formattedJson;

                    // файл sgn
                    byte[] signatureBytes = Convert.FromBase64String((string)json["sig"]);
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        FileName = "signature.sgn",
                        Filter = "SGN files (*.sgn)|*.sgn"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        File.WriteAllBytes(filePath, signatureBytes);
                    }
                    else
                       MessageBox.Show("Ошибка сохранения подписи.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        public static async Task CalculateHash(string base64String, TextBox textBox_result, string algorithm_name)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var data = new StringContent($"{{\"data\": \"{base64String}\", \"algorithm_name\": \"{algorithm_name}\"}}", Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1:8084/api/v1/calculate_hash", data);

                    string responseContent = await response.Content.ReadAsStringAsync();

                    JObject jsonResponse = JObject.Parse(responseContent);
                    string hashValue = (string)jsonResponse["hash_value"];
                    textBox_result.Text = hashValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
