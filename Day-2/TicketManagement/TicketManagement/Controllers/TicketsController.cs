using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManagement.Models;

namespace TicketManagement.Controllers
{
    public class TicketsController : Controller
    {
        private static TicketList ticketList = new TicketList();

        public ActionResult Index() {
            return View(ticketList);
        }

        [HttpGet]
        public ActionResult New() {
            var newTicket = new Ticket() { 
                Title = "[New Ticket Title]", 
                Description = "[Some information about the ticket]",
                Type = TicketType.Salary
            };
            return View(newTicket);
        }

        [HttpPost]
        public ActionResult New(Ticket ticket, int type)
        {
            ticket.Type = TicketType.GetByKey(type);
            ticketList.Add(ticket);
            return RedirectToAction("Index");
        }
    }

    
}