﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBankManagementSystem.Repositories;
using BloodBankManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;


namespace BloodBankManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodDonationCampController:ControllerBase
    {
        
        private IBloodDonationCamp _repository = null;
        public BloodDonationCampController(IBloodDonationCamp repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAllBloodDonationCamps")]
        public IActionResult Get()
        {
            List<BloodDonationCamp> bloodDonationCamps = _repository.GetAllBloodDonationCamps();
            return Ok(bloodDonationCamps);
        }

        [HttpGet]
        [Route("GetBloodDonationCampStartDate/{id}")]

        public IActionResult GetBloodDonationStartDate(int id)
        {
            try
            {
                DateTime bloodDonationCamp = _repository.GetBloodDonationStartDate(id);

                if (bloodDonationCamp != DateTime.Now)
                {
                    return Ok(bloodDonationCamp);
                }
                else
                {
                    return Content("Invalid Id");

                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
            [HttpPost]
            [Route("AddBloodDonationCamp")]
            public IActionResult AddBloodDonationCamp(BloodDonationCamp bloodDonationCamp)
            {
            try
            {
                _repository.AddBloodDonationCamp(bloodDonationCamp);
                return Ok("blood donation camp added");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            }
        [HttpPut]
        [Route("EditBloodDonationCamp")]
        public IActionResult EditBloodDonationCamp(BloodDonationCamp bloodDonationCamp)
        {
            try
            {
                _repository.EditBloodDonationCamp(bloodDonationCamp);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



    }
}
