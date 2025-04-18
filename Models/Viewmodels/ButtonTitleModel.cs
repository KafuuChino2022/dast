using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dast.Models.ViewModels
{
    public class ButtonTitleModel
    {
        /// <summary>
        /// 导航栏集合
        /// </summary>
        public ObservableCollection<NaviModel> NaviCollection { get; set; } = new ObservableCollection<NaviModel>();

        public ButtonTitleModel()
        {
            NaviCollection.Add(new NaviModel() { Icon = "\ue700", Title = "垃圾识别"});
            NaviCollection.Add(new NaviModel() { Icon = "\ue702", Title = "小游戏" });
        }
    }
}
