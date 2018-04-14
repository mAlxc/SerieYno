using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Validators;


namespace SerieYnoModels.Models
{

        [Table(name: "EpisodeModel")]
        public class EpisodeModel : ModelBase
        {
        [Display(Name = "num_ep", ResourceType = typeof(Languages.Resources.Resource))]
        [Required]
        public int Num_ep { get; set; }

        [Display(Name = "name_ep", ResourceType = typeof(Languages.Resources.Resource))]
        public string Name_ep { get; set; }

        [Display(Name = "description", ResourceType = typeof(Languages.Resources.Resource))]
        public string Description { get; set; }

        public Guid SaisonId { get; set; }
        public virtual SerieModel Saison { get; set; }
    }
}
