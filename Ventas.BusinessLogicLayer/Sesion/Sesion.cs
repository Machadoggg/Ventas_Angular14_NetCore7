namespace Ventas.BusinessLogicLayer.Sesion
{
    public class Sesion
    {
        public int IdUsuario { get; set; }

        public string NombreCompleto { get; set; } = default!;

        public string Correo { get; set; } = default!;

        public string RolDescripcion { get; set; } = default!;
    }
}
