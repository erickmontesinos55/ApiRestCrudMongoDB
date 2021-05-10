using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CrudAPI.Domain
{
    public class Promocion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public IEnumerable<string> MediosDePago { get; private set; }
        public IEnumerable<string> Bancos { get; private set; }
        public IEnumerable<string> CategoriasProductos { get; private set; }
        public int? MaximaCantidadDeCuotas { get; private set; }
        public decimal? ValorInteresCuotas { get; private set; }
        public decimal? PorcentajeDeDescuento { get; private set; }
        public BsonDateTime? FechaInicio { get;  set; }
        public BsonDateTime? FechaFin { get; private set; }
        public bool Activo { get; private set; }
        public BsonDateTime FechaCreacion { get; private set; }
        public BsonDateTime? FechaModificacion { get; private set; }

        public IList<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
    }
}