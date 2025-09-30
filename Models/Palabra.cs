namespace TP07_Ahorcado
{
    public class Palabra
    {
        public string texto{get; private set;}
        public int dificultad{get; private set;}

        public Palabra (string texto, int dificultad)
        {
            this.texto = texto;
            this.dificultad = dificultad;
        }
    }
}