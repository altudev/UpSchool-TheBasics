using CrawlerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        services.AddSingleton<HttpClient>(new HttpClient(){BaseAddress = new Uri("https://localhost:7109/api/") });
    })
    .Build();

host.Run();
