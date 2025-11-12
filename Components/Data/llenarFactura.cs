using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace factura.Components.Data;

public class LlenarFactura
{
    private List<Factura> facturas = new List<Factura>
    {
        new Factura { Identificador = 1, Fecha = new DateTime(2015, 12, 31), Nombre = "Maria", Articulo = "Cepillo", Precio = 4 },
        new Factura { Identificador = 2, Fecha = new DateTime(2016, 11, 30), Nombre = "Juan", Articulo = "Peine", Precio = 6 },
    };

    public Task<List<Factura>> ObtenerFacturas() => Task.FromResult(facturas);

    public Task AgregarFactura(Factura factura)
    {
        facturas.Add(factura);
        return Task.CompletedTask;
    }
}
