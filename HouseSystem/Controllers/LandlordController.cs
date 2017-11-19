﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HouseSystem.Models;
using HouseSystem.DAL;
using System.Collections;

namespace HouseSystem.Controllers
{
    public class LandlordController : Controller
    {
        private HouseContext db = new HouseContext();
        private LandlordDAO landlordDAO = new LandlordDAO();
        private AdvertisementDAO advertisementDAO = new AdvertisementDAO();

        // GET: Landlord
        public ActionResult Index()
        {
            if (HttpContext.Session["ID"] != null && !HttpContext.Session["ID"].ToString().Equals(""))
            {
                Landlord landlord = db.Landlords.Find((int)HttpContext.Session["ID"]);
                return View("index", landlord.Advertisements);
            }
            else
            {
                TempData["Message"] = "please login in again!";
                return RedirectToAction("Login", "Login");
            }
        }

        //To add detail Page
        public ActionResult Create() {
            if (HttpContext.Session["ID"] == null && HttpContext.Session["ID"].ToString().Equals("")) {
                return RedirectToAction("Login", "Login");
            }
            return View("Create");
        }

        //add data to database
        public ActionResult Add(Advertisement advertisement)
        {
            if (HttpContext.Session["ID"] != null && !HttpContext.Session["ID"].ToString().Equals(""))
            {
                Landlord landlord = db.Landlords.Find((int)HttpContext.Session["ID"]);
                return View();
            }
            else
            {
                TempData["Message"] = "please login in again!";
                return RedirectToAction("Login", "Login");
            }

        }
        // GET: Landlord/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        //// GET: Landlord/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

       
        public ActionResult CreateToDatabase(string description,string title,string address)
        {
            if (HttpContext.Session["ID"] != null && !HttpContext.Session["ID"].ToString().Equals(""))
            {
                    //????must set both of two????
                    Landlord landlord = db.Landlords.Find((int)HttpContext.Session["ID"]);
                //NULL?????
                    Advertisement advertisement = new Advertisement();
                advertisement.Description=description;
                advertisement.Title = title;
                advertisement.address = address;
               // System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files﻿;
                HttpRequest request = System.Web.HttpContext.Current.Request;
                HttpFileCollection files = request.Files;
                int s = 3;
                if (files.Count > 0)
                {
                    for(int i=0;i<files.Count;i++)
                    {
                        HttpPostedFile FileSave = files[i];  //用key获取单个文件对象HttpPostedFile
                        
                        if (FileSave != null && FileSave.FileName.Length>0)
                        {
                            Image im = new Image
                            {
                                AdvertisementID = landlord.ID,
                                ImageData = new byte[FileSave.ContentLength],
                                ImageMimeType = FileSave.ContentType,
                                Description = Request.Form[s]
                            };
                            FileSave.InputStream.Read(im.ImageData, 0, im.ImageData.Length);
                            if (advertisement.Images == null)
                            {
                                List<Image> imgs = new List<Image>();
                                imgs.Add(im);
                                advertisement.Images = imgs;
                            }
                            else
                            {
                                advertisement.Images.Add(im);
                            }
                        }
                        s++;
                    }
                }


                if (landlord.Advertisements == null)
                {
                    List<Advertisement> advs = new List<Advertisement>();
                    advs.Add(advertisement);
                    landlord.Advertisements = advs;
                }
                else
                {
                    landlord.Advertisements.Add(advertisement);
                }
                db.Entry(landlord).State = EntityState.Modified;
                    db.SaveChanges();
                    //advertisement.LandlordID = landlord.ID;
                    ViewBag.messages = "Submit succefully!";
                    return RedirectToAction("Index", "Landlord");
            }
            else
            {
                ViewBag.message = "please login in again!";
                return RedirectToAction("Login", "Login");
            }           
        }

        // GET: Landlord/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // POST: Landlord/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Image,Description")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                Landlord landlord = db.Landlords.Find((int)HttpContext.Session["ID"]);
                //NULL?????
                Advertisement advertisementOld = db.Advertisements.Find(advertisement.ID);
                advertisementOld.Pass = 0;
                //advertisementOld.Image = advertisement.Image;
                advertisementOld.Description = advertisement.Description;
                db.Entry(landlord).State = EntityState.Modified;
                db.SaveChanges();
                //advertisement.LandlordID = landlord.ID;
                ViewBag.message = "Change is applied!";
                return RedirectToAction("Index", "Landlord");
            }
            return View(advertisement);
        }

        ////delete single image
        //public ActionResult DeleteImage(int id) {

        //}

        // GET: Landlord/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // POST: Landlord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertisement advertisement = db.Advertisements.Find(id);
            db.Advertisements.Remove(advertisement);
            db.SaveChanges();
            ViewBag.message = "Delete successfully!";
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
