using System;
using System.ComponentModel.DataAnnotations;
//using System.DateTime;
namespace Fresh.Models
{
public class Patient
    {
        [Key]
        public int patient_id { get; set; }
        public string patient_name { get; set; }
        //[Column(TypeName="date")
        
         public string DOB { get; set; } 
        public string address { get; set; }
        public string contact{get;set;}
        public string email{ get; set; }
        public string diagnosis_reason{ get; set; }
        public string doctor_name{ get; set; }

        public DateTime appointment_date { get; set; }
        public string appointment_time { get; set; }
        public Patient(int patient_id, string patient_name,string DOB,string address,string contact,string email,string diagnosis_reason,string doctor_name,DateTime appointment_date,string appointment_time)
        {
            this.patient_id = patient_id;
            this.patient_name = patient_name;
            this.DOB = DOB;
            this.address = address;
            this.contact=contact;
            this.email=email;
            this.diagnosis_reason=diagnosis_reason;
            this.doctor_name=doctor_name;
            this.appointment_date=appointment_date;
            this.appointment_time=appointment_time;
        }
    }
}
