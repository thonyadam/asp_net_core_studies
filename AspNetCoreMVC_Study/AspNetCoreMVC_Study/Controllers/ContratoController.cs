using AspNetCoreMVC_Study.Data;
using AspNetCoreMVC_Study.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVC_Study.Controllers
{
    public class ContratoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ContratoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Contrato> objList = _db.Contratos;

            return View(objList);
        }

        //Get - Create
        public IActionResult Create()
        {
            return View();
        }
        //Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contrato obj)
        {

            if (ModelState.IsValid)
            {
                _db.Contratos.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
            
        }

        //Get - Edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Contratos.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contrato obj)
        {

            if (ModelState.IsValid)
            {
                _db.Contratos.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        //Get - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Contratos.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //Post - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Contratos.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Contratos.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
