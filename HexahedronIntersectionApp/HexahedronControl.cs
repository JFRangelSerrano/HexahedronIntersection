using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HexahedronIntersectionApp
{
    public partial class HexahedronControl : UserControl
    {
        public HexahedronControl()
        {
            InitializeComponent();
        }

        public decimal CenterXCoordenate
        {
            get
            {
                return this.XNumericUpDown.Value;
            }
            set
            {
                this.XNumericUpDown.Value = value;
            }
        }

        public decimal CenterYCoordenate
        {
            get
            {
                return this.YNumericUpDown.Value;
            }
            set
            {
                this.YNumericUpDown.Value = value;
            }
        }

        public decimal CenterZCoordenate
        {
            get
            {
                return this.ZNumericUpDown.Value;
            }
            set
            {
                this.ZNumericUpDown.Value = value;
            }
        }

        public decimal HexahedronWidth
        {
            get
            {
                return this.WidthNumericUpDown.Value;
            }
            set
            {
                this.WidthNumericUpDown.Value = value;
            }
        }

        public decimal HexahedronHeight
        {
            get
            {
                return this.HeightNumericUpDown.Value;
            }
            set
            {
                this.HeightNumericUpDown.Value = value;
            }
        }

        public decimal HexahedronDepth
        {
            get
            {
                return this.DepthNumericUpDown.Value;
            }
            set
            {
                this.DepthNumericUpDown.Value = value;
            }
        }

        public decimal HexahedronVolume
        {
            set
            {
                this.VolumeLabel.Text = value.ToString();
            }
        }

        public bool ReadOnly
        {
            get
            {
                return this.XNumericUpDown.ReadOnly;
            }
            set
            {
                this.XNumericUpDown.ReadOnly = value;
                this.YNumericUpDown.ReadOnly = value;
                this.ZNumericUpDown.ReadOnly = value;
                this.WidthNumericUpDown.ReadOnly = value;
                this.HeightNumericUpDown.ReadOnly = value;
                this.DepthNumericUpDown.ReadOnly = value;
            }
        }
    }
}
