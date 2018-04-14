using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Validators;


namespace SerieYnoModels.Models
{

        [Table(name: "Episode_VueModel")]
        public class Episode_VueModel : ModelBase
        {
        [Display(Name = "ID_ep", ResourceType = typeof(Languages.Resources.Resource))]
        public Guid ID_ep{ get; set; }
        public virtual EpisodeModel Episode { get; set; }

        [Display(Name = "ID_user", ResourceType = typeof(Languages.Resources.Resource))]
        public Guid ID_user { get; set; }
        public virtual ApplicationUser Utilisateur { get; set; }

        [Display(Name = "cod_vue", ResourceType = typeof(Languages.Resources.Resource))]
        public int Cod_vue { get; set; }

    }
}
