using Microsoft.AspNetCore.Mvc;
using XtraWork.Requests;
using XtraWork.Responses;
using XtraWork.Services;

namespace XtraWork.Controllers;

[ApiController]
[Route("title")]
public class TitleController : ControllerBase
{
    private readonly TitleService _titleService;

    public TitleController(TitleService titleService)
    {
        _titleService = titleService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TitleResponse>>> GetAll()
    {
        var response = await _titleService.GetAll();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TitleResponse>> Get(int id)
    {
        var response = await _titleService.Get(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<TitleResponse>> Create([FromBody] TitleRequest request)
    {
        try
        {
            var response = await _titleService.Create(request);
            return StatusCode(StatusCodes.Status201Created, response);
        }
        catch (Exception e)
        {
            var errorResponse = new
            {
                Status = StatusCodes.Status400BadRequest,
                Message = e.Message
            };
            return BadRequest(errorResponse);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TitleResponse>> Update(int id, [FromBody] TitleRequest request)
    {
        try
        {
            var response = await _titleService.Update(id, request);
            return Ok(response);
        }
        catch (Exception e)
        {
            var errorResponse = new
            {
                Status = StatusCodes.Status400BadRequest,
                Message = e.Message
            };
            return BadRequest(errorResponse);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _titleService.Delete(id);
            return NoContent();
        }
        catch (Exception e)
        {
            var errorResponse = new
            {
                Status = StatusCodes.Status400BadRequest,
                Message = e.Message
            };
            return BadRequest(errorResponse);
        }
    }
}