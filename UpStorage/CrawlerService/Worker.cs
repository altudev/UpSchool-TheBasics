using System.Net.Http.Headers;
using System.Net.Http.Json;
using Application.Common.Models.WorkerService;
using Application.Features.Accounts.Queries.GetById;
using Microsoft.AspNetCore.SignalR.Client;

namespace CrawlerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly HubConnection _connection;
        private readonly HttpClient _httpClient;

        public Worker(ILogger<Worker> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;

            _connection = new HubConnectionBuilder()
                .WithUrl($"https://localhost:7109/Hubs/AccountHub")
                .WithAutomaticReconnect()
                .Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _connection.On<WorkerServiceNewAccountAddedDto>("NewAccountAdded", async (newAccountAddedDto) =>
            {
                Console.WriteLine($"A new account added. Account Name is {newAccountAddedDto.Account.Title}");
                Console.WriteLine($"Our access token is {newAccountAddedDto.AccessToken}");

                // Crawler.StartAsync(order)

                await Task.Delay(10000,stoppingToken);

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newAccountAddedDto.AccessToken);

                var result = await _httpClient.PostAsJsonAsync("Accounts/CrawlerServiceExample", newAccountAddedDto,stoppingToken);

            });

            await _connection.StartAsync(stoppingToken);

            Console.WriteLine(_connection.State.ToString());
            Console.WriteLine(_connection.ConnectionId);

            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //await Task.Delay(1000, stoppingToken);
            }
        }
    }
}