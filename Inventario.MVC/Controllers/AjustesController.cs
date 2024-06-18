using AspNetCoreHero.ToastNotification.Abstractions;
using Consume.API;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventario.MVC.Controllers
{
    public class AjustesController : Controller
    {
        private string urlApi;
        private string urlApi2;
        public INotyfService _notifyService { get; }
        public AjustesController(IConfiguration configuration, INotyfService notyfService)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Productos";
            urlApi2 = configuration.GetValue("ApiUrlBase", "").ToString() + "/Ajuste";

            _notifyService = notyfService;
        }
  
        public ActionResult Index()
        {
           
            var data = CRUD<Productos>.Read(urlApi);
            var lista = data.ToList();
            ViewBag.Productos = new SelectList(lista, "Id", "nombre_producto");
            return View();
        }
        public ActionResult ProbyId(int id)
        {

            var data = CRUD<Productos>.Read_ById(urlApi, id);
            return Json(data);
        }

        public ActionResult _ViewData(int id)
        {

            
            return View();
        }


        [HttpPost]
        public ActionResult ActualizarProducto(int id, Productos prod)
        {
            var data = CRUD<Productos>.Update(urlApi, id, prod);

            return RedirectToAction("_ViewData", "Ajustes");
        }

        
        [HttpPost]
        public ActionResult CrearAjuste( Ajustes ajus)
        {
            //ajus.Productos = CRUD<Productos>.Read_ById(urlApi, ajus.producto_id);
            var ajuste = CRUD<Ajustes>.Created(urlApi2, ajus);
            return RedirectToAction("Index", "Productos");
        }

  
    }
}
