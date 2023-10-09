namespace EspacioTareas;

public enum Estados{
    Pendiente,
    Proceso,
    Compretada
}
public class Tarea{
    private int id;
    private string titulo;
    private string descripcion;
    private Estados estado;

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public Estados Estado { get => estado; set => estado = value; }

    public Tarea(){
    }
    public Tarea(string titu, string descrip){
        id = 0;
        titulo = titu;
        descripcion = descrip;
        estado = Estados.Pendiente;
    }
    public void ActualizarTarea(int est){
        switch(est){
            case 2:
                estado = Estados.Proceso;
                break;
            case 3:
                estado = Estados.Compretada;
                break;
        }
    }
}