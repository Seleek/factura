using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace factura.Components.Data;

public class LlenarFactura
{
    private List<Factura> facturas = new List<Factura>();



    public async Task<List<Factura>> ObtenerFacturas()
    {
        facturas.Clear();
        String ruta = "facturas.db";
        using var conexion = new SqliteConnection($"DataSource={ruta}");
        await conexion.OpenAsync();

        var comando = conexion.CreateCommand();
        comando.CommandText = "SELECT ID,FECHA,NOMBRE,ARTICULO,PRECIO FROM FACTURAS";
        using var lector = await comando.ExecuteReaderAsync();

        while (await lector.ReadAsync())
        {
            facturas.Add(new Factura
            {
                Identificador = lector.GetInt32(0),
                Fecha = DateOnly.FromDateTime(lector.GetDateTime(1)),
                Nombre = lector.GetString(2),
                Articulo = lector.GetString(3),
                Precio = lector.GetInt32(4)
            });
        }
        return facturas;

    }
    public async Task AgregarFactura(Factura factura)
    {
        String ruta = "facturas.db";
        using var conexion = new SqliteConnection($"DataSource={ruta}");
        await conexion.OpenAsync();

        var comando = conexion.CreateCommand();

        comando.CommandText = "insert into facturas (id,fecha,nombre,articulo,precio) values ($ID,$FECHA,$NOMBRE,$ARTICULO,$PRECIO)";
        comando.Parameters.AddWithValue("$ID", factura.Identificador);
        comando.Parameters.AddWithValue("$FECHA", factura.Fecha);
        comando.Parameters.AddWithValue("$NOMBRE", factura.Nombre);
        comando.Parameters.AddWithValue("$ARTICULO", factura.Articulo);
        comando.Parameters.AddWithValue("$PRECIO", factura.Precio);
        
        comando.ExecuteNonQueryAsync();

        facturas.Add(factura);
      
    }
}
