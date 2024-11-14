using System;
using System.Collections.Generic;

namespace Mineet.Models;

public partial class Meeting
{
    public int MeetingId { get; set; }

    public string MeetingName { get; set; } = null!;

    public string MeetingType { get; set; } = null!;

    public DateOnly MeetingDate { get; set; }

    public virtual ICollection<MeetingItemHistory> MeetingItemHistories { get; set; } = new List<MeetingItemHistory>();

    public virtual ICollection<MeetingItem> MeetingItems { get; set; } = new List<MeetingItem>();
}
