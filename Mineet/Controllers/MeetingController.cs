using Microsoft.AspNetCore.Mvc;
using Mineet.Models;

namespace Mineet.Controllers
{
    public class MeetingController : Controller
    {

        MineetDbContext db = new MineetDbContext();

        public IActionResult MeetingsV()
        {
            var meetings = db.Meetings.ToList();
            return View(meetings);
        }

        public IActionResult MeetingItems(int id)
        {
            var meetingItems = db.MeetingItems.Where(x => x.MeetingId == id).ToList();
            ViewData["MeetingId"] = id;
            return View(meetingItems);
        }

        public IActionResult EditMeetingItem(int id)
        {
            var meetingItem = db.MeetingItems.FirstOrDefault(mi => mi.ItemId == id);
            if (meetingItem == null)
            {
                return NotFound();
            }

            ViewData["MeetingId"] = meetingItem.MeetingId;
            return View(meetingItem);
        }

        [HttpPost]
        public async Task<IActionResult> EditMeetingItem(MeetingItem meetingItem)
        {
            if (ModelState.IsValid)
            {
                var meetingItemHistory = new MeetingItemHistory
                {
                    ItemId = meetingItem.ItemId,
                    MeetingId = meetingItem.MeetingId,
                    ItemName = meetingItem.ItemName,
                    ItemDescription = meetingItem.ItemDescription,
                    ItemStatus = meetingItem.ItemStatus,
                    ItemPersonResponsible = meetingItem.ItemPersonResponsible,
                    ItemMeetingDate = DateOnly.FromDateTime(DateTime.Now)

                };

                db.MeetingItemHistories.Add(meetingItemHistory);

                meetingItem.ItemMeetingDate = DateOnly.FromDateTime(DateTime.Now);
                db.MeetingItems.Update(meetingItem);

                await db.SaveChangesAsync();
                return RedirectToAction("MeetingItems", new { id = meetingItem.MeetingId });
            }

            return View(meetingItem);
        }

        public IActionResult CreateMeetingItem(int id)
        {
            var meetingItem = new MeetingItem { MeetingId = id };
            return View(meetingItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeetingItem(MeetingItem meetingItem)
        {
            if (ModelState.IsValid)
            {
                var date = DateTime.Now;
                meetingItem.ItemMeetingDate = DateOnly.FromDateTime(date);
                db.MeetingItems.Add(meetingItem);
                await db.SaveChangesAsync();

                return RedirectToAction("MeetingItems", new { id = meetingItem.MeetingId });
            }

            return View(meetingItem);
        }

        public IActionResult CreateMeeting(int id)
        {
            var meeting = new Meeting { MeetingId = id };
            return View(meeting);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeeting(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                db.Meetings.Add(meeting);
                await db.SaveChangesAsync();
                return RedirectToAction("MeetingsV");
            }
            return View(meeting);
        }

        public IActionResult ViewItemHistory(int id)
        {
            var itemHistoryList = db.MeetingItemHistories.Where(h => h.ItemId == id).ToList();
            var meetingId = db.MeetingItems.Where(mi => mi.ItemId == id).Select(mi => mi.MeetingId).FirstOrDefault();

            ViewData["MeetingId"] = meetingId;
            return View(itemHistoryList);
        }
    }
}
