﻿namespace Ordering.Domain.ValueObjects;

public record Address
{
    public string FistName { get; } = default!;
    public string LastName { get; } = default!;
    public string? EmailAddress { get; }
    public string AddressLine { get; } = default!;
    public string Country { get; } = default!;
    public string State { get; } = default!;
    public string ZipCode { get; } = default!;
}
