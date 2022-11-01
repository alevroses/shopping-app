using Appcompras.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Appcompras.VistaModelo
{
    public class VMagregarcompra:BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public Mproductos Parametrosrecibe { get; set; }
        #endregion

        #region CONSTRUCTOR
        public VMagregarcompra(INavigation navigation, Mproductos parametrosTrae)
        {
            Navigation = navigation;
            Parametrosrecibe = parametrosTrae;
        }
        #endregion

        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion

        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        //Cuando no son procesos Asíncronos se
        //remplaza el async Task por void 
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        //Llamar al Proceso Asincrona: await es para tareas asincronas
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        //Llamar al Proceso Simple o no Asincrono
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
