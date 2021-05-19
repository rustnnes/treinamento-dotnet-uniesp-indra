namespace Backend {
	public class Veiculo {
		public string Cor { get; set; }

		public virtual string Buzinar() {
			return "Biiii";
		}
	}
}
