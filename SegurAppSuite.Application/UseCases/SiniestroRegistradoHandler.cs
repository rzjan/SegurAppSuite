using MediatR;
using SegurAppSuite.Domain.Events;

namespace SegurAppSuite.Application.UseCases.EventHandlers;

public class SiniestroRegistradoHandler:INotificationHandler<SiniestroRegistrado>
{
    public Task Handle(SiniestroRegistrado notification, CancellationToken cancellation)
    {
        Console.WriteLine($"Evento recibido: Siniestro {notification.SiniestroId} en Póliza {notification.PolizaId}");
        // Aquí se puede publicar en RabbitMQ, enviar email, etc.
        return Task.CompletedTask;
    }
}
