using System.Text;
using RabbitMQ.Client;

public class Publisher 
{
    public void Publish(string message){
         var factory = new ConnectionFactory() { HostName = "localhost",UserName="rabbitmq",Password="rabbitmq"  };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);
        }
    }
}