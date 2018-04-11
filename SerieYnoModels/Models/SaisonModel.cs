﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Validators;


namespace SerieYnoModels.Models
{

        [Table(name: "SaisonModel")]
        public class SaisonModel : ModelBase
        {
        [Key]
        [Display(Name = "ID_ep", ResourceType = typeof(Guid))]
        public Guid ID_ep{ get; set; }
        public virtual EpisodeModel Ep { get; set; }
        [ForeignKey("ID_saison")]

        [Display(Name = "num_saison", ResourceType = typeof(int))]
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(int))]
        [StringLength(100, ErrorMessage = "La série doit au minimum avoir 1 saison.")]
        public int Num_saison { get; set; }

    }
}