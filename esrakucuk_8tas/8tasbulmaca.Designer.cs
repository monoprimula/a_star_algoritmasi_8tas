namespace AStarAlgoritmasi8TasBulmacasi
{
    partial class AStar8Bulmaca
    {
        private System.ComponentModel.IContainer components = null;

        // Bellek yönetimi için Dispose metodu
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtBaslangic = new System.Windows.Forms.TextBox();
            this.txtAmac = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCoz = new System.Windows.Forms.Button();
            this.txtSonuc = new System.Windows.Forms.TextBox();
            this.txtActions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(29, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Başlangıç :";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtBaslangic
            // 
            this.txtBaslangic.Font = new System.Drawing.Font("Arial", 12F);
            this.txtBaslangic.Location = new System.Drawing.Point(144, 71);
            this.txtBaslangic.Name = "txtBaslangic";
            this.txtBaslangic.Size = new System.Drawing.Size(189, 30);
            this.txtBaslangic.TabIndex = 1;
            this.txtBaslangic.Text = "4,1,3,2,8,5,7,0,6";
            // 
            // txtAmac
            // 
            this.txtAmac.Font = new System.Drawing.Font("Arial", 12F);
            this.txtAmac.Location = new System.Drawing.Point(143, 109);
            this.txtAmac.Name = "txtAmac";
            this.txtAmac.Size = new System.Drawing.Size(189, 30);
            this.txtAmac.TabIndex = 3;
            this.txtAmac.Text = "1,2,3,4,5,6,7,8,0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(46, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hedef :";
            // 
            // btnCoz
            // 
            this.btnCoz.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCoz.Location = new System.Drawing.Point(314, 145);
            this.btnCoz.Name = "btnCoz";
            this.btnCoz.Size = new System.Drawing.Size(89, 37);
            this.btnCoz.TabIndex = 4;
            this.btnCoz.Text = "Çöz";
            this.btnCoz.UseVisualStyleBackColor = true;
            this.btnCoz.Click += new System.EventHandler(this.btnCoz_Click);
            // 
            // txtSonuc
            // 
            this.txtSonuc.Font = new System.Drawing.Font("Arial", 12F);
            this.txtSonuc.Location = new System.Drawing.Point(562, 326);
            this.txtSonuc.Multiline = true;
            this.txtSonuc.Name = "txtSonuc";
            this.txtSonuc.ReadOnly = true;
            this.txtSonuc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSonuc.Size = new System.Drawing.Size(370, 333);
            this.txtSonuc.TabIndex = 5;
            // 
            // txtActions
            // 
            this.txtActions.Font = new System.Drawing.Font("Arial", 12F);
            this.txtActions.Location = new System.Drawing.Point(562, 68);
            this.txtActions.Multiline = true;
            this.txtActions.Name = "txtActions";
            this.txtActions.ReadOnly = true;
            this.txtActions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtActions.Size = new System.Drawing.Size(370, 160);
            this.txtActions.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(557, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bulunan Çözüm :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(557, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Adımlar :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(12, 674);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(546, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "İstediğiniz değerleri girerek yeni oyun oluşturabilirsiniz :)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // AStar8Bulmaca
            // 
            this.ClientSize = new System.Drawing.Size(984, 765);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtActions);
            this.Controls.Add(this.txtSonuc);
            this.Controls.Add(this.btnCoz);
            this.Controls.Add(this.txtAmac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBaslangic);
            this.Controls.Add(this.label1);
            this.Name = "AStar8Bulmaca";
            this.Text = " 8 Taş";
            this.Load += new System.EventHandler(this.AStar8Bulmaca_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBaslangic;
        private System.Windows.Forms.TextBox txtAmac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCoz;
        private System.Windows.Forms.TextBox txtSonuc;
        private System.Windows.Forms.TextBox txtActions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}