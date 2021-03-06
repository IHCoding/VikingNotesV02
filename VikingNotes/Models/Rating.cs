﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VikingNotes.Models
{
    public class Rating
    {
        [Key] [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }

        [Required, StringLength(128)] [Display(Name = "User")]
        public string UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required] [Display(Name = "Quiz")]
        public int Id { get; set; } // Quiz id

        //[ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }

        [Range(0, 5)] [Display(Name = "Rank")]
        public decimal Rank { get; set; }
    }
}



//[Display(Name = "Create Date")]
//[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
//public DateTime CreateDate { get; set; }

//[Display(Name = "Edit Date")]
//public DateTime EditDate { get; set; } = DateTime.UtcNow;