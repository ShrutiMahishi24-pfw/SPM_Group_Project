using System;
using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models
{
    public class Appointments
    {
        /// <summary>
        /// These are columns and types of data in the Appointments database for Appointments table
        /// which are taken as columns file class.
        /// </summary>
        /// <param name="doctor_id"></param>
        /// <param name="patient_id"></param>
        /// <param name="appointment_id"></param>
        /// <param name="appointment_time"></param>
        /// <param name="patient_name"></param>
        /// <param name="doctor_name"></param>
        /// <param name="doctor_department"></param>
        /// <param name="patient_disease"></param>
        /// <param name="patient_age"></param>
        /// <summary>
        /// Declaration of the attributes are done here
        /// </summary>
        public int doctor_id { get; set; }
        public int patient_id { get; set; }
        [Key]
        public int appointment_id { get; set; } = 1;
        public DateTime appointment_time { get; set; }
        public String patient_name { get; set; } = String.Empty;
        public String doctor_name { get; set; } = String.Empty;
        public String doctor_department { get; set; } = String.Empty;
        public String patient_disease { get; set; } = String.Empty;
        public int patient_age { get; set; }

    }
}
