using MassTransit;
using ReceiverApplication.Services;

namespace ReceiverApplication;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = Host.CreateApplicationBuilder(args);

		builder.Services.AddMassTransit(x =>
		{
			x.AddConsumer<TestMessageConsumer>();
			
			x.UsingRabbitMq((context, cfg) =>
			{
				cfg.ReceiveEndpoint("Queue", e =>
					e.ConfigureConsumer<TestMessageConsumer>(context));
				cfg.ConfigureEndpoints(context);
			});
		});

		var host = builder.Build();
		
		host.Run();
	}
}