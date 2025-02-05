// See https://aka.ms/new-console-template for more information

using StackExchange.Redis;

Console.WriteLine("Hello, World!");

ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync("localhost:6379");

ISubscriber subscriber = redis.GetSubscriber();


while (true)
{
    //await subscriber.PublishAsync("messages", "hello, world!");
    await subscriber.PublishAsync("amazon.elma", "Amazon Pattern :");
}

