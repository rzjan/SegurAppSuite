using MediatR;

namespace SegurAppSuite.Domain.Events;

public record SiniestroRegistrado(Guid SiniestroId, Guid PolizaId):INotification;
