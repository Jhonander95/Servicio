using System.ComponentModel.DataAnnotations;

namespace WSServicio.Models.Request
{

    public class AuthRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        //public string Nombre { get; set; }
    }
}
