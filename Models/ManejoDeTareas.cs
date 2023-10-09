namespace EspacioTareas;
using EspacioDatos;
using EspacioTareas;

public class ManejoDeTareas{
    private List<Tarea>? ListaTareas = new List<Tarea>();
    private AccesoADatos? accesoTareas;

    public ManejoDeTareas(){

    }
    public ManejoDeTareas(AccesoADatos accTareas){
        accesoTareas = accTareas;
        if(accesoTareas.Obtener() != null){
            ListaTareas = accesoTareas.Obtener();
        }
    }
    public bool CrearTarea(string titulo, string descrip){
        Tarea tarea = new Tarea(titulo, descrip);
        ListaTareas.Add(tarea);
        tarea.Id = ListaTareas.Count();

        if(accesoTareas.Guardar(ListaTareas)){
            return true;
        } else {
            return false;
        }
    }
    public Tarea? BuscarTarea(int id){
        Tarea? tarea = ListaTareas.FirstOrDefault(tarea => tarea.Id == id);
        return tarea;
    }
    public bool ActualizarTarea(int id, int estado){
        Tarea? tarea = ListaTareas.FirstOrDefault(tarea => tarea.Id == id);
        if(tarea != null){ //id comienza en 1, los indices de la lista en 0
            ListaTareas[id-1].ActualizarTarea(estado);
            
            if(accesoTareas.Guardar(ListaTareas)){
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }
    public bool EliminarTarea(int id){
        Tarea? tarea = BuscarTarea(id);
        if(tarea != null){
            ListaTareas.Remove(tarea);
            tarea = BuscarTarea(id);
            if(tarea == null && accesoTareas.Guardar(ListaTareas)){
                return true;
            }
        } 
        return false;
    }
    public List<Tarea> ListarTareas(){
        return ListaTareas;
    }
    public List<Tarea> TareasCompletas(){
        List<Tarea> tareasCompletas = new();
        foreach(Tarea tarea in ListaTareas){
            if(tarea.Estado == Estados.Compretada){
                tareasCompletas.Add(tarea);
            }
        }
        return tareasCompletas;
    }
}