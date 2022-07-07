
namespace DbOgrenciOtomasyon
{
    partial class FrmOnay
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
            this.txtnogir = new System.Windows.Forms.TextBox();
            this.btnderssil = new System.Windows.Forms.Button();
            this.btndersekle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnbul = new System.Windows.Forms.Button();
            this.txtders2 = new System.Windows.Forms.TextBox();
            this.txtders3 = new System.Windows.Forms.TextBox();
            this.txtders4 = new System.Windows.Forms.TextBox();
            this.txtders1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtnogir
            // 
            this.txtnogir.Location = new System.Drawing.Point(25, 262);
            this.txtnogir.Name = "txtnogir";
            this.txtnogir.Size = new System.Drawing.Size(139, 20);
            this.txtnogir.TabIndex = 47;
            // 
            // btnderssil
            // 
            this.btnderssil.BackColor = System.Drawing.Color.White;
            this.btnderssil.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnderssil.Location = new System.Drawing.Point(634, 251);
            this.btnderssil.Name = "btnderssil";
            this.btnderssil.Size = new System.Drawing.Size(61, 39);
            this.btnderssil.TabIndex = 49;
            this.btnderssil.Text = "Sil";
            this.btnderssil.UseVisualStyleBackColor = false;
            this.btnderssil.Click += new System.EventHandler(this.btnderssil_Click);
            // 
            // btndersekle
            // 
            this.btndersekle.BackColor = System.Drawing.Color.White;
            this.btndersekle.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btndersekle.Location = new System.Drawing.Point(487, 251);
            this.btndersekle.Name = "btndersekle";
            this.btndersekle.Size = new System.Drawing.Size(141, 39);
            this.btndersekle.TabIndex = 48;
            this.btndersekle.Text = "Ekle ve Güncelle";
            this.btndersekle.UseVisualStyleBackColor = false;
            this.btndersekle.Click += new System.EventHandler(this.btndersekle_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(686, 233);
            this.dataGridView1.TabIndex = 51;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnbul
            // 
            this.btnbul.BackColor = System.Drawing.Color.White;
            this.btnbul.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnbul.Location = new System.Drawing.Point(170, 251);
            this.btnbul.Name = "btnbul";
            this.btnbul.Size = new System.Drawing.Size(77, 39);
            this.btnbul.TabIndex = 52;
            this.btnbul.Text = "Bul";
            this.btnbul.UseVisualStyleBackColor = false;
            this.btnbul.Click += new System.EventHandler(this.btnbul_Click);
            // 
            // txtders2
            // 
            this.txtders2.Location = new System.Drawing.Point(333, 262);
            this.txtders2.Name = "txtders2";
            this.txtders2.Size = new System.Drawing.Size(27, 20);
            this.txtders2.TabIndex = 56;
            // 
            // txtders3
            // 
            this.txtders3.Location = new System.Drawing.Point(365, 262);
            this.txtders3.Name = "txtders3";
            this.txtders3.Size = new System.Drawing.Size(27, 20);
            this.txtders3.TabIndex = 55;
            // 
            // txtders4
            // 
            this.txtders4.Location = new System.Drawing.Point(397, 262);
            this.txtders4.Name = "txtders4";
            this.txtders4.Size = new System.Drawing.Size(27, 20);
            this.txtders4.TabIndex = 54;
            // 
            // txtders1
            // 
            this.txtders1.Location = new System.Drawing.Point(301, 262);
            this.txtders1.Name = "txtders1";
            this.txtders1.Size = new System.Drawing.Size(27, 20);
            this.txtders1.TabIndex = 53;
            // 
            // FrmOnay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(707, 300);
            this.Controls.Add(this.txtders2);
            this.Controls.Add(this.txtders3);
            this.Controls.Add(this.txtders4);
            this.Controls.Add(this.txtders1);
            this.Controls.Add(this.btnbul);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtnogir);
            this.Controls.Add(this.btnderssil);
            this.Controls.Add(this.btndersekle);
            this.Name = "FrmOnay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOnay";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtnogir;
        private System.Windows.Forms.Button btnderssil;
        private System.Windows.Forms.Button btndersekle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnbul;
        private System.Windows.Forms.TextBox txtders2;
        private System.Windows.Forms.TextBox txtders3;
        private System.Windows.Forms.TextBox txtders4;
        private System.Windows.Forms.TextBox txtders1;
    }
}