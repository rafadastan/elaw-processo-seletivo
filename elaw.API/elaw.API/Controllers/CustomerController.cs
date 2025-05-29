using elaw.API.Controllers;
using elaw.Application.DTOs;
using elaw.Application.Interfaces;
using elaw.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("clientes")]
public class ClientesController : ApiControllerBase
{
    private readonly ICustomerApplicationService _app;
    private readonly NotificationContext _notification;
    public ClientesController(
        ICustomerApplicationService app,
        NotificationContext notification)
        : base(notification)
    {
        _app = app;
        _notification = notification;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult> GetAll() =>
        CustomResponse(await _app.GetAllAsync());

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<ActionResult> GetById(Guid id)
    {
        var dto = await _app.GetByIdAsync(id);
        if (dto == null) _notification.AddNotification("NotFound", "Cliente não encontrado.");
        return CustomResponse(dto);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> Create([FromBody] CustomerDto dto)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);
        var created = await _app.AddAsync(dto);
        return CustomResponse(created);
    }

    [HttpPut("{id:guid}")]
    [AllowAnonymous]
    public async Task<ActionResult> Update(Guid id, [FromBody] CustomerDto dto)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);
        
        if (id != dto.Id) _notification.AddNotification("Id", "ID da URL difere do corpo.");
        
        await _app.UpdateAsync(id, dto);
        
        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    [AllowAnonymous]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _app.DeleteAsync(id);
        return CustomResponse();
    }
}
