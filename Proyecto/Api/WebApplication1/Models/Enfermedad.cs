public class Enfermedad
{
    string Nombre;
    int IdEnfermedad;
    public Enfermedad(string Nombre, int IdEnfermedad)
    {
        this.Nombre = Nombre;
        this.IdEnfermedad = IdEnfermedad;
    }

    public int idEnfermedad
    {
        get { return IdEnfermedad; }
        set { IdEnfermedad = value; }
    }

    public string nombre
    {
        get { return Nombre; }
        set { Nombre = value; }
    }
}