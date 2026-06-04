using CurrencyConverterApi.Models;
using System.Text.Json;

namespace CurrencyConverterApi.Services;
public class CurrencyConverterService : ICurrencyConverterService
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<CurrencyConverterService> _logger;
    public CurrencyConverterService(IWebHostEnvironment environment, ILogger<CurrencyConverterService> logger)
    {
        _environment = environment;
        _logger = logger;
    }

    public async Task<ConvertResponse> ConvertAsync(string sourceCurrency, string targetCurrency, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        var source = sourceCurrency.Trim().ToUpperInvariant();
        var target = targetCurrency.Trim().ToUpperInvariant();
        var key = $"{source}_TO_{target}";

        _logger.LogInformation("Converting {Amount} from {Source} to {Target}", amount, source, target);

        var filePath = Path.Combine(_environment.ContentRootPath, "exchangeRate.json");

        string json;
        try
        {
            json = await File.ReadAllTextAsync(filePath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to read exchange rates file");
            throw;
        }

        var rates =
            JsonSerializer.Deserialize<Dictionary<string, decimal>>(json)
            ?? new Dictionary<string, decimal>();

        var envValue = Environment.GetEnvironmentVariable(key);

        decimal exchangeRate;

        if (!string.IsNullOrWhiteSpace(envValue))
        {
            if (!decimal.TryParse(envValue, out exchangeRate))
                throw new Exception($"Invalid environment rate for {key}");
        }
        else if (rates.TryGetValue(key, out var fileRate))
        {
            exchangeRate = fileRate;
        }
        else
        {
            throw new InvalidOperationException($"Currency pair {key} is not supported.");
        }

        var result = amount * exchangeRate;

        _logger.LogInformation("Conversion successful. Rate: {Rate}, Result: {Result}", exchangeRate, result);

        return new ConvertResponse
        {
            ExchangeRate = exchangeRate,
            ConvertedAmount = result
        };
    }
}