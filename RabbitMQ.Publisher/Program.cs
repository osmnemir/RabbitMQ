using RabbitMQ.Client;
using System.Text;
// BAĞLANTI OLUŞTURULDU

ConnectionFactory factory = new();
factory.Uri = new("amqps://pknsmlly:xzc0m_S3BgK79OijioTX8Iz_20ELmS1U@jackal.rmq.cloudamqp.com/pknsmlly");


// BAĞLANTI AKTİF VE KANAL AÇMA

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();


//QUEUE OLUŞTURMA // Özel olmayan kuyruk false

channel.QueueDeclare(queue: "example-queue", exclusive: false, durable: true);


//QUEUE MESAJ GÖNDERME
// RABBİTMQ KUYRUĞA TACAĞI MESAJILARI BYTE TÜRÜNDEN KABUL EDER.BYTE DÖNÜŞME YAPCAĞIZ.

//byte[] message = Encoding.UTF8.GetBytes("Hello");
//channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message);

IBasicProperties properties = channel.CreateBasicProperties();
properties.Persistent = true;

for (int i = 0; i < 100; i++)
{
    await Task.Delay(200);
    byte[] message = Encoding.UTF8.GetBytes("Hello" + i);
    channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message, basicProperties: properties);

}

Console.Read();

