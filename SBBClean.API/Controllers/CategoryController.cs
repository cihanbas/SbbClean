using Microsoft.AspNetCore.Mvc;
using SBBClean.Application.DTOs;
using SBBClean.Application.Services;

namespace SBBClean.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService category) : ControllerBase
{
    // GET
    public async Task<ActionResult<List<CategoryDto>>> Index()
    {
        return Ok( await category.GetAllAsync());
    }
}