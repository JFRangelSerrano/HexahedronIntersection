
namespace HexahedronIntersectionApp
{
    partial class HexahedronControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ZNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.YNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.XNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DepthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.HeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.WidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DepthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ZNumericUpDown);
            this.groupBox1.Controls.Add(this.YNumericUpDown);
            this.groupBox1.Controls.Add(this.XNumericUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Center point";
            // 
            // ZNumericUpDown
            // 
            this.ZNumericUpDown.DecimalPlaces = 2;
            this.ZNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ZNumericUpDown.Location = new System.Drawing.Point(86, 75);
            this.ZNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.ZNumericUpDown.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147352576});
            this.ZNumericUpDown.Name = "ZNumericUpDown";
            this.ZNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.ZNumericUpDown.TabIndex = 5;
            // 
            // YNumericUpDown
            // 
            this.YNumericUpDown.DecimalPlaces = 2;
            this.YNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.YNumericUpDown.Location = new System.Drawing.Point(86, 49);
            this.YNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.YNumericUpDown.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147352576});
            this.YNumericUpDown.Name = "YNumericUpDown";
            this.YNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.YNumericUpDown.TabIndex = 4;
            // 
            // XNumericUpDown
            // 
            this.XNumericUpDown.DecimalPlaces = 2;
            this.XNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.XNumericUpDown.Location = new System.Drawing.Point(86, 23);
            this.XNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.XNumericUpDown.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147352576});
            this.XNumericUpDown.Name = "XNumericUpDown";
            this.XNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.XNumericUpDown.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Z coordenate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y coordenate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X coordenate:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DepthNumericUpDown);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.HeightNumericUpDown);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.WidthNumericUpDown);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(3, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dimensions";
            // 
            // DepthNumericUpDown
            // 
            this.DepthNumericUpDown.DecimalPlaces = 2;
            this.DepthNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.DepthNumericUpDown.Location = new System.Drawing.Point(90, 71);
            this.DepthNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.DepthNumericUpDown.Name = "DepthNumericUpDown";
            this.DepthNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.DepthNumericUpDown.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Depth (Z axis):";
            // 
            // HeightNumericUpDown
            // 
            this.HeightNumericUpDown.DecimalPlaces = 2;
            this.HeightNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.HeightNumericUpDown.Location = new System.Drawing.Point(90, 45);
            this.HeightNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.HeightNumericUpDown.Name = "HeightNumericUpDown";
            this.HeightNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.HeightNumericUpDown.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Height (Y axis):";
            // 
            // WidthNumericUpDown
            // 
            this.WidthNumericUpDown.DecimalPlaces = 2;
            this.WidthNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.WidthNumericUpDown.Location = new System.Drawing.Point(90, 19);
            this.WidthNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.WidthNumericUpDown.Name = "WidthNumericUpDown";
            this.WidthNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.WidthNumericUpDown.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Width (X axis):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.VolumeLabel);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(3, 219);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(170, 50);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Volume";
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.Location = new System.Drawing.Point(59, 25);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(100, 23);
            this.VolumeLabel.TabIndex = 1;
            this.VolumeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Volume:";
            // 
            // HexahedronControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "HexahedronControl";
            this.Size = new System.Drawing.Size(177, 275);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DepthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown ZNumericUpDown;
        private System.Windows.Forms.NumericUpDown YNumericUpDown;
        private System.Windows.Forms.NumericUpDown XNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown DepthNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown HeightNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown WidthNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.Label label7;
    }
}
