﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SerieYnoModels.Models;
using SerieYnoModels.Models.AccountViewModels;
namespace SerieYno.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SerieYnoModels.Models.SerieModel> Serie { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

        public DbSet<SerieYnoModels.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<SerieYnoModels.Models.EpisodeModel> EpisodeModel { get; set; }
        public DbSet<SerieYnoModels.Models.SaisonModel> SaisonModel { get; set; }
        public DbSet<SerieYnoModels.Models.SerieModel> SerieModel { get; set; }
        public DbSet<SerieYnoModels.Models.Episode_VueModel> Episode_VueModel { get; set; }
        public DbSet<SerieYnoModels.Models.Serie_suivieModel> Serie_suivieModel { get; set; }
    }
}
