using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://jvthiwve:DP2b7DOnUrXKFroJOwM0wvu_UWDlIO-_@sparrow.rmq.cloudamqp.com/jvthiwve");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

#region P2P (Point to Point) Yaklaşımı
//string queueName = "p2p-queue-example";

//channel.QueueDeclare(queue: queueName,autoDelete:false,exclusive:false,durable:false);

//byte[] message = Encoding.UTF8.GetBytes("Merhaba");
//channel.BasicPublish(exchange:string.Empty,routingKey:queueName,body:message);

#endregion

#region Publish/Subscribe Yaklaşımı

#endregion

Console.Read();