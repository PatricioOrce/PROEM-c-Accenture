namespace StarwarsSite.Models
{
    public class Personaje
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Personaje()
        {
                
        }
        public Personaje(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;   
        }
    }
}
