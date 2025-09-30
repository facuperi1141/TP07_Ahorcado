using System.Linq;
using Newtonsoft.Json;
namespace TP07_Ahorcado
{
    public class Juego
    {
        [JsonProperty]
        private List<Palabra> palabras = new List<Palabra>();
        [JsonProperty]
        private List<Usuario> jugadores = new List<Usuario>();
        [JsonProperty]
        private Usuario jugadorActual;
        public string palabraActual {get; private set;}

        private void llenarListaPalabras()
        {
            palabras = new List<Palabra>{};
            // Dificultad 1 - Palabras fáciles
            palabras.Add(new Palabra("casa", 1));
            palabras.Add(new Palabra("perro", 1));
            palabras.Add(new Palabra("sol", 1));
            palabras.Add(new Palabra("gato", 1));
            palabras.Add(new Palabra("pan", 1));
            palabras.Add(new Palabra("flor", 1));
            palabras.Add(new Palabra("mar", 1));
            palabras.Add(new Palabra("pez", 1));
            palabras.Add(new Palabra("luz", 1));
            palabras.Add(new Palabra("nube", 1));

            // Dificultad 2 - Palabras medias
            palabras.Add(new Palabra("ventana", 2));
            palabras.Add(new Palabra("camino", 2));
            palabras.Add(new Palabra("escuela", 2));
            palabras.Add(new Palabra("jardin", 2));
            palabras.Add(new Palabra("pintura", 2));
            palabras.Add(new Palabra("reloj", 2));
            palabras.Add(new Palabra("cuchara", 2));
            palabras.Add(new Palabra("sombrero", 2));
            palabras.Add(new Palabra("bicicleta", 2));
            palabras.Add(new Palabra("pelota", 2));

            // Dificultad 3 - Palabras difíciles
            palabras.Add(new Palabra("murciélago", 3));
            palabras.Add(new Palabra("escritorio", 3));
            palabras.Add(new Palabra("biblioteca", 3));
            palabras.Add(new Palabra("electricidad", 3));
            palabras.Add(new Palabra("computadora", 3));
            palabras.Add(new Palabra("helicóptero", 3));
            palabras.Add(new Palabra("laboratorio", 3));
            palabras.Add(new Palabra("matemáticas", 3));
            palabras.Add(new Palabra("dificultad", 3));
            palabras.Add(new Palabra("universidad", 3));

            // Dificultad 4 - Muy difíciles o inusuales
            palabras.Add(new Palabra("otorrinolaringólogo", 4));
            palabras.Add(new Palabra("paralelepípedo", 4));
            palabras.Add(new Palabra("electroencefalograma", 4));
            palabras.Add(new Palabra("hipopotomonstrosesquipedaliofobia", 4));
            palabras.Add(new Palabra("desoxirribonucleico", 4));
            palabras.Add(new Palabra("anticonstitucionalmente", 4));
            palabras.Add(new Palabra("esternocleidomastoideo", 4));
            palabras.Add(new Palabra("aerofagia", 4));
            palabras.Add(new Palabra("inconstitucionalidad", 4));
            palabras.Add(new Palabra("transustanciación", 4));
        }
        public void InicializarJuego(string usuario, int dificultad)
        {
            jugadorActual = new Usuario(usuario, 0);
            palabraActual = CargarPalabra(dificultad)
        }
        public string CargarPalabra(int dificultad)
        {
            List<Palabra> palabrasDificultad = new List<Palabra>();
            for (int i = 0; i < palabras.Count(); i++)
            {
                if (palabras[i].dificultad == dificultad)
                palabrasDificultad.Add(palabras[i]);
            }
            Random random = new Random();
            int posicionPalabra = random.Next(palabrasDificultad.Count());
            return palabrasDificultad[posicionPalabra].texto;
        }
        public void Finjuego(int intentos)
        {
            Usuario usuarioFin = new Usuario(jugadorActual.nombre, intentos);
            jugadores.Add(usuarioFin);
        }
        public List<Usuario> DevolverListaUsuarios()
        {
            return jugadores.OrderBy(u => u.cantidadIntentos).ToList();
        }
    }
}