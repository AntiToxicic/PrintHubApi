using Microsoft.AspNetCore.Mvc;
using PrintHub.Core.Dtos;
using PrintHub.Core.Interfaces.Services;

namespace PrintHubAPI.Controllers;

[ApiController]
[Route("api/branches")]
public class BranchApiController : ControllerBase
{
    private readonly IBranchService _branchService;

    public BranchApiController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBranch([FromBody] CreateBranchDto branchDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var branch = await _branchService.Add(branchDto);

        if (branch is null)
            return StatusCode(StatusCodes.Status500InternalServerError, "Филиал не был создан");

        return Ok(branch);
    }

    [HttpGet("{branchId}")]
    public async Task<IActionResult> GetBranch(uint branchId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var branch = await _branchService.GetById(branchId);

        if (branch is null)
            return NotFound();

        return Ok(branch);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBranch([FromBody] BranchDto branchDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var branch = await _branchService.Update(branchDto);

        if (branch is null)
            return NotFound();

        return Ok(branch);
    }

    [HttpDelete("{branchId}")]
    public async Task<IActionResult> DeleteBranch(uint branchId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _branchService.Delete(branchId);
        
        return Ok();
    }
}