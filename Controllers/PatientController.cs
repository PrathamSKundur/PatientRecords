using System.Collections.Generic;
using System.Linq;
using Fresh.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace api2.Controllers
{
[Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private PatientContext Context;
        public PatientController(PatientContext context)
        {
            this.Context = context;
        }
        [HttpPost("{filter}")]
        public ActionResult<IEnumerable<Patient>> FilterByDates([FromBody]dates d)
        {
            List<Patient> lists = Context.patients.Where(p => ((p.appointment_date >= d.d1) && (p.appointment_date < d.d2))).ToList();
            return lists;
                      
        }
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> Get()
        {
            List<Patient> l = Context.patients.ToList();
            l.Add(Context.patients.FirstOrDefault(X=>X.patient_id==2));
            return l;
        }
        [HttpGet("{id}")]
        public ActionResult<Patient> GetId(int id)
        {
           return Context.patients.FirstOrDefault(x=>x.patient_id==id);
           
        }
         /*[HttpGet("{name}")]
        public ActionResult<Patient> GetName(string name)
        {
           return Context.patients.FirstOrDefault(x=>x.patient_name==name);
           
        }
        */
        [HttpPost]
        public ActionResult<Patient> Post([FromBody]Patient product)
        {
            if(product==null)
            return BadRequest();
             Context.patients.Add(product);
             Context.SaveChanges();
             return Ok(product);
        }

       [HttpPut("{id}")]
        public ActionResult<Patient> Update(int? id,Patient patient)
        {
            if(id==null)
            return BadRequest();
           Patient pr=Context.patients.FirstOrDefault(x=>x.patient_id==id);
        //    pr.price=product.price;
        //    pr.name=product.name;
        //    pr.description=product.description;
        //    pr.patient_name = patient.patient_name;
         //   pr.DOB =patient.DOB;
            if(!String.IsNullOrEmpty(patient.address))
                pr.address = patient.address;
            if(!String.IsNullOrEmpty(patient.contact))
                pr.contact=patient.contact;
            if(!String.IsNullOrEmpty(patient.email))
                pr.email=patient.email;
            if(!String.IsNullOrEmpty(patient.diagnosis_reason))
                pr.diagnosis_reason=patient.diagnosis_reason;
            if(!String.IsNullOrEmpty(patient.doctor_name))
                pr.doctor_name=patient.doctor_name;
            if(patient.appointment_date!=DateTime.MinValue)
                pr.appointment_date=patient.appointment_date;
            if(!String.IsNullOrEmpty(patient.appointment_time))
                pr.appointment_time=patient.appointment_time;

           Context.patients.Update(pr);
            Context.SaveChanges();
             return new NoContentResult();
        }

      

    }
}