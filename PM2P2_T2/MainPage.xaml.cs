using PM2P2_T2.Model;
using PM2P2_T2.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM2P2_T2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            if (App.DBase != null) { }

        }
    

        //Lista de firmas
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.ListPage());
        }
        //Guardar firma
        private async void Button_Clicked_1(object sender, EventArgs e)
        {

            if (Sign.IsBlank)
            {
                Message("Por favor ingrese la firma.");
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDescription.Text))
            {
                Message("Debe ingresar un nombre y descripcion a la firma.");
                return;
            }


            //Para limpiar -- Sign.Clear();
            Stream img = await Sign.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            var mStream = (MemoryStream)img;
            Byte[] bytes = mStream.ToArray();
            var signature = new Signature()
            {
                Id = 0,
                Name = txtName.Text,
                Description = txtDescription.Text,
                ArrayByteImage = bytes
            };


            var folderPath = "/storage/emulated/0/Android/data/com.companyname.pm2p2_t2/files/Pictures";
            var nameSignature = "";
            if (await new SignatureService().saveSignatures(signature))
            {

                try
                {
                    //Validacion para q se cree la carpeta donde se guardaran las imagenes
                    
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);


                    //if(!File.Exists(Path.GetFileName(folderPath + "/" + txtName)))

                    nameSignature = txtName.Text + DateTime.Now.ToString("MMddyyyyhhmmss"); ;

                    File.WriteAllBytes(folderPath + "/" + nameSignature  + ".png", signature.ArrayByteImage);

                    Message("La firmar se guardo correctamente!! \nPath:" + folderPath + "/" + nameSignature + ".png");
                }
                catch {
                    Message("La firmar se guardo correctamente!!");
                }
               
                

                clear();
            }
            else Message("La firmar no se pudo guardar correctamente!!");

        }


        private void clear()
        {
            txtName.Text = null;
            txtDescription.Text = null;

            Sign.Clear();
        }

        public async void Message(string msg)
        {
            await DisplayAlert("Notificacion", msg, "OK");
        }

    }
}
