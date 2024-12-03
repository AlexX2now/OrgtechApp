using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QRCoder;
using ZXing;

namespace UP_2
{
    /// <summary>
    /// Логика взаимодействия для ManagerP.xaml
    /// </summary>
    public partial class ManagerP : Window
    {
        public ManagerP()
        {
            InitializeComponent();

            System.Drawing.Image img = null;
            BitmapImage bimg = new BitmapImage();
            using (var ms = new MemoryStream())
            {
                BarcodeWriter writer;
                writer = new ZXing.BarcodeWriter() { Format = BarcodeFormat.QR_CODE };
                writer.Options.Height = 190;
                writer.Options.Width = 190;
                writer.Options.PureBarcode = true;
                img = writer.Write("https://docs.google.com/forms/d/e/1FAIpQLSdhZcExx6LSIXxk0ub55mSu-WIh23WYdGG9HY5EZhLDo7P8eA/viewform?usp=sf_link");
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Position = 0;
                bimg.BeginInit();
                bimg.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                bimg.CacheOption = BitmapCacheOption.OnLoad;
                bimg.UriSource = null;
                bimg.StreamSource = ms;
                bimg.EndInit();
                this.Imagee.Source = bimg;
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
