using Microsoft.AspNetCore.Mvc;
using EspacioTareas;
using EspacioDatos;

namespace tl2_tp07_2023_vaninaze.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{
    private ManejoDeTareas manejoTareas;
    private readonly ILogger<TareasController> _logger;
    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
        AccesoADatos accesoTareas = new();
        manejoTareas = new ManejoDeTareas(accesoTareas);
    }
    
    [HttpPut("CrearTarea")]
    public ActionResult<bool> CrearTarea(string titulo, string descrip){
        bool resultado = manejoTareas.CrearTarea(titulo, descrip);
        return resultado;
    }
    

    [HttpGet("GetTarea")]
    public ActionResult<Tarea> GetTarea(int idTarea){
        Tarea? tarea = manejoTareas.BuscarTarea(idTarea);
        return Ok(tarea);
    }

//modifica el estado
    [HttpPost("ActualizarTarea")]
    public ActionResult<Tarea> ActualizarTarea(int id, int estado){
        bool resultado = manejoTareas.ActualizarTarea(id, estado);
        Tarea tarea = manejoTareas.BuscarTarea(id);
        if(resultado){
            return Ok(tarea);
        } else {
            return BadRequest(tarea);
        }
    }

    [HttpDelete("EliminarTarea")]
    public ActionResult<bool> EliminarTarea(int id){
        bool resultado = manejoTareas.EliminarTarea(id);
        return resultado;
    }
    [HttpGet("ListarTareas")]
    public ActionResult<List<Tarea>> ListarTareas(){
        return (manejoTareas.ListarTareas());
    }
    [HttpGet("TareasCompletas")]
    public ActionResult<List<Tarea>> TareasCompletas(){
        return manejoTareas.TareasCompletas();
    }
}