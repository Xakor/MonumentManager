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

        public async Task DeleteSculpture(SculptureModel selectedSculpture) //here we are passing on the selected sculpture to the method
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    if (selectedSculpture == null)
                    {
                        new MessageDialog("Sculpture not selected").ShowAsync();
                    }
                    else
                    {
                        string deleteUrl = "api/Sculptures/" + selectedSculpture.Id;
                        var response = await client.DeleteAsync(deleteUrl);
                    }


                }
                catch (Exception e)
                {
                    new MessageDialog(e.Message).ShowAsync();
                }
            }

        }

        public void AddInspection(InspectionModel ins)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    ins.date = DateTime.Now;
                    string newInspectionjson = JsonConvert.SerializeObject(ins);
                    //Create the content we will send in the Http post request 
                    var content = new StringContent(newInspectionjson, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("api/Inspections/AddInspectionToSculpture", content).Result;
                   // var response = await client.PostAsync("api/Inspections/AddInspectionToSculpture", content);
                    if (response.IsSuccessStatusCode)
                    {
                        //Success , Now we can get the inspection by a Http post
                        new MessageDialog("Inspection created").ShowAsync();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public List<InspectionModel> GetInspections()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Inspections").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var inspectionsList = response.Content.ReadAsAsync<IEnumerable<InspectionModel>>().Result;
                        return inspectionsList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }

        }

        public List<DamageModel> GetDamages()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Damages").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var damagesList = response.Content.ReadAsAsync<IEnumerable<DamageModel>>().Result;
                        return damagesList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }

        }

        public void AddDamage(DamageModel dmg)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    
                    string newDamagejson = JsonConvert.SerializeObject(dmg);
                    //Create the content we will send in the Http post request 
                    var content = new StringContent(newDamagejson, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("api/Damages/AddDamageToSculpture", content).Result;
                    
                    if (response.IsSuccessStatusCode)
                    {
                        //Success , Now we can get the damage by a Http post
                        new MessageDialog("Damage created").ShowAsync();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }


    }
}
