﻿using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppointmentsManager.Data.Models;
using Proiect_appointments.Models;
using Proiect_appointments.Data; // Add this line
using Microsoft.AspNetCore.Authorization;
using System.Data;


namespace Proiect_appointments.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Appointments - default
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
          if (_context.Appointments == null)
          {
              return NotFound("No Data Found!");
          }
            return await _context.Appointments.Where(e=> !e.Deleted && !e.Done).ToListAsync();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
          if (_context.Appointments == null)
          {
              return NotFound("No Data Found!");
          }
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound("No Data Found!");
            }

            return appointment;
        }

        [HttpPost("filters")]
        public async Task<ActionResult<IEnumerable<Appointment>>> FilteredAppointments(Filter filters)
            {
            if (_context.Appointments == null)
            {
                return NotFound("No Data Found!");
            }

            List<Appointment> allData = await _context.Appointments.ToListAsync();

            if(filters.All)
            {
                return allData;
            };

            if(filters.LevelOfImportance !=null)
            {
                allData = allData.Where(e=> e.LevelOfImportance ==  filters.LevelOfImportance).ToList();
            }

            if (filters.SpecifiedDate != null)
            {
                allData = allData.Where(e => e.Date == filters.SpecifiedDate).ToList();
            }

            if (filters.StartDate != null && filters.EndDate !=null)
            {
                allData = allData.Where(e => e.Date >= filters.StartDate && e.Date <=filters.EndDate).ToList();
            }

            if (filters.SpecifiedTime != null)
            {
                allData = allData.Where(e => e.Time == filters.SpecifiedTime).ToList();
            }

            allData = allData.Where(e => e.Done == filters.Done).ToList();
            allData = allData.Where(e => e.Deleted == filters.Deleted).ToList();

            return allData;

        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.ID)
            {
                return BadRequest("You are trying to modify the wrong appointment.");
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {

                Appointment entry_ = await _context.Appointments.FirstAsync(e=> e.ID == appointment.ID);

                if (entry_.Title != appointment.Title) 
                {
                    entry_.Title = appointment.Title;
                }

                if (entry_.Description != appointment.Description)
                {
                    entry_.Description = appointment.Description;
                }

                if (entry_.Address != appointment.Address)
                {
                    entry_.Address = appointment.Address;
                }
                if (entry_.LevelOfImportance != appointment.LevelOfImportance)
                {
                    entry_.LevelOfImportance = appointment.LevelOfImportance;
                }
                if (entry_.Done != appointment.Done)
                {
                    entry_.Done = appointment.Done;
                }
                if (entry_.Deleted != appointment.Deleted)
                {
                    entry_.Deleted = appointment.Deleted;
                }
                if (entry_.Date != appointment.Date)
                {
                    entry_.Date = appointment.Date;
                }
                if (entry_.Time != appointment.Time)
                {
                    entry_.Time = appointment.Time;
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound("The appointment with the Id" + " " + id + " does not exist!");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Appointment updated successfully!");
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
          if (_context.Appointments == null)
          {
              return Problem("Entity set 'Appointments'  is null.");
          }

            try {
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException e)
            {
                return BadRequest("Could not create the new Appointment: " + e.Message);
            }

            return CreatedAtAction("GetAppointment", new { id = appointment.ID }, appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            if (_context.Appointments == null)
            {
                return NotFound("No Data Found!");
            }
            var appointment = await _context.Appointments.FirstAsync(e => e.ID == id);
            if (appointment == null)
            {
                return NotFound("No appointment with the ID " + id);
            }

           Appointment entry_ = await _context.Appointments.FirstAsync(e => e.ID == appointment.ID);
            entry_.ModifiedDate = DateTime.Now;
            entry_.Deleted = true;
            await _context.SaveChangesAsync();

            return Ok("Appointment deleted successfully.");
        }

        private bool AppointmentExists(int id)
        {
            return (_context.Appointments?.Any(e => e.ID == id)).GetValueOrDefault();
        }



    }
}
