using System;
using System.Collections.Generic;

namespace Mineet.Models;

public partial class MeetingItemHistory
{
    public int ItemHistoryId { get; set; }

    public string ItemName { get; set; } = null!;

    public string ItemDescription { get; set; } = null!;

    public string ItemStatus { get; set; } = null!;

    public string ItemPersonResponsible { get; set; } = null!;

    public int? MeetingId { get; set; }

    public int? ItemId { get; set; }

    public DateOnly ItemMeetingDate { get; set; }

    public virtual MeetingItem? Item { get; set; }

    public virtual Meeting? Meeting { get; set; }
}
