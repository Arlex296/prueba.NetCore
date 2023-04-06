using Microsoft.AspNetCore.Mvc;
using System.Threading;
using to_do_list.Models;

namespace to_do_list.Controllers
{
    public class TareasController : Controller
    {
        // se creo una lista de tipo TareaViewModel para ingresar los registros que se utilizan en el crud
        private static List<TareaViewModel> _tarea = new List<TareaViewModel>
        {
           /// tarea quemada de prueba
            new TareaViewModel{ id = 1, descripcion= "tarea de prueba", fechaCreacion= DateTime.Today.AddDays(-3) , completada= false },
        
        };

        // •	Mostrar la lista de tareas pendientes (incluir tanto las completadas como las no completadas). 
       // se creo la opcion de inicio para listar y mostrar todos regisros  donde tambien se cre el filtro de texto
        [HttpGet("~/tareas")]
        public IActionResult Index(string filtro)
        {            
            var filtroTexto = filtro?.ToLower();          
            var items = _tarea
                .Where(i => filtroTexto == null || i.descripcion.ToLower().Contains(filtroTexto)).ToList();           
            return View(items);
            
        }

       
       // •	Agregar una nueva tarea a la lista de tareas pendientes. 
       // se creo las  acciones de crear tarea para crea nuevos registros 
        public IActionResult CrearTarea()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearTarea(TareaViewModel tarea)
        {
            
            _tarea.Add(tarea);
            return RedirectToAction(nameof(Index));
        }

        // •	Editar una tarea existente, permitiendo modificar la descripción 
        // se creo las acciones de editar para editar los registros por el id, modificando solamente la descripcion
        public IActionResult EditarTarea(int id)
        {
            var tarea = _tarea.FirstOrDefault(p => p.id == id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        [HttpPost]
        public IActionResult EditarTarea(int id, TareaViewModel tarea)
        {
            if (id != tarea.id)
            {
                return NotFound();
            }
            var existeTarea = _tarea.FirstOrDefault(p => p.id == id);
            if (existeTarea == null)
            {
                return NotFound();
            }
            existeTarea.descripcion = tarea.descripcion;
           
            return RedirectToAction(nameof(Index));
        }

        //•	Eliminar una tarea de la lista utilizando su Id.
        // se crean las acciones de  eliminar  los resgistros por id 
        public IActionResult EliminarTarea(int id)
        {
            var tarea = _tarea.FirstOrDefault(p => p.id == id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var tarea = _tarea.FirstOrDefault(p => p.id == id);
            if (tarea == null)
            {
                return NotFound();
            }
            _tarea.Remove(tarea);
            return RedirectToAction(nameof(Index));
        }


        // •	Marcar tarea como completada.
        // se crean las acciones de completar para cambiar de estado los registros  a completado obteniendolos por id 
        public IActionResult CompletarTarea(int id)
        {
            var tarea = _tarea.FirstOrDefault(p => p.id == id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        [HttpPost]
        public IActionResult completar(TareaViewModel tarea, int id)
        {
            if (id != tarea.id)
            {
                return NotFound();
            }
            var existeTarea = _tarea.FirstOrDefault(p => p.id == id);
            if (existeTarea == null)
            {
                return NotFound();
            }
            existeTarea.completada = true;

            return RedirectToAction(nameof(Index));
        }
    }
}



