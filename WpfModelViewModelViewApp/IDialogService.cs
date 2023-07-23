using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfModelViewModelViewApp
{
    public interface IDialogService
    {
        string FilePath { set; get; }

        void ShowMessage(string message);
        bool OpenFileDialog();
        bool SaveFileDialog();
    }
}
