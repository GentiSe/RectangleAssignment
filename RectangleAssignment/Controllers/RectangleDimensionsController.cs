using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RectangleAssignment.Application.Requests;
using RectangleAssignment.Application.Responses;
using RectangleAssignment.Domain;
using RectangleAssignment.Infrastructure;

namespace RectangleAssignment.Controllers;

[Route("api/v1/rectangle-dimensions")]
[ApiController]
public class RectangleDimensionsController(RectangleDbContext dbContext) : ControllerBase
{
    private readonly RectangleDbContext _context = dbContext;

    [HttpGet]
    public async Task<IActionResult> GetInitialDimensions()
    {
        var response = await _context.RectangleDimensions.Select(x => new RectangleDimensionResponse
        {
            Width = x.Width,
            Height = x.Height,
        }).FirstOrDefaultAsync();

       var result = response ?? new RectangleDimensionResponse { Width = 100, Height = 100 };

        return Ok(result);
    }


    [HttpPost]

    public async Task<IActionResult> SaveRectangleDimensions([FromBody] AddRectangleDimensionRequest request)
    {
        if (request is null) return BadRequest("Dimensions were not provided");

        if(request.Width <= 0 || request.Height <= 0)
        {
            return BadRequest("Invalid dimensions for the rectangle.");
        }

        await Task.Delay(10000);

        if(request.Width > request.Height)
        {
            return BadRequest(new { message = "Width cannot excceed height" });
        }

        await _context.RectangleDimensions.AddAsync(new RectangleDimension
        {
            Height = request.Height,
            Width = request.Width,
            Perimeter = request.Perimeter,
            CreateDate = DateTime.UtcNow
        });

        await _context.SaveChangesAsync();

        return Created();
    }
}
