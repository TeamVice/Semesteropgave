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
using System.Collections;
using System.ComponentModel;
 

namespace JanitorSystem.Facade
{
    public class FacadeService
    {
        private const string serverUrl = "http://vicewebservice20170509030408.azurewebsites.net";

        #region Get Http kald

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

        public static async Task<ObservableCollection<RegAssignment>> GetRegAssignmentList()
        {
            ObservableCollection<RegAssignment> tempList = new ObservableCollection<RegAssignment>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(serverUrl);

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/RegAssignments");

                    if (response.IsSuccessStatusCode)
                    {
                        tempList = await response.Content.ReadAsAsync<ObservableCollection<RegAssignment>>();
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

        public static async Task<ObservableCollection<Employee>> GetEmployeeList()
        {
            ObservableCollection<Employee> tempList = new ObservableCollection<Employee>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(serverUrl);

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/Employees");

                    if (response.IsSuccessStatusCode)
                    {
                        tempList = await response.Content.ReadAsAsync<ObservableCollection<Employee>>();
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

        #endregion


        #region GetAppartments

        public static async Task<ObservableCollection<Appartment>> GetAppartmentList()
        {
            ObservableCollection<Appartment> tempList = new ObservableCollection<Appartment>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(serverUrl);

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/Appartments");

                    if (response.IsSuccessStatusCode)
                    {
                        tempList = await response.Content.ReadAsAsync<ObservableCollection<Appartment>>();
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


        #endregion

        #region GetDepartment

        public static async Task<ObservableCollection<Department>> GetDepartmentList()
        {
            ObservableCollection<Department> tempList = new ObservableCollection<Department>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(serverUrl);

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/Departments");

                    if (response.IsSuccessStatusCode)
                    {
                        tempList = await response.Content.ReadAsAsync<ObservableCollection<Department>>();
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

        #endregion

        #region Post Http kald
        public static async Task<bool> PostAssignment(Assignment tempAssignment)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("apllication/json"));
                

                var response = await client.PostAsJsonAsync<Assignment>("api/assignments", tempAssignment);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region Edit/Put Http kald

        public static async Task<bool> EditAssignment(Assignment assignmentEdit)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string urlString = "api/assignments/" + assignmentEdit.AssignId;

                var response = await client.PutAsJsonAsync(urlString, assignmentEdit);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region Delete Http kald

        public static async Task DeleteAssignment(Assignment assignmentToDelete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                string urlString = "api/assignments/" + assignmentToDelete.AssignId;
                await client.DeleteAsync(urlString);
            }
        } 

        #endregion
    }
}
