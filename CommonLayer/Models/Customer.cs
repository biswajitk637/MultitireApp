using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
   public class Customer
    {
        public static object fname;

        public   int Id { get; set; }
        [Required]
        public  string Fname { get; set; }
        [Required]
        public  string Lname { get; set; }
        [Required]
        public  string Email { get; set; }
        [Required]
        public  string Gender { get; set; }
        [Required]
        public  string Mobile { get; set; }
        [Required]
        public  string Address { get; set; }


       

    }
}
