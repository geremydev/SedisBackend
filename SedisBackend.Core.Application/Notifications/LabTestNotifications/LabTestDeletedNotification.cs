using MediatR;

namespace SedisBackend.Core.Application.Notifications.LabTestNotifications;

public sealed record LabTestDeletedNotification(Guid Id, bool TrackChanges) : INotification;
