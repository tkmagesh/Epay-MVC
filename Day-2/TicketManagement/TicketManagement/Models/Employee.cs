using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage="No one in the world is without First Name")]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}