using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend {
	[Table("countries")]
	public class Pais {
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		public string nome { get; set; }

		public virtual ICollection<Marca> marcas { get; set; }
	}
}
