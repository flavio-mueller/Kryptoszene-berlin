using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kryptoszene_berlin.Models;
using reCAPTCHA.MVC;

namespace Kryptoszene_berlin.Controllers
{
    public class CommentsController : Controller
    {
        private CryptoContext db = new CryptoContext();

        // GET: Comments
        public ActionResult Index()
        {
            var model = new CommentViewModel()
            {
                NewComment = new Comment(),
                Comments = db.Comments.ToList().Skip(Math.Max(0, db.Comments.Count() - 15))
            };
            return View(model);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [CaptchaValidator(
            PrivateKey = "6LdnmWoUAAAAAFJEvlRBh_Ur6AD-eutE9TZX_pc7",
            ErrorMessage = "Invalide Captcha Eingabe",
            RequiredMessage = "Dieses Feld ist ein Pflichtfeld")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Message")] Comment comment, bool captchaValid)
        {
            comment.TimeStamp = DateTime.Now;
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(comment.Name) && !string.IsNullOrWhiteSpace(comment.Message))
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("ErrorComment");

        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            return View("ErrorAuth");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TimeStamp,Message")] Comment comment)
        {
            return View("ErrorAuth");

            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            return View("ErrorAuth");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return View("ErrorAuth");
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
