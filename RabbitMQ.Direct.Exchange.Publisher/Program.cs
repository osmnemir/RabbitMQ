using RabbitMQ.Client;
using System.Text;
// BAĞLANTI OLUŞTURULDU

ConnectionFactory factory = new();
factory.Uri = new("amqps://pknsmlly:xzc0m_S3BgK79OijioTX8Iz_20ELmS1U@jackal.rmq.cloudamqp.com/pknsmlly");


// BAĞLANTI AKTİF VE KANAL AÇMA

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "direct-exchange-example", type: ExchangeType.Direct);


while (true)
{
    Console.Write("Mesaj: ");
    string message = Console.ReadLine();
    byte[] byteMessage = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(
    exchange: "direct-exchange-example",
    routingKey: "direct-queue-example",
    body: byteMessage);
}
Console.Read() ;