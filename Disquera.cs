public class Disquera
{
    private Int32 nCantidadMaxima;
    private Int32 nContador;
    private Disco[] discos;

    public Disquera()
    {
        this.nCantidadMaxima = 1;
        this.discos = new Disco[this.nCantidadMaxima];
        this.nContador = 0;
    }
    public void AgregarDisco(Disco disco)
    {
        if (this.nContador >= this.nCantidadMaxima)
        {
            Disco[] discos = new Disco[this.nCantidadMaxima + 1];
            for (int i = 0; i < this.nContador; i++)
            {
                discos[i] = this.discos[i];
            }
            this.discos = discos;
        }
        this.discos[this.nContador] = disco;
        this.nContador++;
        this.nCantidadMaxima = this.discos.Length;
    }

    public void EliminarDisco(String sNombreDisco)
    {
        Int32[] nIndices = this.BuscarDisco(sNombreDisco);
        if (nIndices.Length > 1)
        {
            Console.Clear();
            Console.WriteLine("MÁS DE UN DISCO COINCIDE CON EL NOMBRE");
            for (int i = 0; i < nIndices.Length; i++)
            {
                Console.WriteLine($"{i + 1}.-{this.discos[nIndices[i]].sNombreDisco}, {this.discos[nIndices[i]].nCantidadCanciones}");
            }
            Console.WriteLine("Escoja el disco a eliminar: ");
            try
            {
                Int32 op = Int32.Parse(Console.ReadLine());
                this.discos[nIndices[op - 1]].sNombreDisco = "<Null>";
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("=====PRESIONE CUALQUIER TECLA PARA VOLVER AL MENÚ=====");
                Console.ReadKey();
            }
        }
        else
        {
            this.discos[nIndices[0]].sNombreDisco = "<Null>";
        }

        Disco[] discos = new Disco[this.nContador - 1];
        Int32 j = 0;
        for (int i = 0; i < discos.Length; i++)
        {
            if (this.discos[i].sNombreDisco == "<Null>")
            {
                j++;
                discos[i] = this.discos[j];
            }
            else
            {
                discos[i] = this.discos[j];
            }
            j++;
        }
        this.discos = discos;
        this.nContador--;
        this.nCantidadMaxima--;
    }

    public void MostrarDisco()
    {
        Console.Clear();
        for (int i = 0; i < this.discos.Length; i++)
        {
            Console.WriteLine($"Nombre: {this.discos[i].sNombreDisco} | Precio: {this.discos[i].dPrecio} | Cantidad de canciones: {this.discos[i].nCantidadCanciones} | Fecha: {this.discos[i].doFechaCompra}");
        }
        Console.ReadKey();
    }

    private Int32[] BuscarDisco(String sNombreDisco)
    {
        Int32 nCantidad = 1;
        String sIndices = "-1";

        do
        {
            for (int i = 0; i < this.nContador; i++)
            {
                if (this.discos[i].sNombreDisco.Equals(sNombreDisco))
                {
                    sIndices += $"|{i}";
                    nCantidad++;
                }
            }
            if (sIndices == "-1")
            {
                Console.WriteLine("NO EXISTE EL DISCO CON ESE NOMBRE");
                Console.WriteLine("Introduzca el nombre nuevamente: ");
                sNombreDisco = Console.ReadLine();
            }
        } while (sIndices == "-1");


        String[] sIndices2 = sIndices.Split("|");
        Int32[] nIndices = new int[nCantidad - 1];
        
        for (int i = 1; i < nCantidad; i++)
        {
            nIndices[i - 1] = Int32.Parse(sIndices2[i]);
        }
        return nIndices;
    }
}
