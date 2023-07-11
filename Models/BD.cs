using System.Data.SqlClient;
using Dapper;

public static class DB
{
    private static string ConnectionString { get; set; } = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";
     public static void AgregarCandidato(Candidato can)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            db.Execute("INSERT INTO Candidato(IdPartido, Nombre, Apellido, Foto, FechaNacimiento, Postulación) VALUES (@IdPartido, @Nombre, @Apellido, @Foto, @FechaNacimiento, @Postulación)", new {IdPartido = can.IdPartido, Nombre = can.Nombre, Apellido = can.Apellido, Foto = can.Foto, FechaNacimiento = can.FechaNacimiento, Postulación = can.Postulación});
        }
    }
    public static void EliminarCandidato(int IdCandidato)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            db.Execute("DELETE FROM Candidato WHERE IdCandidato = @IdCandidato", new {IdCandidato = IdCandidato});
        }
    }
    public static void EliminarPartido(int IdPartido)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            db.Execute("DELETE FROM Partido WHERE IdPartido = @IdPartido", new {IdPartido = IdPartido});
        }
    }
     public static void AgregarPartido(Partido par)
    {
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            db.Execute("INSERT INTO Partido(Nombre, Logo, SitioWeb, FechaFundacion, CantidadDiputados, CantidadSenadores) VALUES (@Nombre, @Logo, @SitioWeb, @FechaFundacion, @CantidadDiputados, @CantidadSenadores)", new {Nombre = par.Nombre, Logo = par.Logo, SitioWeb = par.SitioWeb, FechaFundacion = par.FechaFundacion, CantidadDiputados = par.CantidadDiputados, CantidadSenadores = par.CantidadSenadores});
        }
    }
    public static Partido VerInfoPartido(int IdPartido)
    {
        Partido partido = null;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Partido WHERE IdPartido = @IdPartido";
            partido = db.QueryFirstOrDefault<Partido>(sql, new {IdPartido = IdPartido});
        }
        return partido;
    }
    public static Candidato VerInfoCandidato(int IdCandidato)
    {
        Candidato candidato = null;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE IdCandidato = @IdCandidato";
            candidato = db.QueryFirstOrDefault<Candidato>(sql, new {IdCandidato = IdCandidato});
        }
        return candidato;
    }
    public static List<Partido> ListarPartidos()
    {
        List<Partido> ListaPartidos = new List<Partido>();
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Partido";
            ListaPartidos = db.Query<Partido>(sql).ToList();
        }
        return ListaPartidos;
    }
    public static List<Candidato> ListarCandidatos(int IdPartido)
    {
        List<Candidato> ListaCandidatos = new List<Candidato>(); 
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE IdPartido = @IdPartido";
            ListaCandidatos = db.Query<Candidato>(sql, new {IdPartido = IdPartido}).ToList();
        }
        return ListaCandidatos;
    }

}