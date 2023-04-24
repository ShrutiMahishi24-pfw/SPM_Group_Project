using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

///<summary>
///C# implementation for Maintaining Appointment Count 
///</summary>
namespace AppointmentsDetails.Pages.Appointments
{
    //Gets the maximum value
    public class AppointmentsCount : PageModel
    {
        public int apcount = new();
        public async void OnGet()
        {
            var client = new HttpClient();
            var responseTask = client.GetAsync("http://localhost:5053/Appointment/Analysis-GetAppointmentsCount");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                apcount = JsonConvert.DeserializeObject<int>(content);
            }
        }
    }
}
