using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCVTest
{
    public partial class BlurControl : UserControl
    {
        public delegate int BlurEvent();
        public event BlurEvent eventBlur;

        public delegate int BoxFilterEvent();
        public event BoxFilterEvent eventBoxFilter;

        public delegate int MedianBlurEvent();
        public event MedianBlurEvent eventMedianBlur;

        public delegate int GaussianBlurEvent();
        public event GaussianBlurEvent eventGaussianBlur;

        public delegate int BilateralFilterEvent();
        public event BilateralFilterEvent eventBilateralFilter;

        public delegate int CloseEvent();
        public event CloseEvent eventClose;

        public delegate int ReEvent();
        public event ReEvent eventReturn;

        public BlurControl()
        {
            InitializeComponent();
        }

        private void btnBlur_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Text)
            {
                case "Blur":
                    eventBlur?.Invoke();
                    break;
                case "BoxFilter":
                    eventBoxFilter?.Invoke();
                    break;
                case "MedianBlur":
                    eventMedianBlur?.Invoke();
                    break;
                case "GaussianBlur":
                    eventGaussianBlur?.Invoke();
                    break;
                case "BilateralFilter":
                    eventBilateralFilter?.Invoke();
                    break;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            eventClose.Invoke();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            eventReturn.Invoke();
        }
    }
}
