using System;
using System.ComponentModel.DataAnnotations;

namespace N5.Challenge.Api.Infraestructure.Entities
{
	public record IEntity
	{
		[Key]
		public int Id { get; set; }
	}
}
