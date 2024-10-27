Publisher publisher = new Publisher();

Subscriber subscriber1 = new Subscriber("Subscriber 1");
Subscriber subscriber2 = new Subscriber("Subscriber 2");

// Subscribing to the Publisher's event
publisher.MessagePublished += subscriber1.OnMessageReceived;
publisher.MessagePublished += subscriber2.OnMessageReceived;

// Publishing messages
publisher.PublishMessage("Hello, Subscribers!");
publisher.PublishMessage("Another message for you.");


public class Publisher
{
    public event Action<string> MessagePublished;

    public void PublishMessage(string message)
    {
        Console.WriteLine($"Publisher: Publishing message '{message}'");
        MessagePublished?.Invoke(message); // Notify all subscribers
    }
}

public class Subscriber
{
    private readonly string _name;

    public Subscriber(string name)
    {
        _name = name;
    }

    public void OnMessageReceived(string message)
    {
        Console.WriteLine($"{_name} received message: {message}");
    }
}

