﻿using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.ReservationDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateReservationDto> _validator;
        public ReservationController(IReservationService reservationService, IMapper mapper, IValidator<CreateReservationDto> validator)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult ReservationList()
        {
            var values =_mapper.Map<List<ResultReservationDto>>(_reservationService.TGetAll());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult ReservationGetById(int id)
        {
            var value = _reservationService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("ReservationCount")]
        public IActionResult ReservationCount()
        {
            var count = _reservationService.TGetReservationCount();
            return Ok(new { Count = count });
        }[HttpGet("ActiveReservationCount")]
        public IActionResult ActiveReservationCount()
        {
            var count = _reservationService.TGetActiveReservationCount();
            return Ok(new { Count = count });
        }[HttpGet("InActiveReservationCount")]
        public IActionResult InActiveReservationCount()
        {
            var count = _reservationService.TGetInActiveReservationCount();
            return Ok(new { Count = count });
        }
        [HttpPost]
        public IActionResult ReservationAdd(CreateReservationDto reservation)
        {

            var validationResult = _validator.Validate(reservation);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }


            var reservationEntity = _mapper.Map<Reservation>(reservation);

            _reservationService.TInsert(reservationEntity);


            return CreatedAtAction(nameof(ReservationGetById), new { id = reservationEntity.ReservationId }, reservationEntity);
        }
        [HttpPut]
        public IActionResult ReservationUpdate(UpdateReservationDto reservation)
        {
            if (reservation == null)
            {
                return BadRequest("Reservation data is null");
            }
            var existingReservation = _reservationService.TGetById(reservation.ReservationId);
            if (existingReservation == null)
            {
                return NotFound();
            }

            // Map UpdateReservationDto to Reservation entity
            var updatedReservation = _mapper.Map(reservation, existingReservation);

            _reservationService.TUpdate(updatedReservation);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public IActionResult ReservationDelete(int id)
        {
            var reservation = _reservationService.TGetById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            _reservationService.TDelete(reservation);
            return NoContent();
        }
    }
}
