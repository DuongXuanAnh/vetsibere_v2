namespace VetsiBere
{
    partial class Menu
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
            this.btn_Konec = new System.Windows.Forms.Button();
            this.btn_Nastaveni = new System.Windows.Forms.Button();
            this.btn_Pomoc = new System.Windows.Forms.Button();
            this.btn_SpustitHru = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Konec
            // 
            this.btn_Konec.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Konec.Location = new System.Drawing.Point(12, 324);
            this.btn_Konec.Name = "btn_Konec";
            this.btn_Konec.Size = new System.Drawing.Size(376, 98);
            this.btn_Konec.TabIndex = 7;
            this.btn_Konec.Text = "Konec";
            this.btn_Konec.UseVisualStyleBackColor = true;
            this.btn_Konec.Click += new System.EventHandler(this.btn_Konec_Click);
            // 
            // btn_Nastaveni
            // 
            this.btn_Nastaveni.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Nastaveni.Location = new System.Drawing.Point(12, 220);
            this.btn_Nastaveni.Name = "btn_Nastaveni";
            this.btn_Nastaveni.Size = new System.Drawing.Size(376, 98);
            this.btn_Nastaveni.TabIndex = 6;
            this.btn_Nastaveni.Text = "Nastavení";
            this.btn_Nastaveni.UseVisualStyleBackColor = true;
            this.btn_Nastaveni.Click += new System.EventHandler(this.btn_Nastaveni_Click);
            // 
            // btn_Pomoc
            // 
            this.btn_Pomoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Pomoc.Location = new System.Drawing.Point(12, 116);
            this.btn_Pomoc.Name = "btn_Pomoc";
            this.btn_Pomoc.Size = new System.Drawing.Size(376, 98);
            this.btn_Pomoc.TabIndex = 5;
            this.btn_Pomoc.Text = "Pomoc";
            this.btn_Pomoc.UseVisualStyleBackColor = true;
            this.btn_Pomoc.Click += new System.EventHandler(this.btn_Pomoc_Click);
            // 
            // btn_SpustitHru
            // 
            this.btn_SpustitHru.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_SpustitHru.Location = new System.Drawing.Point(12, 12);
            this.btn_SpustitHru.Name = "btn_SpustitHru";
            this.btn_SpustitHru.Size = new System.Drawing.Size(376, 98);
            this.btn_SpustitHru.TabIndex = 4;
            this.btn_SpustitHru.Text = "Spustit hru";
            this.btn_SpustitHru.UseVisualStyleBackColor = true;
            this.btn_SpustitHru.Click += new System.EventHandler(this.btn_SpustitHru_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 431);
            this.Controls.Add(this.btn_Konec);
            this.Controls.Add(this.btn_Nastaveni);
            this.Controls.Add(this.btn_Pomoc);
            this.Controls.Add(this.btn_SpustitHru);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Konec;
        private System.Windows.Forms.Button btn_Nastaveni;
        private System.Windows.Forms.Button btn_Pomoc;
        private System.Windows.Forms.Button btn_SpustitHru;
    }
}