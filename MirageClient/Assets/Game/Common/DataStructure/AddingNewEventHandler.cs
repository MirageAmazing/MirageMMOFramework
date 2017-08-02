using System.Security.Permissions;

namespace Mirage.DataStructure
{
    [HostProtection(SharedState = true)]
    public delegate void AddingNewEventHandler(object sender, AddingNewEventArgs e);
}