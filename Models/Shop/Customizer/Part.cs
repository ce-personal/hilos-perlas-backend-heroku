using Microsoft.OpenApi.Attributes;
using Nothing.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nothing.Models.Shop.Customizer
{
    public class Part
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public StepPart StepPart { get; set; }

        public Guid FileMainId { get; set; }
        public Guid FileSecondaryId { get; set; }



        [NotMapped]
        public Shared.File? FileMain { get; set; }
        [NotMapped]
        public Shared.File? FileSecondary { get; set; }

    }



    public enum StepPart
    {
        [Display(name: "Seleccione un hilo")]
        Hilo,
        [Display(name: "Seleccione las perlas")]
        Perlas,
        [Display(name: "Seleccione la decoración")]
        Decoracion
    }

}
