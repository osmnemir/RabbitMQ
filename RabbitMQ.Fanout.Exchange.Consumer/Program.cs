﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://jvthiwve:DP2b7DOnUrXKFroJOwM0wvu_UWDlIO-_@sparrow.rmq.cloudamqp.com/jvthiwve");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "fanout-exchange-example", type: ExchangeType.Fanout);

Console.WriteLine("Kuyruk adını giriniz: ");
string queueName = Console.ReadLine();

channel.QueueDeclare(queue: queueName, exclusive: false);

channel.QueueBind(queue: queueName, exchange: "fanout-exchange-example", routingKey: string.Empty);

EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

consumer.Received += (sender, e) =>
{
    string message = Encoding.UTF8.GetString(e.Body.Span);
    Console.WriteLine(message);
};

Console.Read();