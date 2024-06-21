using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCES_CP
{
    internal class HTTP
    {
        public static async Task SendHttpRequestAsync(string base64String, Label label_result)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var data = new StringContent($"{{\"data\": \"{base64String}\"}}", Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1:8084/sign", data);

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
