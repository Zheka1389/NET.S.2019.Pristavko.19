using NET.S._2019.Pristavko._19.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NET.S._2019.Pristavko._19.DAL
{
    public class GalleryToDBContext : DbContext
    {
        public GalleryToDBContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<GalleryToDBContext>
                (new DropCreateDatabaseIfModelChanges<GalleryToDBContext>());
        }
        public DbSet<PhotoToDB> PhotosToDB { get; set; }
    }
}