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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dast
{
    /// <summary>
    /// SuperButton.xaml 的交互逻辑
    /// </summary>
    public partial class SuperButton : Button
    {
        public SuperButton()
        {
            InitializeComponent();
        }
        private void Click_SuperButton(object sender, RoutedEventArgs e)
        {
            var roundEllipse =  Template.FindName("RoundEllipse", this) as EllipseGeometry;
            roundEllipse.Center = Mouse.GetPosition(this);
            var ani_expend = new DoubleAnimation()
            {
                From = 0,
                To = 180,
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            roundEllipse.BeginAnimation(EllipseGeometry.RadiusXProperty, ani_expend);
            var ani_disapear = new DoubleAnimation()
            {
                From = 0.3,
                To = 0
            };
            var roundPath = Template.FindName("RoundPath", this) as Path;
            roundPath.BeginAnimation(Path.OpacityProperty, ani_disapear);
        }
    }
}
