﻿namespace Ordering.Domain.ValuesObjects;

public record OrderName
{
    private const int DefaultLenght = 3;
    public string Value { get; }

    private OrderName(string value) => Value = value;

    public static OrderName Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        //ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLenght);

        return new OrderName(value);
    }
}
