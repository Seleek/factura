using System;

public class LlenarFactura
{
	private List<Factura> facturas = new List<Factura>
	{
		new Factura{Identificador = 1, Fecha = (2015,12,31), Nombre = "Maria", "Cepillo", Precio = 4},
		new Factura{Identificador = 2, Fecha = (2016,11,31), Nombre = "Juan", "Peine", Precio = 6},
	};

	public Task<List<Factura>> ObtenerFacturas() => Task.FromResult(facturas);

	public Task AgregarFactura(Factura factura)
	{
		facturas.add(factura);
		return Task.CompletedTask;
	}
}
