using Appcompras.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appcompras.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Compras : ContentPage
    {
        VMcompras vm;

        public Compras()
        {
            InitializeComponent();
            vm = new VMcompras(Navigation, Carrilderecha, Carrilizquierda);
            BindingContext = vm;

            this.Appearing += Compras_Appearing; //+=Tabulador
        }

        private async void Compras_Appearing(object sender, EventArgs e)
        {
            await vm.MostrarVistapreviaDc();
        }
    }
}