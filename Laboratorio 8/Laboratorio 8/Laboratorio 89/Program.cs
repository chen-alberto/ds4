using Laboratorio_89;

internal class Program
{
    private static void Main(string[] args)
    {
        Template temp1 = new Template();
        temp1.ponerVariable("var1", "valor 1");
        temp1.ponerVariable("var1", "valor 1");
        temp1.ponerVariable("var1", "valor 1");
        temp1.verHtml("<br>Texto de prueba</b>");
    }
}