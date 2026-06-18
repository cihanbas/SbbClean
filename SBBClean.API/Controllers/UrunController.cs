using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SBBClean.Application.DTOs;
using SBBClean.Application.Services;

namespace SBBClean.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UrunController(IUrunService service) : ControllerBase
{
   [HttpGet]
   public async Task<ActionResult<List<UrunDto>>> GetAll()
   {
      return Ok(await service.GetAllAsync());
   }

   [HttpGet("{id}")]
   public async Task<ActionResult<UrunDto>> GetById(int id)
   {
      var urun = await service.GetByIdAsync(id);
      return Ok(urun);
   }

   [HttpPost]
   public async Task<ActionResult<UrunDto>> CreateAsync([FromBody] UrunCreateDto dto)
   {
      var urun = await service.CreateAsync(dto);
      return CreatedAtAction(nameof(GetById), new { id = urun.Id }, urun);
   }

}