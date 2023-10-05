using EasyNetQ.Management.Client.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection;
using System.Text;
// BAĞLANTI OLUŞTURULDU

ConnectionFactory factory = new();
factory.Uri = new("amqps://pknsmlly:xzc0m_S3BgK79OijioTX8Iz_20ELmS1U@jackal.rmq.cloudamqp.com/pknsmlly");


// BAĞLANTI AKTİF VE KANAL AÇMA

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

//1.adım
channel.ExchangeDeclare(exchange: "direct-exchange-example", type: ExchangeType.Direct);
//2.adım
string queueName = channel.QueueDeclare().QueueName;
//3.adım
channel.QueueBind(
queue: queueName,
exchange: "direct-exchange-example",
    routingKey: "direct-queue-example");

EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(
queue: queueName,
autoAck: true,
consumer: consumer) ;


consumer.Received += (sender, e) =>
{
    string message= Encoding.UTF8.GetString(e.Body.Span);
    
Console.WriteLine (message);
};
Console.Read();