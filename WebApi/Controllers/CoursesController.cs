using Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(ApiContext context) : ControllerBase
{
    private readonly ApiContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = await _context.Courses
            .Include(c => c.Authors)
            .ToListAsync();

        if (courses == null || !courses.Any())
        {
            return NoContent();
        }

        var result = courses.Select(c => new
        {
            Id = c.Id,
            IsBestseller = c.IsBestseller,
            ImageUrl = c.ImageUrl,
            Title = c.Title,
            Price = c.Price,
            DiscountPrice = c.DiscountPrice,
            Hours = c.Hours,
            LikesInPercent = c.LikesInPercent,
            LikesInNumbers = c.LikesInNumbers,
            Authors = c.Authors.Select(a => new
            {
                Id = a.Id,
                Name = a.Name
            })
        });

        return Ok(result);
    }




}
