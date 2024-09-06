namespace Ordering.Application.Dtos;

public record PaymentDto(string CardNamne, string CarNumber, string Expiration, string Cvv, int PaymentMethod);