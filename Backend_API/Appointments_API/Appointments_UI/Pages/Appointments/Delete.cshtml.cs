using System;
using System.Collections.Generic;
using System.Linq;
using Appointments_API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AppointmentsDetails.Pages.Appointments
{
    using System.ComponentModel.DataAnnotations;
    using Appointments_API.Models;
     
    ///<summary>
      /// Obtaining and Deleting the appointment of the patient.
    ///</summary>
    public class DeleteModel : PageModel
    {
        public Appointments todo = new();
        public string errorMessage = "";
        public string successMessage = "";
        public async void OnGet()
        {

        string id = Request.Query["id"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5053");
                //HTTP GET Request to obtain the appointment details of the patient.
                var responseTask = client.GetAsync("Appointment/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    todo = JsonConvert.DeserializeObject<Appointments>(readTask);
                }
            }
        }


        public async Task<IActionResult> OnPost()
        {
            bool isDeleted = false;
            int id = int.Parse(Request.Form["id"]);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5053");
                
                ///<summary>
                   ///HTTP DELETE Request to delete the appointment details of the patient.
                ///</summary>
                var response = await client.DeleteAsync("/Appointment/" + id);
                if (response.IsSuccessStatusCode)
                {
                    isDeleted = true;
                }
            }

            if (isDeleted)
            {
                successMessage = "Successfully deleted";
            }
            else
            {
                errorMessage = "Error deleting";
            }
            return RedirectToPage("/Index");
        }
    }
}
