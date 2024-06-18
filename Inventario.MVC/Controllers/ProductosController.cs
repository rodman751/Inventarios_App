using AspNetCoreHero.ToastNotification.Abstractions;
using Consume.API;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.MVC.Controllers
{
    public class ProductosController : Controller
    {
        private string urlApi;
        private string urlApi2;
        public INotyfService _notifyService { get; }
        public ProductosController(IConfiguration configuration, INotyfService notyfService)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Productos";
            urlApi2 = configuration.GetValue("ApiUrlBase", "").ToString() + "/DetalleAjuste";

            _notifyService = notyfService;
        }
        // GET: ProductosController
        public ActionResult Index()
        {
            var data = CRUD<Productos>.Read(urlApi);
            return View(data);
        }

        // GET: ProductosController/Details/5
        public ActionResult Details(int id)
        {
            //var data = CRUD<DetalleAjuste>.Read_ById(urlApi2, id);
            return View();
        }

        // GET: ProductosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
