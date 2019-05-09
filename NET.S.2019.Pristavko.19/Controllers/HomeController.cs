using NET.S._2019.Pristavko._19.DAL;
using NET.S._2019.Pristavko._19.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NET.S._2019.Pristavko._19.Controllers
{
    public class HomeController : Controller
    {
        GalleryContext db = new GalleryContext();

        public ActionResult Index(int page = 1)
        {
            int pageSize = 3; 
            IEnumerable<Photo> phonesPerPages = db.Photos.ToList().Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = db.Photos.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Photos = phonesPerPages };
            return View(ivm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var photo = new Photo();
            return View(photo);
        }

        public Size NewImageSize(Size imageSize, Size newSize)
        {
            Size finalSize;
            double tempval;
            if (imageSize.Height > newSize.Height || imageSize.Width > newSize.Width)
            {
                if (imageSize.Height > imageSize.Width)
                    tempval = newSize.Height / (imageSize.Height * 1.0);
                else
                    tempval = newSize.Width / (imageSize.Width * 1.0);

                finalSize = new Size((int)(tempval * imageSize.Width), (int)(tempval * imageSize.Height));
            }
            else
                finalSize = imageSize; // image is already small size

            return finalSize;
        }

        private void SaveToFolder(Image img, Size newSize, string pathToSave)
        {
            // Get new resolution
            Size imgSize = NewImageSize(img.Size, newSize);
            using (System.Drawing.Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
            {
                newImg.Save(Server.MapPath(pathToSave), img.RawFormat);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Decription")]Photo photo, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid && upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);

                

                using (var img = System.Drawing.Image.FromStream(upload.InputStream))
                {
                    photo.ThumbPath = String.Format("../Gallery/GalleryThumb/" + fileName);
                    photo.ImagePath = String.Format("../Gallery/GalleryImage/" + fileName);

                    // Save thumbnail size image, 100 x 100
                    SaveToFolder(img, new Size(300, 300), photo.ThumbPath);

                    // Save large size image, 800 x 800
                    SaveToFolder(img, new Size(800, 800), photo.ImagePath);
                }

                photo.CreatedOn = DateTime.Now;
                db.Photos.Add(photo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(photo);
        }
    }
}