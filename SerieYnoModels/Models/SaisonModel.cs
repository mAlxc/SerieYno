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

        public virtual ICollection<EpisodeModel> Episodes { get; set; }

        public Guid SerieId { get; set; }
        public virtual SerieModel Serie {get;set;}

        [Display(Name = "num_saison", ResourceType = typeof(Languages.Resources.Resource))]
        [Required]
        public int? Num_saison { get; set; }
    }
}
