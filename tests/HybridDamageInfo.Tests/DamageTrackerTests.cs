using Xunit;

namespace HybridDamageInfo.Tests;

public class DamageTrackerTests
{
    [Fact]
    public void RemoveSlot_RemovesOwnedAndCrossReferencedState()
    {
        var tracker = new DamageTracker();
        tracker.CacheName(1, "old player");
        tracker.RecordDamage(1, 2, 30, 5, 1, false);

        tracker.RemoveSlot(1);

        Assert.Null(tracker.Get(1));
        Assert.Equal("Unknown", tracker.GetName(1));
        Assert.Empty(tracker.Get(2)!.TakenDamage);
    }

    [Fact]
    public void EncodeHtml_ProtectsCenterHtmlFromPlayerNames()
    {
        Assert.Equal("&lt;b&gt;owned&lt;/b&gt;&amp;", DisplaySafety.EncodeHtml("<b>owned</b>&"));
    }
}
