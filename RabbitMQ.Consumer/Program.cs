using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


// BAĞLANTI OLUŞTURULDU

ConnectionFactory factory = new();
factory.Uri = new("amqps://pknsmlly:xzc0m_S3BgK79OijioTX8Iz_20ELmS1U@jackal.rmq.cloudamqp.com/pknsmlly");


// BAĞLANTI AKTİF VE KANAL AÇMA

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();



//QUEUE OLUŞTURMA 
//CONSUMER VE PUBLİSHER'DAKİ KUYRUK BİREBİR TANIMLANMALIDIR.
channel.QueueDeclare(queue: "example-queue", exclusive: false,durable:true);


//QUEUE MESAJ GÖNDERME


EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue: "example-queue", autoAck:false, consumer);
channel.BasicQos(0, 1, false);// mesajlar eşit istekte gitmesi için
consumer.Received += (sender, e) =>
{

    //kuyruğa gelen mesajın işlendiği yer.
    //e.Body :mesajı bütünsel olarak verir.
    //e.Body.Span veya e.Body.ToArray() : kuyruştaki mesajın byte verisini verir.
    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));

    // mesajları siler
    channel.BasicAck(deliveryTag:e.DeliveryTag,multiple:false);
};
Console.Read();