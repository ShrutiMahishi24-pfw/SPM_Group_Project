﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Appointments_UI.Pages.Appointments
{
    using System.Security.Cryptography;
    using Appointments_API.Models;
    
    ///<summary>
      /// Gets the item inputs from the UI, evaluates them on the basis of assigned doctor and displays the details
    ///</summary>
    public class GetItemByDocModel : PageModel
    {
        public List<Appointment> ap = new();
        public async void OnGet()
        {

            string id = Request.Query["dId"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5053");
                ///<summary>
                   ///HTTP GET to obtain the appointment details based on the assigned doctor.
                ///</summary>
                var responseTask = client.GetAsync("Appointment/Analysis-GetAppointmentsByDoctor?dId=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    ap = JsonConvert.DeserializeObject<List<Appointment>>(readTask);
                }
            }
        }
    }
}
