
namespace IgricePS.Klijent.UI
{
    partial class KreiranjeOcenaIgriceUI
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
            this.button1 = new System.Windows.Forms.Button();
            this.cmbKorisnik = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbIgrica = new System.Windows.Forms.ComboBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.cmbNazivOcene = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTabela = new System.Windows.Forms.DataGridView();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabela)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 44);
            this.button1.TabIndex = 39;
            this.button1.Text = "Izmeni";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbKorisnik
            // 
            this.cmbKorisnik.FormattingEnabled = true;
            this.cmbKorisnik.Location = new System.Drawing.Point(323, 107);
            this.cmbKorisnik.Name = "cmbKorisnik";
            this.cmbKorisnik.Size = new System.Drawing.Size(249, 24);
            this.cmbKorisnik.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(323, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "Korisnik";
            // 
            // cmbIgrica
            // 
            this.cmbIgrica.FormattingEnabled = true;
            this.cmbIgrica.Location = new System.Drawing.Point(323, 47);
            this.cmbIgrica.Name = "cmbIgrica";
            this.cmbIgrica.Size = new System.Drawing.Size(249, 24);
            this.cmbIgrica.TabIndex = 36;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(459, 396);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(113, 44);
            this.btnSacuvaj.TabIndex = 29;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Opis";
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(28, 110);
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(249, 22);
            this.txtOpis.TabIndex = 25;
            // 
            // cmbNazivOcene
            // 
            this.cmbNazivOcene.FormattingEnabled = true;
            this.cmbNazivOcene.Location = new System.Drawing.Point(28, 47);
            this.cmbNazivOcene.Name = "cmbNazivOcene";
            this.cmbNazivOcene.Size = new System.Drawing.Size(249, 24);
            this.cmbNazivOcene.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 41;
            this.label1.Text = "Naziv ocene";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(320, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 42;
            this.label2.Text = "Igrica";
            // 
            // dgvTabela
            // 
            this.dgvTabela.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTabela.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(101)))), ((int)(((byte)(103)))));
            this.dgvTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabela.Location = new System.Drawing.Point(28, 187);
            this.dgvTabela.Name = "dgvTabela";
            this.dgvTabela.RowHeadersWidth = 51;
            this.dgvTabela.RowTemplate.Height = 24;
            this.dgvTabela.Size = new System.Drawing.Size(544, 192);
            this.dgvTabela.TabIndex = 43;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(488, 137);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(84, 35);
            this.btnDodaj.TabIndex = 44;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(398, 137);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(84, 35);
            this.btnObrisi.TabIndex = 45;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // KreiranjeOcenaIgriceUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(78)))), ((int)(((byte)(91)))));
            this.ClientSize = new System.Drawing.Size(604, 453);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.dgvTabela);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNazivOcene);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbKorisnik);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbIgrica);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOpis);
            this.Name = "KreiranjeOcenaIgriceUI";
            this.Text = "KreiranjeOcenaIgrice";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbKorisnik;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbIgrica;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.ComboBox cmbNazivOcene;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTabela;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnObrisi;
    }
}