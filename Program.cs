Console.WriteLine("******************** Bienvenido a Picas y Fijas! ********************\n");
Console.WriteLine("Objetivo: Intenta adivinar el código secreto de 4 dígitos.\n");
Console.WriteLine("### REGLAS");
Console.WriteLine("- En cada intento digitaras un numero de 4 dígitos");
Console.WriteLine("- El sistema le indicara cuantas 'picas' y 'fijas' tiene su número.");
Console.WriteLine("- Pica: el número existe, pero esta en una posicion incorrecta.");
Console.WriteLine("- Fijas: el número existe y está en la posición correcta.\n");
Console.WriteLine("### VICTORIA");
Console.WriteLine("- Debes obtener 4 fijas, es decir adivinar el numero secreto\n");
Console.WriteLine("*********************************************************************");


// Generar un código secreto aleatorio de 4 dígitos
Random random = new Random();
int[] codigoSecreto = new int[4];
for (int i = 0; i < 4; i++)
{
    codigoSecreto[i] = random.Next(10); // Números del 0 al 9
}

int intentos = 0;

while (true)
{
    Console.Write("Ingresa tu número de 4 dígitos: ");
    string entrada = Console.ReadLine();

    // Si la longitud es diferente de 4 se ejecuta la siguiente condición
    if (entrada.Length != 4)
    {
        Console.WriteLine("*** Ingresa exactamente 4 dígitos. ***");
        continue;
    }

    // Bloque de código que verifica que solo se ingresen números enteros
    int[] intento = new int[4];
    for (int i = 0; i < 4; i++)
    {
        if (!int.TryParse(entrada[i].ToString(), out intento[i]))
        {
            Console.WriteLine("(*** Ingresa solo dígitos. ***");
            break;
        }
    }

    // Compara el intento con el código secreto
    int picas = 0;
    int fijas = 0;

    for (int i = 0; i < 4; i++)
    {
        if (intento[i] == codigoSecreto[i])
        {
            fijas++;
        }
        else
        {
            for (int j = 0; j < 4; j++)
            {
                if (intento[i] == codigoSecreto[j])
                {
                    picas++;
                    break;
                }
            }
        }
    }

    Console.WriteLine($"Picas: {picas}, Fijas: {fijas}\n");
    intentos++;

    if (fijas == 4)
    {
        Console.WriteLine($"¡Ganaste en {intentos} intentos!");
        break;
    }
}