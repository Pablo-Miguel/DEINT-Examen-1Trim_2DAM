// See https://aka.ms/new-console-template for more information


using Examen_1Trim_Pablo_Miguel_del_Castillo_Barba_2DAM.Ejercicio1;
using Examen_1Trim_Pablo_Miguel_del_Castillo_Barba_2DAM.Ejercicio2;
using Examen_1Trim_Pablo_Miguel_del_Castillo_Barba_2DAM.Ejercicio2.Excepcion;
using System.Linq;

//Ejercicio1
Console.WriteLine("EJERCICIO 1");
Console.WriteLine();

int numComienza = 8;

numComienza.imprimirConRango(10);

Console.WriteLine();

//Ejercicio2
Console.WriteLine("EJERCICIO 2");
Console.WriteLine();

List<Empleado> listaEmpleados = new List<Empleado>();
try
{
    Console.WriteLine("Introduzca el número de empleados a introducir: ");
    int numEmpleados = Int16.Parse(Console.ReadLine());

    for (int i = 0; i < numEmpleados; i++) {
        
        Console.WriteLine($"Introduce el DNI del empleado {i}:");
        String? dni = Console.ReadLine();
        Empleado empleado = new Empleado(dni);
        
        Console.WriteLine($"Introduzca el nombre del empleado {i}:");
        String nombre = Console.ReadLine();
        empleado.Nombre = nombre;

        Console.WriteLine($"Introduzca el sueldo base del empleado {i}:");
        Int16 sueldoBase = Int16.Parse(Console.ReadLine());
        empleado.SueldoBase = sueldoBase;

        Console.WriteLine($"Introduzca el pago de horas extras del empleado {i}:");
        Int16 pagoHorasExtras = Int16.Parse(Console.ReadLine());
        empleado.PagoHorasExtras = pagoHorasExtras;

        Console.WriteLine($"Introduzca el numero de horas extras del empleado {i}:");
        Int16 numHorasExtras = Int16.Parse(Console.ReadLine());
        empleado.NumHorasExtras = numHorasExtras;

        Console.WriteLine($"Introduzca el porcentaje de IRPF del empleado {i}:");
        Int16 porcentajeIRPF = Int16.Parse(Console.ReadLine());
        empleado.PorcentajeIRPF = porcentajeIRPF;

        Console.WriteLine($"Introduzca si el empleado {i} está casado [1 - Sí, 0 - No]:");
        Int16 casado = Int16.Parse(Console.ReadLine());
        if (casado == 1)
        {
            empleado.Casado = true;
        }
        else if (casado == 0)
        {
            empleado.Casado = false;
        }
        else {
            throw new Exception("Casado está fuera de rango o caracter incorrecto");
        }

        Console.WriteLine($"Introduzca el numero de hijos del empleado {i}:");
        Int16 numHijos = Int16.Parse(Console.ReadLine());
        empleado.NumHijos = numHijos;

        listaEmpleados.Add(empleado);

        Console.WriteLine();
        Console.WriteLine("Complemento horas extras: " + empleado.calcularComplementoHorasExtras());
        Console.WriteLine("Sueldo bruto: " + empleado.calcularSueldoBruto());
        Console.WriteLine("Retencion IRPF: " + empleado.calcularRetencionesIRPF());
        Console.WriteLine("Se ha creado el empleado: " + empleado.ToString());
        Console.WriteLine();
    }
}
catch (ExceptionFormatDNI ex)
{
    Console.WriteLine(ex.Message);
}
catch (ArgumentNullException ex) {
    Console.WriteLine(ex.Message);
}
catch (Exception ex) {
    Console.WriteLine(ex.Message);
}

if (listaEmpleados.Count != 0) {

    var conHijos = listaEmpleados.Where(e => e.NumHijos > 0).ToList();
    var ordSalario = listaEmpleados.OrderBy(e => e.SueldoBase).ToList();
    var masCobra = ordSalario.Last();
    var menosCobra = ordSalario.First();

    Console.WriteLine($"Empleado que más cobra: {masCobra.ToString()}");
    Console.WriteLine($"Empleado que menos cobra: {menosCobra.ToString()}");

    if (conHijos.Count != 0) {
        Console.WriteLine("Empleados con hijos:");
        foreach (var elem in conHijos)
        {
            Console.WriteLine($"Empleado {elem.Nombre} tiene {elem.NumHijos} hijos.");
        }
    }
    else {
        Console.WriteLine("No hay empleados con hijos");
    }

    if (ordSalario.Count != 0)
    {
        Console.WriteLine("Empleados ordenados por salario de menor a mayor:");
        foreach (var elem in ordSalario)
        {
            Console.WriteLine(elem.ToString());
        }
    }
    else
    {
        Console.WriteLine("No hay empleados");
    }

}

