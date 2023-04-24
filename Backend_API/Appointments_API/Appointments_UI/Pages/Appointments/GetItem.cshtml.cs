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
      /// Gets the item inputs from the UI and displays the appointment details
    ///</summary>
    public class GetItemModel : PageModel
    {
        public Appointments ap = new();
        public async void OnGet()
        {

            string id = Request.Query["appointment_id"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5053");
                ///<summary>
                  ///HTTP GET to obtain the appointment details based on the id
                ///</summary>
                var responseTask = client.GetAsync("Appointment/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    ap = JsonConvert.DeserializeObject<Appointments>(readTask);
                }
            }
        }
    }
}
