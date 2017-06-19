using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneCore.Modelo
{

    /// <summary>
    /// Usuarios del sistema.
    /// </summary>
    [Table("Usuarios")]
    public class Usuario
    {
        /// <summary>
        /// Identificador del usuario.
        /// </summary>
        /// <remarks>
        /// Se especifica el campo como identidad (autoincremental).
        /// </remarks>
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioID { get; set; }

        /// <summary>
        /// Nombre o alias de usuario.
        /// </summary>
        /// <remarks>
        /// Se espeficia un índice para agilizar las búsquedas.
        /// </remarks>
        [DisplayName("Nombre:")]
        [Index("IX_UsuariosNombre", IsUnique = true)]
        [MinLength(5, ErrorMessage = "El nombre de usuario debe tener una longitud mínima de 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre de usuario debe tener una longitud máxima de 50 caracteres.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre de usuario requerido.")]
        public string Nombre { get; set; }

        /// <summary>
        /// Contraseña de acceso.
        /// </summary>
        /// <remarks>
        /// Para el ejemplo, la contraseña se almacenará en texto plano. 
        /// Lo recomendable sería guardar el Hash (SHA1-SHA256) de la contraseña. 
        /// Se espeficia un índice para agilizar las búsquedas.
        /// </remarks>
        [DisplayName("Contraseña:")]
        [Index("IX_UsuarioContraseña")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%_!&-]).{6,20})", ErrorMessage = "La contraseña de acceso debe contener almenos una letra mayúscula, un número y un símbolo.")]
        [MinLength(5, ErrorMessage = "La contraseña de acceso debe tener una longitud mínima de 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "La contraseña de acceso debe tener una longitud máxima de 50 caracteres.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contraseña de acceso requerida.")]
        public string Contraseña { get; set; }

        /// <summary>
        /// Dirección de correo electrónico.
        /// </summary>
        /// <remarks>
        /// El decorador EmailAddress valida por si solo el formato del correo electrónico. No hace falta validar mediante expresión regular.
        /// </remarks>
        [DisplayName("Correo:")]
        [MinLength(5, ErrorMessage = "El correo electrónico debe tener una longitud mínima de 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "El correo electrónico debe tener una longitud máxima de 50 caracteres.")]
        [EmailAddress(ErrorMessage = "Correo electrónico inválido.")]
        public string Correo { get; set; }

        /// <summary>
        /// Sexo.
        /// </summary>
        /// <remarks>
        /// Posible representación con un tipo complejo (enumeración).
        /// </remarks>
        [DisplayName("Sexo:")]
        [RegularExpression("[MF]{1}", ErrorMessage = "Establezca el sexo con la letra inicial correspondiente; M o F.")]
        [MinLength(1, ErrorMessage = "El sexo debe espeficiarse con la letra inicial; M o F.")]
        [MaxLength(1, ErrorMessage = "El sexo debe espeficiarse con la letra inicial; M o F.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sexo requerido.")]
        public string Sexo { get; set; }

        /// <summary>
        /// Determina si el usuario está activo en el sistema.
        /// </summary>
        [DisplayName("Activo:")]
        public bool Activo { get; set; }

    }
}
