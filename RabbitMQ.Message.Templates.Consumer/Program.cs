using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://jvthiwve:DP2b7DOnUrXKFroJOwM0wvu_UWDlIO-_@sparrow.rmq.cloudamqp.com/jvthiwve");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

#region P2P (Point to Point) Yaklaşımı
//string queueName = "p2p-queue-example";

//channel.QueueDeclare(queue: queueName, autoDelete: false, exclusive: false, durable: false);

//EventingBasicConsumer consumer = new (channel);
//channel.BasicConsume(queue: queueName, autoAck:false, consumer:consumer);

//consumer.Received += (sender, e) =>
//{
//    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
//};

#endregion