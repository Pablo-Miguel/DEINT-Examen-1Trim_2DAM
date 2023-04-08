using Examen_1Trim_Pablo_Miguel_del_Castillo_Barba_2DAM.Ejercicio2.Excepcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Examen_1Trim_Pablo_Miguel_del_Castillo_Barba_2DAM.Ejercicio2
{
    internal class Empleado
    {
        private const String NOMBRE = "";
        private const Int16 SUELDO_BASE = 0;
        private const Int16 PAGO_HORAS_EXRAS = 0;
        private const Int16 NUM_HORAS_EXTRAS = 0;
        private const Double PORCENTAJE_IRPF = 0;
        private const Boolean CASADO = false;
        private const Int16 NUM_HIJOS = 0;

        public String? Dni { get; set; }
        public String Nombre { get; set; }
        public Int16 SueldoBase { get; set; }
        public Int16 PagoHorasExtras { get; set; }
        public Int16 NumHorasExtras { get; set; }
        public Double PorcentajeIRPF { get; set; }
        public Boolean Casado { get; set; }
        public Int16 NumHijos { get; set; }

        public Empleado()
        {
            Nombre = NOMBRE;
            SueldoBase = SUELDO_BASE;
            PagoHorasExtras = PAGO_HORAS_EXRAS;
            NumHorasExtras = NUM_HORAS_EXTRAS;
            PorcentajeIRPF = PORCENTAJE_IRPF;
            Casado = CASADO;
            NumHijos = NUM_HIJOS;
        }

        public Empleado(String? dni)
        {
            try
            {
                Dni = comprobarDNI(dni);
                Nombre = NOMBRE;
                SueldoBase = SUELDO_BASE;
                PagoHorasExtras = PAGO_HORAS_EXRAS;
                NumHorasExtras = NUM_HORAS_EXTRAS;
                PorcentajeIRPF = PORCENTAJE_IRPF;
                Casado = CASADO;
                NumHijos = NUM_HIJOS;
            }
            catch (ExceptionFormatDNI)
            {
                throw new ExceptionFormatDNI();
            }
            catch (ArgumentNullException) {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        private String comprobarDNI(String? dni)
        {
            if (Regex.IsMatch(dni, @"^[0-9]{8}[A-Z]$"))
            {
                return dni;
            }
            else if (dni == null) {
                throw new ArgumentNullException();
            }
            else
            {
                throw new ExceptionFormatDNI();
            }
        }

        public Int16 calcularComplementoHorasExtras() => (short)(PagoHorasExtras * NumHorasExtras);
        public Int16 calcularSueldoBruto() => (short) (SueldoBase + calcularComplementoHorasExtras());
        public Double calcularRetencionesIRPF() => Math.Round(calcularSueldoBruto() * obtenerPorcentajeIRPF(), 2);
        private Double obtenerPorcentajeIRPF()
        {
            if (PorcentajeIRPF >= 2 && Casado)
            {
                return ((PorcentajeIRPF - 2) / 100);
            }
            else if (PorcentajeIRPF >= NumHijos)
            {
                return (PorcentajeIRPF - NumHijos);
            }
            else {
                return (PorcentajeIRPF / 100);
            }
        }

        public Int16 calcularSueldoNeto() => (short) (calcularSueldoBruto() - calcularRetencionesIRPF());

        public override string ToString()
        {
            return $"Empleado -> Nombre: {Nombre}, Sueldo Neto: {calcularSueldoNeto()}";
        }

    }

}
