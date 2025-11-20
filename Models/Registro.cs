using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2DDA.Models
{
    public class Registro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Huella {get; set;}
        [Required]
        public double Peso {get; set;}
        [Required]
        public string Tipo {get; set;}

        public DateTime IngresoRegistro {get; set;}

        public Registro(string huella, double peso, string tipo, DateTime ingresoRegistro)
        {
            Huella = huella;
            Peso = peso;
            Tipo = tipo;
            IngresoRegistro = ingresoRegistro;
        }
    }
}