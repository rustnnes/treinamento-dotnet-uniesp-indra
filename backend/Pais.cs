using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend {
	[Table("Pais")]
	public class Pais {
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Nome { get; set; }

		public virtual ICollection<Marca> Marcas { get; set; }

	}
}
