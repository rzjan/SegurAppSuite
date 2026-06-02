using MediatR;

namespace SegurAppSuite.Domain.Events;

public record PolizaActivada(Guid PolizaId) : INotification;