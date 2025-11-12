using System.Runtime.CompilerServices;
using factura.Components.Data;


namespace factura.Components.Servicios
{
    public class ServicioControlador
	{
		private readonly LlenarFactura _llenarFactura;

		public ServicioControlador(LlenarFactura llenarFactura)
	{
		_llenarFactura = llenarFactura;

	}

	public async Task<List<Factura>> ObtenerFacturas()
	{
		return await _llenarFactura.ObtenerFacturas();
	}

	public async Task AgregarFactura(Factura factura)
	{
		factura.Identificador = await GenerarNuevoId();
		await _llenarFactura.AgregarFactura(factura);
	}

	private async Task<int> GenerarNuevoId()
	{
		var facturas = await _llenarFactura.ObtenerFacturas();
		return facturas.Any() ? facturas.Max(t => t.Identificador) + 1 : 1;
	}

	}
}



