using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Validators;


namespace SerieYnoModels.Models
{

        [Table(name: "AmiModel")]
        public class AmiModel : ModelBase
        {

        [Key]
        [Display(Name = "ID_user1", ResourceType = typeof(Guid))]
        public Guid ID_user1 { get; set; }
        public virtual ApplicationUser Utilisateur1 { get; set; }

        [Key]
        [Display(Name = "ID_user2", ResourceType = typeof(Guid))]
        public Guid ID_user2 { get; set; }
        public virtual ApplicationUser Utilisateur2 { get; set; }

        [Display(Name = "cod_ami", ResourceType = typeof(int))]
        public int Cod_ami { get; set; }

    }
}
