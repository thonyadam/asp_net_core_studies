using AspNetCoreMVC_Study.Data;
using AspNetCoreMVC_Study.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVC_Study.Controllers
{
    public class TipoContratoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TipoContratoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int? id)
        {
            IEnumerable<TipoContrato> objList = _db.TipoContrato.Where(x => x.IdContrato == id);

            return View(objList);
        }

        //Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IEnumerable<TipoContrato> objList)
        {
            bool temDif = false;

            if (ModelState.IsValid)
            {
                IEnumerable<TipoContrato> objListAnt = _db.TipoContrato.Where(x => x.IdContrato == objList.First().IdContrato);
                //IEnumerable<TipoContrato> objListAnt = _db.TipoContrato;
                foreach (var obj in objList)
                {
                    foreach(TipoContrato objAnt in objListAnt)
                    {
                        if (!objAnt.NomeContrato.Equals(obj.NomeContrato) && obj.Id == objAnt.Id)
                        {
                            temDif = true;
                            objAnt.NomeContrato = obj.NomeContrato;
                            _db.TipoContrato.Update(objAnt);
                        }
                    }
                }
                if (temDif)
                {
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                /*_db.Contratos.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");*/
            }

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
        public IActionResult Create(TipoContrato obj)
        {
            _db.TipoContrato.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
