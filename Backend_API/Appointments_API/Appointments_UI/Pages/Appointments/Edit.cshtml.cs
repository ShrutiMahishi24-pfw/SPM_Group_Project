using System;
using System.Collections.Generic;
using System.Linq;
using Appointments_API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Newtonsoft.Json;
using Appointments_UI.Pages;
using Appointments_API;

namespace Appointments_UI.Pages.Appointments
{
    using Appointments_API.Models;

     ///<summary>
      ///Obtaining and Editing the appointment details of the patient.
    ///</summary>
    public class EditModel : PageModel
    {
        public Appointment todo = new();
        public string errorMessage = "";
        public string successMessage = "";

        public async void OnGet()
        {
            string id = Request.Query["id"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5053");
                
                //HTTP GET request to get the appropriate appointment details of the patient to edit.
                var responseTask = client.GetAsync("Appointment/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    todo = JsonConvert.DeserializeObject<Appointment>(readTask);
                }
            }
        }

        public async void OnPost()
        {
            /// Assigning the appointment details of the patient to local variables.

            todo.appointment_id = int.Parse(Request.Form["id"]);
            todo.doctor_id = int.Parse(Request.Form["doctor_id"]);
            todo.patient_id = int.Parse(Request.Form["patient_id"]);
            todo.appointment_time = DateTime.Parse(Request.Form["appointment_time"]);
            todo.patient_name = Request.Form["patient_name"];
            todo.doctor_name = Request.Form["doctor_name"];
            todo.doctor_department = Request.Form["doctor_department"];
            todo.patient_disease = Request.Form["patient_disease"];

            todo.patient_age = int.Parse(Request.Form["patient_age"]);

            if (todo.appointment_time == null)
            {
                errorMessage = "Appointment Time is Required";
            }
            else
            {
                var opt = new JsonSerializerOptions() { WriteIndented = true };
                string json = System.Text.Json.JsonSerializer.Serialize<Appointment>(todo, opt);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5053");

                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                   
                    ///<summary>
                      ///HTTP PUT request to update the appropriate appointment details of the patient.
                    ///</summary>
                    var result = await client.PutAsync("Appointment", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);

                    if (!result.IsSuccessStatusCode) {
                        errorMessage = "Error editing";
                    } else {
                        successMessage = "Successfully edited";
                    }
                }
            }
        }
    }
}
