using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ServicePresidente
/// </summary>
public class ServicePresidentes:IServicePresidentes
{
    public List<Presidentes> GetPresidente()

    {
        return new List<Presidentes>

            {
            new Presidentes
            {
                IdPresidente=1,
                Nombres="Carlos Angel",
                Apellidos="Ipanaque Lujan",
                DNI="921921120",
                Partido="Casado",
                AntecedentesPoliciales="Sin Antecedentes"
                },
            new Presidentes
            {
                IdPresidente=2,
                Nombres="Jessica Juana",
                Apellidos="Huaita Luna",
                DNI="921921620",
                Partido="Soltero",
                AntecedentesPoliciales="Sin Antecedentes"
            }
        };
    }
}