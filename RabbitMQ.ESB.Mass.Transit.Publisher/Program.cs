using MassTransit;
using RabbitMQ.ESB.Mass.Transit.Shared.Messages;

string rabbitMQUri = "amqps://pknsmlly:xzc0m_S3BgK79OijioTX8Iz_20ELmS1U@jackal.rmq.cloudamqp.com/pknsmlly";

string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);
});

ISendEndpoint sendEndpoint = await bus.GetSendEndpoint(new($"{rabbitMQUri}/{queueName}"));

Console.Write("Gönderilecek Mesaj: ");
string messagee=Console.ReadLine();
await sendEndpoint.Send<IMessage>(new ExampleMessage(){
    Text = messagee
});
Console.Read();