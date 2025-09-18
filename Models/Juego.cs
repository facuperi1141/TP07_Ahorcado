namespace TP07_Ahorcado
{
    public class Juego
    {
        private List<Palabra> palabras;
        private List<Usuario> jugadores;
        Usuario jugadorActual;

        private void llenarListaPalabras()
        {
            palabras = new List<Palabra>{};
        }
    }
}