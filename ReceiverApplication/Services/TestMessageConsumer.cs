using MassTransit;
using MessageClassLibrary;

namespace ReceiverApplication.Services;

public class TestMessageConsumer : IConsumer<TestMessage>
{
	public Task Consume(ConsumeContext<TestMessage> context)
	{
		Console.WriteLine("Received Text: " + context.Message.Text);
		return Task.CompletedTask;
	}
}