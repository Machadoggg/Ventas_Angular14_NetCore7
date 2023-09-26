namespace Ventas.API.Utilidad
{
    public class Response<T>
    {
        public bool Ok { get; set; }
        public T Value { get; set; } = default!;
        public string MensajeError { get; set; } = default!;


        public Response()
        {
            Ok = true;
        }
    }
}
