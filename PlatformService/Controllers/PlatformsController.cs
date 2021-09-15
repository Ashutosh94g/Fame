using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controller
{

	[Route("api/[controller]")]
	[ApiController]
	public class PlatformsController : ControllerBase
	{
		private readonly IPlatformRepo _repo;
		private readonly IMapper _mapper;

		public PlatformsController(IPlatformRepo repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}


		[HttpGet]
		public ActionResult<IEnumerable<PlatformReadDto>> getAllPlatforms()
		{
			Console.WriteLine("--> Getting all Platforms...");

			var platformItems = _repo.getAllPlatforms();

			return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
		}

		[HttpGet("{id}", Name = "getPlatformById")]
		public ActionResult<PlatformReadDto> getPlatformById(int id)
		{
			var platformItem = _repo.getPlatformById(id);

			if (platformItem != null)
			{
				return Ok(_mapper.Map<PlatformReadDto>(platformItem));
			}

			return NotFound();
		}

		[HttpPost]
		public ActionResult<PlatformReadDto> createPlatform(PlatformCreateDto platformCreateDto)
		{
			var platformModel = _mapper.Map<Platform>(platformCreateDto);
			_repo.createPlatform(platformModel);
			_repo.SaveChanges();

			PlatformReadDto platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
			return CreatedAtRoute(nameof(getPlatformById), new { id = platformReadDto.Id }, platformReadDto);
		}
	}
}