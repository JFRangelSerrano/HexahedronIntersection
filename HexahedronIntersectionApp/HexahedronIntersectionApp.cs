using HexahedronIntersection.GeometricForms;
using HexahedronIntersection.Managers;
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
    public partial class HexahedronIntersectionApp : Form
    {
        public HexahedronIntersectionApp()
        {
            InitializeComponent();
        }

        private void GetIntersectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                var hexahedron1CenterPoint = new HexahedronIntersection.GeometricForms.Point(HexahedronControl1.CenterXCoordenate, HexahedronControl1.CenterYCoordenate, HexahedronControl1.CenterZCoordenate);
                var hexahedron1 = new Hexahedron(hexahedron1CenterPoint, HexahedronControl1.HexahedronWidth, HexahedronControl1.HexahedronHeight, HexahedronControl1.HexahedronDepth);
                HexahedronControl1.HexahedronVolume = hexahedron1.volume;

                var hexahedron2CenterPoint = new HexahedronIntersection.GeometricForms.Point(HexahedronControl2.CenterXCoordenate, HexahedronControl2.CenterYCoordenate, HexahedronControl2.CenterZCoordenate);
                var hexahedron2 = new Hexahedron(hexahedron2CenterPoint, HexahedronControl2.HexahedronWidth, HexahedronControl2.HexahedronHeight, HexahedronControl2.HexahedronDepth);
                HexahedronControl2.HexahedronVolume = hexahedron2.volume;

                var hexahedronIntersection = HexahedronIntersectionManager.GetIntersection(hexahedron1, hexahedron2);

                if (hexahedronIntersection==null)
                {
                    this.IntersectionSplitContainer.Panel1Collapsed = false;
                    this.IntersectionSplitContainer.Panel2Collapsed = true;
                }
                else
                {
                    this.IntersectionSplitContainer.Panel1Collapsed = true;
                    this.IntersectionSplitContainer.Panel2Collapsed = false;

                    this.HexahedronControlIntersection.CenterXCoordenate = hexahedronIntersection.center.x;
                    this.HexahedronControlIntersection.CenterYCoordenate = hexahedronIntersection.center.y;
                    this.HexahedronControlIntersection.CenterZCoordenate = hexahedronIntersection.center.z;
                    this.HexahedronControlIntersection.HexahedronWidth = hexahedronIntersection.width;
                    this.HexahedronControlIntersection.HexahedronHeight = hexahedronIntersection.height;
                    this.HexahedronControlIntersection.HexahedronDepth = hexahedronIntersection.depth;
                    this.HexahedronControlIntersection.HexahedronVolume = hexahedronIntersection.volume;
                }
            }
            catch (Exception Ex)
            {
                this.IntersectionSplitContainer.Panel1Collapsed = false;
                this.IntersectionSplitContainer.Panel2Collapsed = true;

                MessageBox.Show(Ex.Message,"Error");
            }

        }
    }
}
