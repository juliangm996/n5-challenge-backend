using Nest;
using System;
using System.ComponentModel.DataAnnotations;

namespace N5.Challenge.Api.Entities
{
    public record PermissionTypes : IEntity
    {

        [StringLength(80, MinimumLength = 4)]
        public string? Descripcion { get; init; }

        //Relation tables
        public virtual ICollection<Permissions>? Permissions { get; init; }

        [Text(Analyzer = "spanish")]
        public string? DescripcionElasticsearch { get; set; }
    }
}

