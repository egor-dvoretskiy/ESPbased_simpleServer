using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;
using System.Windows.Threading;
using System.Threading;

namespace ESP_pairing_PC
{

    public partial class MainWindow : Window
    {
        private DispatcherTimer mainTimer;
        private Thread thread_ESP_listener;

        public MainWindow()
        {
            InitializeComponent();

            thread_ESP_listener = new Thread(source.ESP_listener.Entry);
            thread_ESP_listener.IsBackground = true;
            thread_ESP_listener.Start();
            
            mainTimer = new DispatcherTimer();
            mainTimer.Interval = TimeSpan.FromSeconds(1);
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            
        }

        private void Btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            //this.WindowState = WindowState.Minimized;
            this.Hide();
        }

        private void Btn_test_Click(object sender, RoutedEventArgs e)
        {

            foreach (var i in Temperature.Temperatures)
                Console.WriteLine(i.CurrentValue);
        }
    }

    public class Temperature
    {
        public double CurrentValue { get; set; }
        public string InstanceName { get; set; }
        public static List<Temperature> Temperatures
        {
            get
            {
                List<Temperature> result = new List<Temperature>();
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
                foreach (ManagementObject obj in searcher.Get())
                {
                    Double temp = Convert.ToDouble(obj["CurrentTemperature"].ToString());
                    temp = (temp - 2732) / 10.0;
                    result.Add(new Temperature { CurrentValue = temp, InstanceName = obj["InstanceName"].ToString() });
                }
                return result;

            }
        }
    }
}
