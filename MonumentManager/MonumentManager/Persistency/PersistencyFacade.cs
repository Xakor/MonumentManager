using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;
using MonumentManager.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Newtonsoft.Json;


namespace MonumentManager.Persistency
{
    class PersistencyFacade
    {
        const string ServerUrl = "http://localhost:50000";
        HttpClientHandler handler;

        public  PersistencyFacade()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }

        public List<SculptureModel> GetSculptures()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Sculptures").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var sculptureList = response.Content.ReadAsAsync<IEnumerable<SculptureModel>>().Result;
                        return sculptureList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }

        }

        public void SaveSculpture(SculptureModel sculpture)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(sculpture);
                    var response =
                        client.PostAsync("api/Sculptures",
                            new StringContent(postBody, Encoding.UTF8, "application/json")).Result;

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }

        }
    }
}
