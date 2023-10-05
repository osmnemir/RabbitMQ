using MassTransit;
using RabbitMQ.ESB.Mass.Transit.Consumer.Consumers;

string rabbitMQUri = "amqps://pknsmlly:xzc0m_S3BgK79OijioTX8Iz_20ELmS1U@jackal.rmq.cloudamqp.com/pknsmlly";

string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);
    factory.ReceiveEndpoint(queueName, endpoint =>
    {
        endpoint.Consumer<ExampleMessageConsumer>();
    });
});


await  bus.StartAsync();

Console.Read();