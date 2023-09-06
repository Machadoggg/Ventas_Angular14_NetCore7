namespace Ventas.API.Controllers.Usuarios
{
    public class LoginDTO
    {
        public string Correo { get; set; } = default!;

        public string Clave { get; set; } = default!;
    }
}
