using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace AppointmentsDetails.Pages.Appointments
{
    using Appointments_API.Models;
    using Newtonsoft.Json;

    ///<summary>
    /// Manages the appointment details of the patient.
    ///</summary>

    public class CreateModel : PageModel
    {
        public Appointments todo = new();
        public List<Appointments> apps = new();
        public string errorMessage = "";
        public string successMessage = "";
        public async Task<IActionResult> OnPost()
        {
            /// Assigning the appointment details of the patient to local variables.

            todo.doctor_id = int.Parse(Request.Form["doctor_id"]);
            todo.patient_id = int.Parse(Request.Form["patient_id"]);
            todo.appointment_time = DateTime.Parse(Request.Form["appointment_time"]);
            todo.patient_name = Request.Form["patient_name"];
            todo.doctor_name = Request.Form["doctor_name"];
            todo.doctor_department = Request.Form["doctor_department"];
            todo.patient_disease = Request.Form["patient_disease"];

            todo.patient_age = int.Parse(Request.Form["patient_age"]);

            ///<summary>
            /// Validating and Submitting the appointment details of the patient.
            ///</summary>

            if (todo.appointment_time == null)
            {
                errorMessage = "Appointment time is required";
            }
            else
            {
                var opt = new JsonSerializerOptions() { WriteIndented = true };
                string json = System.Text.Json.JsonSerializer.Serialize<Appointments>(todo, opt);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5053");
                    var responseTask = client.GetAsync("Appointment/Analysis-GetAppointmentsByDoctor?dId=" + todo.doctor_id);
                    responseTask.Wait();
                    var resultList = responseTask.Result;
                    bool flag = false;
                    if (resultList.IsSuccessStatusCode)
                    {
                        var readTask = await resultList.Content.ReadAsStringAsync();
                        apps = JsonConvert.DeserializeObject<List<Appointments>>(readTask);
                    }
                    foreach (var item in apps)
                    {
                        if (todo.appointment_time == item.appointment_time)
                        {
                            errorMessage = "This appointment time is already booked for the doctor";
                            flag = true;
                        }
                    }
                    if (flag == false)
                    {

                        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                        var result = await client.PostAsync("Appointment", content);
                        string resultContent = await result.Content.ReadAsStringAsync();
                        Console.WriteLine(resultContent);
                        if (!result.IsSuccessStatusCode)
                        {
                            errorMessage = "Error adding";
                        }
                        else
                        {
                            successMessage = "Successfully added";
                        }
                    }
                }
            }
            return RedirectToPage("/Index");
        }
    }
}
