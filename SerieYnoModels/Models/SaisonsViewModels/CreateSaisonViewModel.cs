using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SerieYnoModels.Models.SaisonsViewModels
{
    class CreateSaisonViewModel
    {
        [Required]
        public Guid SerieId { get; set; }

        [Display(Name = "num_saison", ResourceType = typeof(Languages.Resources.Resource))]
        [Required]
        [Range(1, 50)]
        public int? Num_saison { get; set; }
    }
}
