using System;
using System.Collections.Generic;
using HomeWork01.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneController : ControllerBase
    {
        static List<Phone> phones = new List<Phone>()
            {
                new Phone() { Model = "Iphone 13", Created = DateTime.Now, Color = "Red" },
                new Phone() { Model = "Nokia 3110", Created= new DateTime(1990, 11, 21), Color="Black"},
                new Phone() { Model = "Samsung", Created = DateTime.Now.AddDays(-5), Color = "Red" },
                new Phone() { Model = "LG" },
                new Phone() { Model = "XiaMi" }
            };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(phones);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(phones[id]);
        }

        [HttpPost]
        public IActionResult Post(Phone phone)
        {
            phones.Add(phone);
            return Created(phones.Count.ToString(), "Phone was added to collection!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Phone phone)
        {
            try
            {
                phones[id] = phone;
                return Ok("Phone was updated!");
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Mising index {id} in phone collection!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                phones.Remove(phones[id]);
                return Ok($"Phone with id {id} was deleted!");
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Mising index {id} in phone collection!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}