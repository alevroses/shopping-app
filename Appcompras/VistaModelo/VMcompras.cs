﻿using Appcompras.Datos;
using Appcompras.Modelo;
using Appcompras.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Appcompras.VistaModelo
{
    public class VMcompras : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        int _index;

        List<Mproductos> _listaproductos;
        #endregion

        #region CONSTRUCTOR
        public VMcompras(INavigation navigation, StackLayout Carrilderecha, StackLayout Carrilizquierda)
        {
            Navigation = navigation;
            Mostrarproductos(Carrilderecha, Carrilizquierda);
        }
        #endregion

        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }

        public List<Mproductos> Listaproductos
        {
            get { return _listaproductos; }
            set { SetValue(ref _listaproductos, value); }
        }
        #endregion

        #region PROCESOS
        public async Task Mostrarproductos(StackLayout Carrilderecha, StackLayout Carrilizquierda)
        {
            var funcion = new Dproductos();
            Listaproductos = await funcion.Mostrarproductos();

            var box = new BoxView
            {
                HeightRequest = 60
            };

            Carrilderecha.Children.Clear();
            Carrilizquierda.Children.Clear();

            Carrilderecha.Children.Add(box);
            
            foreach(var item in Listaproductos)
            {
                Dibujarproductos(item, _index, Carrilderecha, Carrilizquierda);
                _index++;
            }
        }

        public void Dibujarproductos(Mproductos item, int index, StackLayout Carrilderecha, StackLayout Carrilizquierda)
        {
            var _ubicacion = Convert.ToBoolean(index % 2);
            var carril = _ubicacion ? Carrilderecha : Carrilizquierda;

            var frame = new Frame
            {
                HeightRequest = 300,
                CornerRadius = 10,
                Margin = 8,
                HasShadow = false,
                BackgroundColor = Color.White,
                Padding = 22,
            };

            var stack = new StackLayout
            {

            };

            var image = new Image
            {
                Source = item.Icono,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 10),
            };

            var labelprecio = new Label
            {
                Text = "$" + item.Precio,
                FontAttributes = FontAttributes.Bold,
                FontSize = 22,
                Margin = new Thickness(0, 10),
                TextColor = Color.FromHex("#333333")
            };

            var labeldescripcion = new Label
            {
                Text = item.Descripcion,
                FontSize = 16,
                TextColor = Color.Black,
                CharacterSpacing = 1
            };

            var labelpeso = new Label
            {
                Text = item.Peso,
                FontSize = 13,
                TextColor = Color.FromHex("#cccccc"),
                CharacterSpacing = 1
            };

            stack.Children.Add(image);
            stack.Children.Add(labelprecio);
            stack.Children.Add(labeldescripcion);
            stack.Children.Add(labelpeso);

            frame.Content = stack;

            var tap = new TapGestureRecognizer();
            tap.Tapped += async (object sender, EventArgs e) =>
            {
                await Navigation.PushAsync(new Agregarcompra(item));
            };

            carril.Children.Add(frame);
            stack.GestureRecognizers.Add(tap);
        }

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
