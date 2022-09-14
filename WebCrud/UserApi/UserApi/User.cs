using System.ComponentModel.DataAnnotations;

namespace UserApi
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = "Campo precisa conter de 10 a 100 caracteres")]
        [MinLength(10, ErrorMessage = "Campo precisa conter de 10 a 100 caracteres")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = "Campo precisa conter de 10 a 100 caracteres")]
        [MinLength(100, ErrorMessage = "Campo precisa conter de 10 a 100 caracteres")]
        public string? Password { get; set; }

    }
}