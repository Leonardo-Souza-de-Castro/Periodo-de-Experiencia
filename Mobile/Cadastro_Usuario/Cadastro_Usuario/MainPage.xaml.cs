using Cadastro_Usuario.Models;
using Cadastro_Usuario.Services;
using Cadastro_Usuario.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cadastro_Usuario
{
    public partial class MainPage : ContentPage
    {
        private Usuarios usuario;
        readonly UsuariosAPI api;

        public MainPage()
        {
            InitializeComponent();
            api = new UsuariosAPI();
            AtualizaDados();
        }

        private async void btCadastrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                usuario = new Usuarios();
                usuario.firstName = entFirstname.Text;
                usuario.surName = entSurname.Text;
                usuario.age = Convert.ToInt32(entAge.Text);
                if (btSalvar.Text == "Atualizar")
                {
                    usuario.Id = Guid.Parse(entId.Text);
                    await api.UpDateUser(usuario);
                    btSalvar.Text = "Cadastrar";
                }
                else
                {
                    await api.CreateUser(usuario);
                }
                this.LimparCampos();
                this.AtualizaDados();
                await DisplayAlert("Alerta", "Operação realizada com sucesso", "OK");
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "OK");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var id = Guid.Parse(entId.Text);
                if (id != null)
                {
                    await api.DeleteUser(id);
                    btSalvar.Text = "Cadastrar";
                    this.AtualizaDados();
                    this.LimparCampos();
                }
                await DisplayAlert("Alerta", "Operação realizada com sucesso", "OK");
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "OK");
            }
        }

        private void LimparCampos()
        {
            entId.Text = "";
            entFirstname.Text = "";
            entSurname.Text = "";
            entAge.Text = "";
        }

        async void AtualizaDados()
        {
            var teste = await api.GetUsers();
            listaUsuarios.ItemsSource = teste.OrderBy(item => item.firstName).ToList();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var id = Guid.Parse(entId.Text);
                usuario = await api.GetUser(id);
                if (usuario.Id != null)
                {
                    entFirstname.Text = usuario.firstName;
                    entSurname.Text = usuario.surName;
                    entAge.Text = usuario.age.ToString();
                    btSalvar.Text = "Atualizar";
                }
                else btSalvar.Text = "Cadastrar";
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "OK");

            }
        }

        private void listaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            usuario = e.SelectedItem as Usuarios;

            if (usuario.Id != null)
            {
            entId.Text = usuario.Id.ToString();
            entFirstname.Text = usuario.firstName;
            entSurname.Text = usuario.surName;
            entAge.Text = usuario.age.ToString();
            btSalvar.Text = "Atualizar";
            }
            else
            {
                btSalvar.Text = "Cadastrar";
            }
        }
    }
}
