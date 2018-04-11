using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Validators;


namespace SerieYnoModels.Models
{

    [Table(name: "SerieModel")]
    public class SerieModel : ModelBase
    {

        [Display(Name = "name_serie", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        [StringLength(50, ErrorMessage = "Le nom de la série doit contenir {1} caractères maximum.")]
        public string Name_serie { get; set; }

        [Display(Name = "description", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        [StringLength(1024, ErrorMessage = "La description de la série doit contenir {1} caractères maximum.")]
        public string Description { get; set; }

        [Display(Name = "photo_serie", ResourceType = typeof(Languages.Resources.Resource))]
        public string Photo_serie { get; set; }

        [Display(Name = "num_max_ep", ResourceType = typeof(int))]
        public int Num_max_ep { get; set; }

        [Display(Name = "num_max_saison", ResourceType = typeof(int))]
        public int Num_max_saison { get; set; }

        [Key]
        [Display(Name = "ID_ep", ResourceType = typeof(Guid))]
        public Guid ID_ep { get; set; }
        public virtual EpisodeModel Ep { get; set; }
        [ForeignKey("ID_ep")]
        
        [Key]
        [Display(Name = "ID_saison", ResourceType = typeof(Guid))]
        public Guid ID_saison { get; set; }
        public virtual SaisonModel Saison { get; set; }
        [ForeignKey("ID_saison")]
        
    }
}
