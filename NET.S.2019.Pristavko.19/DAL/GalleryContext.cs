using NET.S._2019.Pristavko._19.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NET.S._2019.Pristavko._19.DAL
{
    public class GalleryContext : DbContext
    {
        public GalleryContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<GalleryContext>
                (new DropCreateDatabaseIfModelChanges<GalleryContext>());
        }

        public DbSet<Photo> Photos { get; set; }
    }
}