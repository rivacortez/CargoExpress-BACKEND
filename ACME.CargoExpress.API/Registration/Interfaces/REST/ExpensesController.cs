using ACME.CargoExpress.API.Registration.Domain.Model.Queries;
using ACME.CargoExpress.API.Registration.Domain.Services;
using ACME.CargoExpress.API.Registration.Interfaces.REST.Resources;
using ACME.CargoExpress.API.Registration.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;


namespace ACME.CargoExpress.API.Registration.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
public class ExpensesController(IExpenseCommandService expenseCommandService, IExpenseQueryService expenseQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseResource createExpenseResource)
    {
        try
        {
            var createExpenseCommand = CreateExpenseCommandFromResourceAssembler.ToCommandFromResource(createExpenseResource);
            var expense = await expenseCommandService.Handle(createExpenseCommand);
            if (expense is null) return BadRequest();
            var resource = ExpenseResourceFromEntityAssembler.ToResourceFromEntity(expense);
            return CreatedAtAction(nameof(GetExpenseById), new { expenseId = resource.Id }, resource);
        }
        catch (InvalidOperationException e)
        {
            // Handle the case where an Expense with the same TripId already exists
            return BadRequest(new {message = "An Expense with the same TripId already exists."});
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = "An error occurred while creating the expense. " + e.Message });
        }
    }
    
    [HttpPut("{expenseId}")]
    public async Task<IActionResult> UpdateExpense([FromBody] UpdateExpenseResource updateExpenseResource, [FromRoute] int expenseId)
    {
        try
        {
            var updateExpenseCommand = UpdateExpenseCommandFromResourceAssembler.ToCommandFromResource(updateExpenseResource, expenseId);
            var expense = await expenseCommandService.Handle(updateExpenseCommand);
            if (expense is null) return BadRequest();
            var resource = ExpenseResourceFromEntityAssembler.ToResourceFromEntity(expense);
            return Ok(resource);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = "An error occurred while updating the expense. " + e.Message });
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllExpenses()
    {
        var getAllExpensesQuery = new GetAllExpensesQuery();
        var expenses = await expenseQueryService.Handle(getAllExpensesQuery);
        var resources = expenses.Select(ExpenseResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{expenseId}")]
    public async Task<IActionResult> GetExpenseById([FromRoute] int expenseId)
    {
        var expense = await expenseQueryService.Handle(new GetExpenseByIdQuery(expenseId));
        if (expense == null) return NotFound();
        var resource = ExpenseResourceFromEntityAssembler.ToResourceFromEntity(expense);
        return Ok(resource);
    }
}