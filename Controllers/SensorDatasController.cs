﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_Demo.Data;
using Web_API_Demo.Models;

namespace Web_API_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDatasController : ControllerBase
    {
        private readonly Web_API_DemoContext _context;

        public SensorDatasController(Web_API_DemoContext context)
        {
            _context = context;
        }

        // GET: api/SensorDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorData>>> GetSensorData()
        {
            return await _context.SensorData.ToListAsync();
        }

        // GET: api/SensorDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorData>> GetSensorData(int id)
        {
            var sensorData = await _context.SensorData.FindAsync(id);

            if (sensorData == null)
            {
                return NotFound();
            }

            return sensorData;
        }

        // PUT: api/SensorDatas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorData(int id, SensorData sensorData)
        {
            if (id != sensorData.Id)
            {
                return BadRequest();
            }

            _context.Entry(sensorData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SensorDatas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SensorData>> PostSensorData(SensorData sensorData)
        {
            _context.SensorData.Add(sensorData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensorData", new { id = sensorData.Id }, sensorData);
        }

        // DELETE: api/SensorDatas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SensorData>> DeleteSensorData(int id)
        {
            var sensorData = await _context.SensorData.FindAsync(id);
            if (sensorData == null)
            {
                return NotFound();
            }

            _context.SensorData.Remove(sensorData);
            await _context.SaveChangesAsync();

            return sensorData;
        }

        private bool SensorDataExists(int id)
        {
            return _context.SensorData.Any(e => e.Id == id);
        }
    }
}
