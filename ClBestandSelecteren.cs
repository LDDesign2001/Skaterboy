using System.Windows.Forms;

namespace Skaterboy
{
    class ClBestandSelecteren
    {
        string bestandEnPad;
        public string getBestand()
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecteer bestand";
            ofd.Filter = "Alle bestanden (*.jpg,*.png)|*.jpg;*.png;";
            ofd.FilterIndex = 0;
            ofd.InitialDirectory = @"C:";
            bool padOk = ofd.CheckPathExists;
            if (!padOk) ofd.InitialDirectory = @"Bureaublad";
            if (ofd.ShowDialog() == DialogResult.OK) bestandEnPad = ofd.FileName;
            return bestandEnPad;
        }

    }
}
