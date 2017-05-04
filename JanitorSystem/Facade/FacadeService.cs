using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JanitorSystem.Model;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace JanitorSystem.Facade
{
    public class FacadeService
    {
        private const string serverUrl = "http://vicewebservices20170502020205.azurewebsites.net";

        public static async Task<ObservableCollection<Assignment>> GetAssignmentList()
        {
            ObservableCollection<Assignment> tempList = new ObservableCollection<Assignment>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(serverUrl);

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/Assignments");

                    if (response.IsSuccessStatusCode)
                    {
                        tempList = await response.Content.ReadAsAsync<ObservableCollection<Assignment>>();
                    }
                }
                catch (Exception e)
                {
                    Debug.Write($"Exception {e} ");
                    tempList = null;
                }

                return tempList;

            }
        }
    

    }
}
