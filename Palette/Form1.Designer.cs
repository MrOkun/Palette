
namespace Palette
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Image_Box = new System.Windows.Forms.PictureBox();
            this.Render = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.Load_Button = new System.Windows.Forms.Button();
            this.CheckSave = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.paletteChanger = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Image_Box)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Image_Box
            // 
            this.Image_Box.Location = new System.Drawing.Point(0, 0);
            this.Image_Box.Name = "Image_Box";
            this.Image_Box.Size = new System.Drawing.Size(350, 350);
            this.Image_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Image_Box.TabIndex = 0;
            this.Image_Box.TabStop = false;
            // 
            // Render
            // 
            this.Render.Location = new System.Drawing.Point(273, 368);
            this.Render.Name = "Render";
            this.Render.Size = new System.Drawing.Size(89, 41);
            this.Render.TabIndex = 2;
            this.Render.Text = "Render";
            this.Render.UseVisualStyleBackColor = true;
            this.Render.Click += new System.EventHandler(this.Render_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Location = new System.Drawing.Point(98, 367);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(80, 41);
            this.Save_Button.TabIndex = 3;
            this.Save_Button.Text = "Save";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Load_Button
            // 
            this.Load_Button.Location = new System.Drawing.Point(12, 367);
            this.Load_Button.Name = "Load_Button";
            this.Load_Button.Size = new System.Drawing.Size(80, 42);
            this.Load_Button.TabIndex = 4;
            this.Load_Button.Text = "Load";
            this.Load_Button.UseVisualStyleBackColor = true;
            this.Load_Button.Click += new System.EventHandler(this.Load_Button_Click);
            // 
            // CheckSave
            // 
            this.CheckSave.AutoSize = true;
            this.CheckSave.Checked = true;
            this.CheckSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckSave.Location = new System.Drawing.Point(184, 367);
            this.CheckSave.Name = "CheckSave";
            this.CheckSave.Size = new System.Drawing.Size(80, 19);
            this.CheckSave.TabIndex = 5;
            this.CheckSave.Text = "Open Expl";
            this.CheckSave.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.Image_Box);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 350);
            this.panel1.TabIndex = 6;
            // 
            // paletteChanger
            // 
            this.paletteChanger.DisplayMember = "0";
            this.paletteChanger.FormattingEnabled = true;
            this.paletteChanger.Items.AddRange(new object[] {
            "1 PALETTE",
            "2 PALETTE",
            "ST 8 PHOENIX PALETTE",
            "NINTENDO GAMEBOY (ARNE) PALETTE",
            "RUST GOLD 8 PALETTE"});
            this.paletteChanger.Location = new System.Drawing.Point(184, 385);
            this.paletteChanger.Name = "paletteChanger";
            this.paletteChanger.Size = new System.Drawing.Size(83, 23);
            this.paletteChanger.TabIndex = 1;
            this.paletteChanger.ValueMember = "0";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 414);
            this.Controls.Add(this.paletteChanger);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CheckSave);
            this.Controls.Add(this.Load_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Render);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(390, 453);
            this.MinimumSize = new System.Drawing.Size(390, 453);
            this.Name = "FormMain";
            this.Text = "Palette";
            ((System.ComponentModel.ISupportInitialize)(this.Image_Box)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Image_Box;
        private System.Windows.Forms.Button Render;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Button Load_Button;
        private System.Windows.Forms.CheckBox CheckSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox paletteChanger;
    }
}

