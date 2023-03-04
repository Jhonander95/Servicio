namespace WSServicio.Models.Request
{
    public class ClienteRequest
    {
        public long Id  { get; set; }
        public string Nombre { get; set; }
        public long Telefono { get; set; }
        public string? Empresa { get; set; }
    }
}
