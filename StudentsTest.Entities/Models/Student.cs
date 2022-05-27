using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace StudentsTestCore.Entities.Models
{
    [Table("Student")]
    [Index(nameof(Username), IsUnique = true)]
    public partial class Student
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string LastName { get; set; }
        public long Age { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Career { get; set; }
    }
}
