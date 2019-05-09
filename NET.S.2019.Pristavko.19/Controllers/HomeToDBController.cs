using NET.S._2019.Pristavko._19.DAL;
using NET.S._2019.Pristavko._19.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NET.S._2019.Pristavko._19.Controllers
{
    public class HomeToDBController : Controller
    {
        GalleryToDBContext db = new GalleryToDBContext();

        public ActionResult Index()
        {
            return View(db.PhotosToDB);
        }

        public ActionResult GetImage(int photoId)
        {
            PhotoToDB photo = db.PhotosToDB.FirstOrDefault(p => p.PhotoId == photoId);
            if (photo != null)
            {
                return File(photo.Image, photo.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            var photo = new PhotoToDB();
            return View(photo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name")]PhotoToDB photo, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid && upload != null)
            {
                photo.ImageMimeType = upload.ContentType;
                photo.Image = new byte[upload.ContentLength];
                upload.InputStream.Read(photo.Image, 0, upload.ContentLength);

                db.PhotosToDB.Add(photo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(photo);
        }
    }
}