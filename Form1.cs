using System;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace AudioControlApp
{
    public partial class Form1 : Form
    {
        private MMDevice defaultDevice;

#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public Form1()
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configurar o valor máximo e mínimo do controle TrackBar
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 100;

            // Obter o dispositivo de áudio padrão
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            defaultDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            // Set the initial audio volume to 50%
            trackBar1.Value = 50;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            // Obter o valor do controle TrackBar
            int volume = trackBar1.Value;

            // Converter o valor do controle TrackBar para a faixa de 0.0 a 1.0
            float volumeNormalized = volume / 100f;

            // Alterar o volume do dispositivo de áudio padrão
            defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = volumeNormalized;

            // Exibir o valor do volume atual na etiqueta
            label1.Text = "Volume: " + volume.ToString();
        }
    }
}