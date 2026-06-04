using CurrencyConverterApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverterApi.Services
{
    public interface ICurrencyConverterService
    {
        Task<ConvertResponse> ConvertAsync(string sourceCurrency, string targetCurrency, decimal amount);
    }
}
