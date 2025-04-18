using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dast.Models
{
    public class NaviModel
    {
        /// <summary>
        /// 图标
        /// </summary>
        private string _icon;

        public string Icon
        { 
            get {return _icon;}
            set {_icon = value;}
        }

        /// <summary>
        /// 文本
        /// </summary>
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
}
