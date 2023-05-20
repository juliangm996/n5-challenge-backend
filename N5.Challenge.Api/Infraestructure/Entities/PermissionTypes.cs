using System;
using System.ComponentModel.DataAnnotations;

namespace N5.Challenge.Api.Infraestructure.Entities
{
    public class PermissionTypes
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 4)]
        public string Descripcion { get; set; }

        //Relation tables
        public virtual IEnumerable<Permissions> Permissions { get; set; }
    }
}

