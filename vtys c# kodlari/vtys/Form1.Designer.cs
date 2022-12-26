
namespace vtys
{
    partial class Form1
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
            this.btn_blt_al = new System.Windows.Forms.Button();
            this.btn_yonet_gir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_blt_al
            // 
            this.btn_blt_al.Location = new System.Drawing.Point(36, 52);
            this.btn_blt_al.Name = "btn_blt_al";
            this.btn_blt_al.Size = new System.Drawing.Size(208, 190);
            this.btn_blt_al.TabIndex = 1;
            this.btn_blt_al.Text = "BILET AL";
            this.btn_blt_al.UseVisualStyleBackColor = true;
            this.btn_blt_al.Click += new System.EventHandler(this.btn_blt_al_Click);
            // 
            // btn_yonet_gir
            // 
            this.btn_yonet_gir.Location = new System.Drawing.Point(250, 52);
            this.btn_yonet_gir.Name = "btn_yonet_gir";
            this.btn_yonet_gir.Size = new System.Drawing.Size(208, 190);
            this.btn_yonet_gir.TabIndex = 2;
            this.btn_yonet_gir.Text = "YÖNETICI GIRISI";
            this.btn_yonet_gir.UseVisualStyleBackColor = true;
            this.btn_yonet_gir.Click += new System.EventHandler(this.btn_yonet_gir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 296);
            this.Controls.Add(this.btn_blt_al);
            this.Controls.Add(this.btn_yonet_gir);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_blt_al;
        private System.Windows.Forms.Button btn_yonet_gir;
    }
}

