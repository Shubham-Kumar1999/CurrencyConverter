using CurrencyConverterApi.Models;
using CurrencyConverterApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverterApi.Controllers;

[ApiController]
[Route("")]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyConverterService _currencyConverterService;
    private ILogger<CurrencyController> _logger;
    public CurrencyController(
        ICurrencyConverterService currencyConverterService, ILogger<CurrencyController> logger)
    {
        _currencyConverterService = currencyConverterService;
        _logger = logger;
    }

    [HttpGet("convert")]
    public async Task<ConvertResponse> Convert(string sourceCurrency, string targetCurrency, decimal amount)
    {
        _logger.LogInformation("Convert endpoint called");
         return await _currencyConverterService.ConvertAsync(sourceCurrency, targetCurrency, amount);
        
    }
}