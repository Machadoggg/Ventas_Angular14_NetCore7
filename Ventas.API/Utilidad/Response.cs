namespace Ventas.API.Utilidad
{
    public class Response<T>
    {
        public bool Ok { get; set; }
        public T? Value { get; set; }
        public string? MensajeError { get; set; }


        public Response()
        {
            Ok = true;
        }
    }
}
