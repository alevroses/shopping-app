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
    }
}
