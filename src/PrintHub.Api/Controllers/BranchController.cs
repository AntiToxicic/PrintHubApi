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
    public async Task<IActionResult> CreateBranch([FromBody] CreateBranchDto createBranchDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var branchDto = await _branchService.Add(createBranchDto);

        if (branchDto is null)
            return StatusCode(StatusCodes.Status500InternalServerError, "Филиал не создан");

        return CreatedAtAction(nameof(GetBranch), 
            new { branchId = branchDto.Id }, branchDto);
    }

    [HttpGet("{branchId}")]
    public async Task<IActionResult> GetBranch(uint branchId)
    {
        var branch = await _branchService.GetById(branchId);

        if (branch is null)
            return NotFound();

        return Ok(branch);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllBranches()
    {
        var branchesDtos = await _branchService.GetAll();

        if (branchesDtos.Count == 0)
            return NotFound();

        return Ok(branchesDtos);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBranch([FromBody] BranchDto branchDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedBranch = await _branchService.Update(branchDto);

        if (updatedBranch is null)
            return NotFound();

        return Ok(updatedBranch);
    }

    [HttpDelete("{branchId}")]
    public async Task<IActionResult> DeleteBranch(uint branchId)
    {
        await _branchService.Delete(branchId);

        return NoContent();
    }

}