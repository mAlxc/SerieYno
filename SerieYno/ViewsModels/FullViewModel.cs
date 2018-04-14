using SerieYnoModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerieYno.ViewsModels.SerieViewModels
{
    public class FullViewModel
    {
        public IEnumerable<SerieModel> SerieModel { get; set; }
        public IEnumerable<SaisonModel> SaisonModel { get; set; }
        public IEnumerable<EpisodeModel> EpisodeModel { get; set; }
    }
}
