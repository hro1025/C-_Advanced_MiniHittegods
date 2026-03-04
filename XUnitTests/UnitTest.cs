using System.Security.Claims;
using Microsoft.VisualBasic;
using MiniHittegods.Domain.Core;
using Xunit;

namespace XUnitTest;

public class UnitTests
{
    [Fact]
    public void FoundItemAvailable()
    {
        var target = new FoundItem();

        var status = target.Status;

        Assert.Equal(ItemStatus.Available, status);
    }

    [Fact]
    public void FoundItemClaim()
    {
        var target = new FoundItem();

        target.Claim();

        var status = target.Status;

        Assert.Equal(ItemStatus.Claimed, status);
    }

    [Fact]
    public void FoundItemReturn()
    {
        var target = new FoundItem();

        target.Claim();
        target.Return();

        var status = target.Status;

        Assert.Equal(ItemStatus.Returned, status);
    }

    [Fact]
    public void FoundItemDelete()
    {
        var target = new FoundItem();

        target.Delete();

        var status = target.Status;

        Assert.Equal(ItemStatus.Deleted, status);
    }
}
