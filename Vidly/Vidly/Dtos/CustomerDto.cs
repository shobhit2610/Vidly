﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedTo { get; set; }

        [Required]
//      [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }
    }
}