using System.Text;
using RabbitMQ.Client;

Console.WriteLine("Producer is begining its work...");
var factory = new ConnectionFactory
{
    HostName = "localhost",
    Port = 5672,
    UserName = "guest",
    Password = "guest",
    VirtualHost = "/"
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

var queueName = "demo-queue";
channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

var body = Encoding.UTF8.GetBytes("https://stackoverflow.com/questions/76335193/queues-in-rabbitmq-management-are-not-displayed");

channel.BasicPublish("", queueName, null, body);

Console.WriteLine("The message was sent successfully");
