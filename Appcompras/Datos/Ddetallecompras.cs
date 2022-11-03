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

            var data = (await Cconexion.firebase
                .Child("Detallecompra")
                .OnceAsync<Mdetallecompras>())
                .Where(a => a.Key != "Modelo")
                .Select(item=> new Mdetallecompras
                {
                    Idproducto = item.Object.Idproducto,
                    Iddetallecompra = item.Key
                })
                ;

            foreach(var hobit in data)
            {
                var parametros = new Mdetallecompras();
                parametros.Idproducto = hobit.Idproducto;
                parametrosProductos.Idproducto = hobit.Idproducto;
                var listaproductos = await funcionproductos.MostrarproductosXid(parametrosProductos);

                parametros.Imagen = listaproductos[0].Icono;
                ListaDc.Add(parametros);
            }

            return ListaDc;
        }

        public async Task<List<Mdetallecompras>> MostrarDc()
        {
            var ListaDc = new List<Mdetallecompras>();
            var parametrosProductos = new Mproductos();
            var funcionproductos = new Dproductos();

            var data = (await Cconexion.firebase
                .Child("Detallecompra")
                .OnceAsync<Mdetallecompras>())
                .Where(a => a.Key != "Modelo")
                .Select(item => new Mdetallecompras
                {
                    Idproducto = item.Object.Idproducto,
                    Iddetallecompra = item.Key
                })
                ;

            foreach (var hobit in data)
            {
                var parametros = new Mdetallecompras();
                parametros.Idproducto = hobit.Idproducto;
                parametrosProductos.Idproducto = hobit.Idproducto;
                var listaproductos = await funcionproductos.MostrarproductosXid(parametrosProductos);

                parametros.Imagen = listaproductos[0].Icono;
                parametros.Cantidad = hobit.Cantidad;
                parametros.Total = hobit.Total;
                ListaDc.Add(parametros);
            }

            return ListaDc;
        }
    }
}
