namespace MilesCarRentalWebAPI.Models
{
    public partial class Vehiculo
    {
        public int VehiculoId { get; set; }
        public string? VehiculoNombre { get; set; }
        public int? TipoVehiculoId { get; set; }
        public decimal? VehiculoPrecio { get; set; }
        public string? LocalidadRecogida { get; set; }
        public string? LocalidadDevolucion { get; set; }

        public virtual TipoVehiculo? TipoVehiculo { get; set; }
    }
}
