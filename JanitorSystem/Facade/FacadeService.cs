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
    /// <summary>
    /// This class comminicates with the TeamVice Webservice Dot.net solution through Http commands.
    /// </summary>
    public class FacadeService
    {
        #region Serverurl varible with the azure website address.
        private const string serverUrl = "http://teamvicewebservice20170518050703.azurewebsites.net";
        #endregion

        #region Get Http kald

        #region GetAssignments

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

        #endregion
        
        
        #region GetEmployees

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

        #region GetAppartmentOwners

        public static async Task<AssignmentSorting> GetAppartmentOwners(int appID)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(serverUrl);

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/Appartments/" + appID);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<AssignmentSorting>();
                    }
                }
                catch (Exception e)
                {
                    Debug.Write($"Exception {e} ");
                }

                return null;
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
        #endregion

        #region Post Http kald
        public static async Task<Assignment> PostAssignment(Assignment tempAssignment)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                

                try
                     
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync<Assignment>("api/Assignments", tempAssignment);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<Assignment>();
                    }
                }
                catch (Exception e)
                {
                    Debug.Write($"Exception {e}");
                }
                return null;
            }
        }
        #endregion

        #region Edit/Put Http kald

        public static async Task<AssignmentSorting> PutAssignComment(AssignmentSorting assignCommentEdit)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string urlString = "api/assignments/" + assignCommentEdit.AssignId;

                

                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync(urlString, assignCommentEdit);
                    if (response.IsSuccessStatusCode)
                    {
                       return await response.Content.ReadAsAsync<AssignmentSorting>();
                    }
                }
                catch (Exception e)
                {
                    Debug.Write($"Exception {e}");
                }
                return null;
            }
        }

        #endregion

        #region Delete Http kald

        public static async Task DeleteAssignment(AssignmentSorting assignmentToDelete)
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