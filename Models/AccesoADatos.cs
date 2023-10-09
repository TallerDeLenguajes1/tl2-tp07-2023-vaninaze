namespace EspacioDatos;

using System.Text.Json;
using EspacioTareas;

public class AccesoADatos{
    public List<Tarea>? Obtener(){
        string fileName = "Tareas.json";
        if(new FileInfo(fileName).Length == 0){ //archivo vacio
            return null;
        } else {
            string jsonString = File.ReadAllText(fileName);
            List<Tarea>? listaTareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString);
            return listaTareas;
        }
    }
    public bool Guardar(List<Tarea> ListaTareas){
        string fileName = "Tareas.json";
        string jsonString = JsonSerializer.Serialize(ListaTareas);
        File.WriteAllText(fileName, jsonString);
        if(jsonString != null){
            return true;
        } else {
            return false;
        }
    }
}