using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBBClean.Application.DTOs;
using SBBClean.Application.Services;

namespace SBBClean.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class KitapController : ControllerBase
{
    private readonly IKitapService _kitapService;

    public KitapController(IKitapService kitapService)
    {
        _kitapService = kitapService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _kitapService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var kitap = await _kitapService.GetByIdAsync(id);
        return kitap is null ? NotFound() : Ok(kitap);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] KitapCreateDto dto)
    {
        var kitap = await _kitapService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = kitap.Id }, kitap);
    }
}
