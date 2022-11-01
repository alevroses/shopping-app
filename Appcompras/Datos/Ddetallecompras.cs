using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database.Query;
using System.Linq;
using Firebase.Database;
using System.Threading.Tasks;
using Appcompras.Modelo;
using Appcompras.Conexiones;

namespace Appcompras.Datos
{
    public class Ddetallecompras
    {
        public async Task InsertarDc(Mdetallecompras parametros)
        {
            await Cconexion.firebase
                .Child("Detallecompra")
                .PostAsync(new Mdetallecompras()
                {
                    Cantidad = parametros.Cantidad,
                    Idproducto = parametros.Idproducto,
                    Preciocompra = parametros.Preciocompra,
                    Total = parametros.Total
                });
        }

        public async Task<List<Mdetallecompras>> MostrarVistapreviaDc()
        {
            var ListaDc = new List<Mdetallecompras>();
            var parametrosProductos = new Mproductos();
            var funcionproductos = new Dproductos();

            var data = await Cconexion.firebase
                .Child("Detallecompra")
                .OnceAsync<Mdetallecompras>();

            data.Where(a => a.Key != "Modelo");

            foreach(var hobit in data)
            {
                var parametros = new Mdetallecompras();
                parametros.Idproducto = hobit.Object.Idproducto;
                parametrosProductos.Idproducto = hobit.Object.Idproducto;
                var listaproductos = await funcionproductos.MostrarproductosXid(parametrosProductos);

                parametros.Imagen = listaproductos[0].Icono;
                ListaDc.Add(parametros);
            }

            return ListaDc;
        }
    }
}
