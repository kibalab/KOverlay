using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plugins
{
    public interface Plugin //플러그인을 받아서 함수실행해요
    {
        void run(Form form);
        string PluginName();
    }
}
