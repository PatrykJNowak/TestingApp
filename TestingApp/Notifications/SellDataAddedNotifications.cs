using MediatR;
using TestingApp.DataModels;

namespace TestingApp.Notifications
{
    public record SellDataAddedNotifications(SellData SellData) : INotification;
}