using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudDevelopmentPART3.Data;
using CloudDevelopmentPART3.Models;

namespace CloudDevelopmentPART3.Controllers
{
    public class EventsController : Controller
    {
        private readonly CloudDevelopmentPART3Context _context;

        public EventsController(CloudDevelopmentPART3Context context)
        {
            _context = context;
        }

        // GET: Events
        //public async Task<IActionResult> Index()
        //{
        //    var cloudDevelopmentPART3Context = _context.Event.Include(@ => @.EventTypeModel);
        //    return View(await cloudDevelopmentPART3Context.ToListAsync());
        //}

        // GET: Events/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var @event = await _context.Event
        //        .Include(@ => @.EventTypeModel)
        //        .FirstOrDefaultAsync(m => m.EventId == id);
        //    if (@event == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(@event);
        //}

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["EventTypeId"] = new SelectList(_context.Set<EventTypeModel>(), "EventTypeId", "EventTypeId");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,EventName,Description,EventDate,EventTypeId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventTypeId"] = new SelectList(_context.Set<EventTypeModel>(), "EventTypeId", "EventTypeId", @event.EventTypeId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["EventTypeId"] = new SelectList(_context.Set<EventTypeModel>(), "EventTypeId", "EventTypeId", @event.EventTypeId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventName,Description,EventDate,EventTypeId")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventTypeId"] = new SelectList(_context.Set<EventTypeModel>(), "EventTypeId", "EventTypeId", @event.EventTypeId);
            return View(@event);
        }

        // GET: Events/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var @event = await _context.Event
        //        .Include(@ => @.EventTypeModel)
        //        .FirstOrDefaultAsync(m => m.EventId == id);
        //    if (@event == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(@event);
        //}

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            if (@event != null)
            {
                _context.Event.Remove(@event);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }
    }
}
