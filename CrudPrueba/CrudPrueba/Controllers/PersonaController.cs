using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudPrueba.Models;
using CrudPrueba.Models.ViewModel;

namespace CrudPrueba.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            List<ListaPersonaViewModel> lst;
            using (PersonaBDEntities db = new PersonaBDEntities())
            {
                lst = (from d in db.persona
                       select new ListaPersonaViewModel
                       {
                           id = d.id,
                           Nombre = d.Nombre,
                           Apellido = d.Apellido,
                           Edad = d.Edad
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(PersonaVeiwModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (PersonaBDEntities db = new PersonaBDEntities())
                    {
                        var oTabla = new persona();
                        oTabla.Nombre = model.Nombre;
                        oTabla.Apellido = model.Apellido;
                        oTabla.Edad = model.Edad;

                        db.persona.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Persona/");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        public ActionResult Editar(int id)
        {
            PersonaVeiwModel model = new PersonaVeiwModel();
            using (PersonaBDEntities db = new PersonaBDEntities())
            {
                var oTabla = db.persona.Find(id);
                model.Nombre = oTabla.Nombre;
                model.Apellido = oTabla.Apellido;
                model.Edad = oTabla.Edad;
                model.id = oTabla.id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(PersonaVeiwModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (PersonaBDEntities db = new PersonaBDEntities())
                    {
                        var oTabla = db.persona.Find(model.id);
                        oTabla.Nombre = model.Nombre;
                        oTabla.Apellido = model.Apellido;
                        oTabla.Edad = model.Edad;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Persona/");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            
            using (PersonaBDEntities db = new PersonaBDEntities())
            {
                var oTabla = db.persona.Find(id);
                db.persona.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Persona/");
        }
    }
}