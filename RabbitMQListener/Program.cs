using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        string queueName = "locationSampleQueue";
        var rabbitMqConnection = factory.CreateConnection();
        var rabbitMqChannel = rabbitMqConnection.CreateModel();

        rabbitMqChannel.QueueDeclare(queue: queueName,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        rabbitMqChannel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

        int messageCount = Convert.ToInt16(rabbitMqChannel.MessageCount(queueName));
        Console.WriteLine(" Listening to the queue. This channels has {0} messages on the queue", messageCount);

        var consumer = new EventingBasicConsumer(rabbitMqChannel);
        consumer.Received += (model, ea) =>
         {
             var body = ea.Body;
             var message = Encoding.UTF8.GetString(body);
             Console.WriteLine(" Location received: " + message);
             rabbitMqChannel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
             Thread.Sleep(1000);
         };
        rabbitMqChannel.BasicConsume(queue: queueName,
                             autoAck: false,
                             consumer: consumer);

        Thread.Sleep(1000 * messageCount);
        Console.WriteLine(" Connection closed, no more messages.");
        Console.ReadLine();
    }
}
