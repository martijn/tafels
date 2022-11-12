using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Analytics;

namespace TafelsTests;

public class MockAnalytics : IAnalytics
{
    public async Task Initialize(string trackingId)
    {
    }

    public async Task ConfigureGlobalConfigData(Dictionary<string, object> globalConfigData)
    {
    }

    public async Task ConfigureGlobalEventData(Dictionary<string, object> globalEventData)
    {
    }

    public async Task TrackNavigation(string uri)
    {
    }

    public async Task TrackEvent(string eventName, string eventCategory = null, string eventLabel = null,
        int? eventValue = null)
    {
    }

    public async Task TrackEvent(string eventName, int eventValue, string eventCategory = null,
        string eventLabel = null)
    {
    }

    public async Task TrackEvent(string eventName, object eventData)
    {
    }

    public void Enable()
    {
    }

    public void Disable()
    {
    }
}
