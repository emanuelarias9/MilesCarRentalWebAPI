using System.Text.Json.Serialization;

namespace MilesCarRentalWebAPI.Models
{
    public partial class TipoVehiculo
    {
        public TipoVehiculo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int TipoVehiculoId { get; set; }
        public string? TipoVehiculoNombre { get; set; }

        [JsonIgnore]
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
