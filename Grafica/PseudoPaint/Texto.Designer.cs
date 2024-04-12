
namespace PseudoPaint
{
    partial class Texto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TbTexto = new System.Windows.Forms.TextBox();
            this.TbLetra = new System.Windows.Forms.TextBox();
            this.LblTexto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TbTexto
            // 
            this.TbTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbTexto.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTexto.Location = new System.Drawing.Point(12, 41);
            this.TbTexto.Name = "TbTexto";
            this.TbTexto.Size = new System.Drawing.Size(232, 32);
            this.TbTexto.TabIndex = 0;
            // 
            // TbLetra
            // 
            this.TbLetra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbLetra.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbLetra.Location = new System.Drawing.Point(197, 79);
            this.TbLetra.Name = "TbLetra";
            this.TbLetra.Size = new System.Drawing.Size(47, 32);
            this.TbLetra.TabIndex = 1;
            this.TbLetra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbLetra_KeyPress);
            // 
            // LblTexto
            // 
            this.LblTexto.AutoSize = true;
            this.LblTexto.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F);
            this.LblTexto.Location = new System.Drawing.Point(9, 9);
            this.LblTexto.Name = "LblTexto";
            this.LblTexto.Size = new System.Drawing.Size(160, 25);
            this.LblTexto.TabIndex = 2;
            this.LblTexto.Text = "Ingrese su texto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F);
            this.label2.Location = new System.Drawing.Point(9, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tamaño de fuente";
            // 
            // Texto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 123);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblTexto);
            this.Controls.Add(this.TbLetra);
            this.Controls.Add(this.TbTexto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Texto";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Texto_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbTexto;
        private System.Windows.Forms.TextBox TbLetra;
        private System.Windows.Forms.Label LblTexto;
        private System.Windows.Forms.Label label2;
    }
}