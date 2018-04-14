using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Validators;


namespace SerieYnoModels.Models
{

        [Table(name: "Serie_suivieModel")]
        public class Serie_suivieModel : ModelBase
        {

        [Display(Name = "ID_serie", ResourceType = typeof(Languages.Resources.Resource))]
        public Guid ID_serie{ get; set; }
        public virtual SerieModel Serie { get; set; }

        [Display(Name = "ID_user", ResourceType = typeof(Languages.Resources.Resource))]
        public Guid ID_user { get; set; }
        public virtual ApplicationUser Utilisateur { get; set; }

        [Display(Name = "cod_suivie", ResourceType = typeof(Languages.Resources.Resource))]
        public int Cod_suivie { get; set; }

    }
}
