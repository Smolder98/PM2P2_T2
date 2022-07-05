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
        private void Button_Clicked(object sender, EventArgs e)
        {

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


            SignatureService signatureService = new SignatureService();

            if (await signatureService.saveSignatures(signature))
            {
                

                //Validacion para q se cree la carpeta donde se guardaran las imagenes
                var folderPath = "/storage/emulated/0/Android/data/com.companyname.pm2p2_t2/files/Pictures";
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);


                //if(!File.Exists(Path.GetFileName(folderPath + "/" + txtName)))
                File.WriteAllBytes(folderPath + "/"+txtName.Text + ".jpg", signature.ArrayByteImage);


              


                Message("La firmar se guardo correctamente!!");
            }
            else Message("La firmar no se pudo guardar correctamente!!");

        }


        public async void Message(string msg)
        {
            await DisplayAlert("Notificacion", msg, "OK");
        }

    }
}
