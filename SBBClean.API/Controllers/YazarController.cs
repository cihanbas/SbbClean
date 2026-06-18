using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SBBClean.Application.DTOs;
using SBBClean.Application.Services;

namespace SBBClean.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class YazarController(IYazarService service) : ControllerBase
{
   [HttpGet]
   public async Task<ActionResult<List<YazarDto>>> GetAll()
   {
      return Ok(await service.GetAllAsync());
   }

   [HttpGet("{id}")]
   public async Task<ActionResult<YazarDto>> GetById(int id)
   {
      var yazar = await service.GetByIdAsync(id);
      return Ok(yazar);
   }

   [HttpPost]
   public async Task<ActionResult<YazarDto>> CreateAsync([FromBody] YazarDto dto)
   {
      var yazar = await service.CreateAsync(dto);
      return CreatedAtAction(nameof(GetById), new { id = yazar.Id }, yazar);
   }

}