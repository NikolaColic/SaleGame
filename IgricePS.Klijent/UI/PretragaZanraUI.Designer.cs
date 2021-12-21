
namespace IgricePS.Klijent.UI
{
    partial class PretragaZanraUI
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
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.dgvTabela = new System.Windows.Forms.DataGridView();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabela)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Location = new System.Drawing.Point(297, 27);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(84, 35);
            this.btnPretrazi.TabIndex = 65;
            this.btnPretrazi.Text = "Pretrazi";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(402, 27);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(84, 35);
            this.btnRestart.TabIndex = 64;
            this.btnRestart.Text = "Restartuj";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // dgvTabela
            // 
            this.dgvTabela.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTabela.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(101)))), ((int)(((byte)(103)))));
            this.dgvTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabela.Location = new System.Drawing.Point(12, 100);
            this.dgvTabela.Name = "dgvTabela";
            this.dgvTabela.RowHeadersWidth = 51;
            this.dgvTabela.RowTemplate.Height = 24;
            this.dgvTabela.Size = new System.Drawing.Size(578, 200);
            this.dgvTabela.TabIndex = 63;
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(12, 40);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(249, 22);
            this.txtPretraga.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 17);
            this.label3.TabIndex = 66;
            this.label3.Text = "Unesite tekst pretrage:";
            // 
            // PretragaZanraUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(78)))), ((int)(((byte)(91)))));
            this.ClientSize = new System.Drawing.Size(614, 316);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.dgvTabela);
            this.Controls.Add(this.txtPretraga);
            this.Name = "PretragaZanraUI";
            this.Text = "PretragaZanraUI";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.DataGridView dgvTabela;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Label label3;
    }
}