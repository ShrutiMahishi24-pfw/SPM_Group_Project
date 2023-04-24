using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AppointmentsDetails.Pages.Appointments
{
    using Appointments_API.Models;
    ///<summary>
    // gets the item from the UI and displays the details
    ///</summary>
    public class GetItemByDiseaseModel : PageModel
    {
        public List<Appointments> ap = new();
        public async void OnGet()
        {

            string id = Request.Query["disease"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5053");
                //HTTP GET
                var responseTask = client.GetAsync("Appointment/Analysis-GetAppointmentsByDisease?disease=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    ap = JsonConvert.DeserializeObject<List<Appointments>>(readTask);
                }
            }
        }
    }
}
