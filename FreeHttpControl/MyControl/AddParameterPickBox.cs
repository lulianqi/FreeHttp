using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FreeHttp.AutoTest.ParameterizationPick;

namespace FreeHttp.FreeHttpControl.MyControl
{
    public partial class AddParameterPickBox : UserControl
    {
        public AddParameterPickBox()
        {
            InitializeComponent();
        }

        public ParameterPick GetParameterPickInfo()
        {
            ParameterPick returnParameterPick=new ParameterPick();
            ParameterPickType tempParameterPickType;
            if(!Enum.TryParse<ParameterPickType>(cb_ParameterType.Text,out tempParameterPickType))
            {
                throw new Exception("ParameterPickType Error");
            }
            returnParameterPick.PickType = tempParameterPickType;
            returnParameterPick.PickTypeAdditional = cb_ParameterTypeAddition.Text;
            returnParameterPick.PickTypeExpression = tb_ParameterExpression.Text;
            return returnParameterPick;
        }
    }
}
