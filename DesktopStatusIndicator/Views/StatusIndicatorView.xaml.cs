using DesktopStatusIndicator.Properties;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace DesktopStatusIndicator.Views
{
    public partial class StatusIndicatorView : Window
    {
        private readonly IReadOnlyList<Ellipse> _trafficLights;

        public StatusIndicatorView()
        {
            InitializeComponent();
            _trafficLights = new[] { RedTrafficLight, YellowTrafficLight, GreenTrafficLight };
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void TrafficLight_MouseDown_Toggle(object sender, MouseButtonEventArgs e)
        {
            foreach (var trafficLight in _trafficLights)
            {
                if (trafficLight == sender)
                {
                    trafficLight.Opacity = trafficLight.Opacity == 1 ? .05 : 1;
                }
                else
                {
                    trafficLight.Opacity = .05;
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Settings.Default.Save();

            base.OnClosing(e);
        }
    }
}
