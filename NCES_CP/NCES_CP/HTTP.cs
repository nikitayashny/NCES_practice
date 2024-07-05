using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace NCES_CP
{
    internal class HTTP
    {
        private static X509Certificate2 certificate;
        public static async Task SignFile(string base64String, TextBox textBox_result, bool isDetached, string signMethod, bool isAC, string fileName, string certificate = null)
        {
            try
            {
                if (signMethod == "idCard")
                {
                    if (isAC == false)
                    {
                        using (var httpClient = new HttpClient())
                        {
                            var data = new StringContent($"{{\"data\": \"{base64String}\", \"isDetached\": \"{isDetached}\"}}", Encoding.UTF8, "application/json");

                            HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1:8084/sign_kta_cms", data);

                            string responseContent = await response.Content.ReadAsStringAsync();

                            JObject json = JObject.Parse(responseContent);

                            /*if (json["error"] != null)
                            {
                                MessageBox.Show("Ошибка: " + json["error"].ToString());
                                return;
                            }*/

                            string formattedJson = json.ToString(Formatting.Indented);
                            textBox_result.Text = formattedJson;

                            byte[] signatureBytes = Convert.FromBase64String((string)json["sig"]);
                            SaveFileDialog saveFileDialog = new SaveFileDialog
                            {
                                FileName = $"{fileName}IdCard.sgn",
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
                    if (isAC == true)
                    {
                        using (var httpClient = new HttpClient())
                        {
                            var data = new StringContent($"{{\"data\": \"{base64String}\",\"AC\": \"{certificate}\", \"isDetached\": \"{isDetached}\"}}", Encoding.UTF8, "application/json");

                            HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1:8084/sign_kta_cms_ac", data);

                            string responseContent = await response.Content.ReadAsStringAsync();

                            JObject json = JObject.Parse(responseContent);

                            string formattedJson = json.ToString(Formatting.Indented);

                            byte[] signatureBytes = Convert.FromBase64String((string)json["sig"]);

                            //// Сверка серийных номеров сертиифатов (легендарный костыль)
                            try
                            {
                                byte[] fileBytes = Convert.FromBase64String(certificate);
                                Asn1Object asn1ObjectAttr = Asn1Object.FromByteArray(fileBytes);
                                string patternAttr = @"\]\]\]\], (.+?)\]\]";
                                Asn1Object asn1ObjectCert = Asn1Object.FromByteArray(signatureBytes);
                                string patternCert = @"\[0\]\[\[\[\[0\]2, (.+?),";

                                Regex regexAttr = new Regex(patternAttr);
                                Match matchAttr = regexAttr.Match(asn1ObjectAttr.ToString());

                                Regex regexCert = new Regex(patternCert);
                                Match matchCert = regexCert.Match(asn1ObjectCert.ToString());

                                if (matchAttr.Success && matchCert.Success)
                                {
                                    string valueAttr = matchAttr.Groups[1].Value;
                                    string valueCert = matchCert.Groups[1].Value;
                                    if (valueAttr != valueCert)
                                    {
                                        textBox_result.Text = "Серийный номер сертификата в АС не совпадает с основным сертификатом.";
                                        return;
                                    }
                                }
                                else
                                {
                                    textBox_result.Text = "Cерийный номер сертификата не найден.";
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                textBox_result.Text = "Cерийный номер сертификата не найден.";
                                return;
                            }

                            /////////////////////////////////////////////////

                            SaveFileDialog saveFileDialog = new SaveFileDialog
                            {
                                FileName = $"{fileName}IdCardAC.sgn",
                                Filter = "SGN files (*.sgn)|*.sgn"
                            };

                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string filePath = saveFileDialog.FileName;
                                File.WriteAllBytes(filePath, signatureBytes);
                            }
                            else
                                MessageBox.Show("Ошибка сохранения подписи.");

                            textBox_result.Text = formattedJson;
                        }
                    }    
                }
                if (signMethod == "AvPass")
                {
                    if (isAC == false)
                    {
                        using (var httpClient = new HttpClient())
                        {
                            var data = new StringContent($"{{\"data\": \"{base64String}\", \"isDetached\": \"{isDetached}\"}}", Encoding.UTF8, "application/json");

                            HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1:8084/sign", data);

                            string responseContent = await response.Content.ReadAsStringAsync();

                            JObject json = JObject.Parse(responseContent);

                            string formattedJson = json.ToString(Formatting.Indented);
                            textBox_result.Text = formattedJson;

                            byte[] signatureBytes = Convert.FromBase64String((string)json["cms"]);
                            SaveFileDialog saveFileDialog = new SaveFileDialog
                            {
                                FileName = $"{fileName}AvPass.sgn",
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
                    if (isAC == true)
                    {
                        using (var httpClient = new HttpClient())
                        {
                            var data = new StringContent($"{{\"data\": \"{base64String}\",\"AC\": \"{certificate}\", \"isDetached\": \"{isDetached}\"}}", Encoding.UTF8, "application/json");

                            HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1:8084/sign_cms_ac", data);

                            string responseContent = await response.Content.ReadAsStringAsync();

                            JObject json = JObject.Parse(responseContent);

                            string formattedJson = json.ToString(Formatting.Indented);          

                            byte[] signatureBytes = Convert.FromBase64String((string)json["cms"]);

 //// Сверка серийных номеров сертиифатов (легендарный костыль)
                            try
                            {
                                byte[] fileBytes = Convert.FromBase64String(certificate);
                                Asn1Object asn1ObjectAttr = Asn1Object.FromByteArray(fileBytes);
                                string patternAttr = @"\]\]\]\], (.+?)\]\]";
                                Asn1Object asn1ObjectCert = Asn1Object.FromByteArray(signatureBytes);
                                string patternCert = @"\[0\]\[\[\[\[0\]2, (.+?),";

                                Regex regexAttr = new Regex(patternAttr);
                                Match matchAttr = regexAttr.Match(asn1ObjectAttr.ToString());

                                Regex regexCert = new Regex(patternCert);
                                Match matchCert = regexCert.Match(asn1ObjectCert.ToString());

                                if (matchAttr.Success && matchCert.Success)
                                {
                                    string valueAttr = matchAttr.Groups[1].Value;
                                    string valueCert = matchCert.Groups[1].Value;
                                    if (valueAttr != valueCert)
                                    {
                                        textBox_result.Text = "Серийный номер сертификата в АС не совпадает с основным сертификатом.";
                                        return;
                                    }
                                }
                                else
                                {
                                    textBox_result.Text = "Cерийный номер сертификата не найден.";
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                textBox_result.Text = "Cерийный номер сертификата не найден.";
                                return;
                            }
     
/////////////////////////////////////////////////

                            SaveFileDialog saveFileDialog = new SaveFileDialog
                            {
                                FileName = $"{fileName}AvPassAC.sgn",
                                Filter = "SGN files (*.sgn)|*.sgn"
                            };

                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string filePath = saveFileDialog.FileName;
                                File.WriteAllBytes(filePath, signatureBytes);
                            }
                            else
                                MessageBox.Show("Ошибка сохранения подписи.");

                            textBox_result.Text = formattedJson;
                        }
                    }
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
        public static async Task VerifySignature(string base64String, TextBox textBox_result, string base64Signature, Button button_fullinfo)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var data = new StringContent($"{{\"cms\": \"{base64Signature}\", \"data\": \"{base64String}\"}}", Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1:8084/verify_cms", data);

                    string responseContent = await response.Content.ReadAsStringAsync();

                    JObject jsonResponse = JObject.Parse(responseContent);
                    string verify = (string)jsonResponse["verify"];

                    byte[] signatureBytes = Convert.FromBase64String(base64Signature);
                    certificate = new X509Certificate2(signatureBytes);
                    string subjectName = certificate.Subject;

                    string patternSN = @"SN=(\w+)";
                    string patternName = @"Отчество=(\w+(?:\s\w+)*),";
                    string patternGivenName = @"G=(\w+)";

                    Match matchSN = Regex.Match(subjectName, patternSN);
                    Match matchName = Regex.Match(subjectName, patternName);
                    Match matchGivenName = Regex.Match(subjectName, patternGivenName);

                    string surname = matchSN.Groups[1].Value;
                    string name = matchName.Groups[1].Value;
                    string givenName = matchGivenName.Groups[1].Value;

                    DateTime validFrom = certificate.NotBefore;
                    DateTime validTo = certificate.NotAfter;

                    if (verify == "OK")
                    {
                        string certificateInfo = $@"Подпись достоверна 
{surname + " " + name + " " + givenName}
";
                        textBox_result.Text = certificateInfo;           
                    }
                    else if (jsonResponse["error"] != null)
                        textBox_result.Text = "Подпись неверна. Код ошибки: " + jsonResponse["error"].ToString();
                    else
                        textBox_result.Text = "Ошибка";

                    button_fullinfo.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        public static void ShowFullInfo()
        {
            string issuerName = certificate.Issuer;
            string subjectName = certificate.Subject;
            DateTime validFrom = certificate.NotBefore;
            DateTime validTo = certificate.NotAfter;
            int version = certificate.Version;
            string serialNumber = certificate.SerialNumber;
            var extensions = certificate.Extensions;
            string extensionsInfo = Helper.GetExtensionsInfo(extensions, certificate);

            string certificateInfo = $@"
Issuer: {issuerName}
Subject: {subjectName}
Valid From: {validFrom:yyyy-MM-dd}
Valid To: {validTo:yyyy-MM-dd}
Version: {version}
Serial Number: {serialNumber}
Extensions: {extensionsInfo}
";

            MessageBox.Show(certificateInfo, "Информация о сертификате", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        
    }
}
