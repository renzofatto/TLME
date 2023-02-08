namespace Dominio
{
    public class Actuacion
    {
        public string Papel { get; set; }
        
        public Reparto Actor { get; set; }

        public int Id { get; set; }
        public override string ToString()
        {
            return $"{this.Actor.Nombre} - {this.Papel}";
        }
    }
}