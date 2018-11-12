using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VikingNotes.Models
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }

        [Required, StringLength(128)]
        [Display(Name = "User")]
        public string UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }



        [Required]
        [Display(Name = "Quiz")]
        public int Id { get; set; }

        //[ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }




        [Display(Name = "Create Date")]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Edit Date")]
        public DateTime EditDate { get; set; } = DateTime.UtcNow;




        [Range(0, 9)]
        [Display(Name = "Rank")]
        public decimal Rank { get; set; }
    }
}