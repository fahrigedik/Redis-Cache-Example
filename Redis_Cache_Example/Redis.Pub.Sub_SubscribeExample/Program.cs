// See https://aka.ms/new-console-template for more information

using StackExchange.Redis;

Console.WriteLine("Hello, World!");

ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync("localhost:6379");

ISubscriber subscriber = redis.GetSubscriber();

await subscriber.SubscribeAsync("messages", (channel, message) =>
{
    Console.WriteLine((string)message);
});


await subscriber.SubscribeAsync("amazon.*", (channel, message) =>
{
    Console.WriteLine((string)message);
});

Console.ReadLine();