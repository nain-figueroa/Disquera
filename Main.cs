using System.Diagnostics.Metrics;

public class Main
{
    private Disquera disquera;
    private Disco disco;

    public Main()
    {
        this.disquera = new Disquera();
        this.disco = new Disco();
    }
    public void Menu()
    {
        Int32 op = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("MENU\n(1)Agregar Disco\n(2)Eliminar Disco\n(3)Eliminar\n(0)Salir");
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    while (true)
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Para salir teclee 'enter'");
                            Console.WriteLine("Nombre del disco: ");
                            this.disco.sNombreDisco = Console.ReadLine();

                            if (this.disco.sNombreDisco == "enter") break;

                            Console.WriteLine("Cantidad de canciones: ");
                            this.disco.nCantidadCanciones = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Precio: ");
                            this.disco.dPrecio = Double.Parse(Console.ReadLine());
                            this.disco.doFechaCompra = DateTime.Today;
                            this.disquera.AgregarDisco(this.disco);
                        }
                        catch (System.Exception ex)
                        {
                            Console.WriteLine(ex);
                            Console.WriteLine("=====PRESIONE CUALQUIER TECLA PARA VOLVER AL MENÚ=====");
                            Console.ReadKey();
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Disco a Eliminar: ");
                    String sDisco = Console.ReadLine();
                    this.disquera.EliminarDisco(sDisco);
                    Console.Write("Presione cualquier tecla...");
                    Console.ReadKey();
                    break;
                case 3:
                    this.disquera.MostrarDisco();
                    break;
            }
        } while (op != 0);
    }
}