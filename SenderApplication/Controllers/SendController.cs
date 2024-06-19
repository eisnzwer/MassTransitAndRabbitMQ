using MassTransit;
using MessageClassLibrary;
using Microsoft.AspNetCore.Mvc;

namespace SenderApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
	private readonly IBus _bus;

	public MessageController(IBus bus)
	{
		_bus = bus;
	}
	
	[HttpPost]
	public async Task<IActionResult> SendMessage(TestMessage message)
	{
		await _bus.Publish(message);
		return Ok();
	}
}