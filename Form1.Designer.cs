namespace Losowe_figury_geometryczne
{
    partial class LosoweFiguryGeometryczne
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLiczbaFigur = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnNew_place = new System.Windows.Forms.Button();
            this.btnRandom_los = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chlbFigury = new System.Windows.Forms.CheckedListBox();
            this.imgPlansza = new System.Windows.Forms.PictureBox();
            this.ERROR = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnLosowaFigura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlansza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ERROR)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Podaj liczbę figur geometrycznych";
            // 
            // txtLiczbaFigur
            // 
            this.txtLiczbaFigur.Location = new System.Drawing.Point(42, 34);
            this.txtLiczbaFigur.Name = "txtLiczbaFigur";
            this.txtLiczbaFigur.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLiczbaFigur.Size = new System.Drawing.Size(100, 20);
            this.txtLiczbaFigur.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStart.Location = new System.Drawing.Point(53, 60);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnNew_place
            // 
            this.btnNew_place.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNew_place.Location = new System.Drawing.Point(30, 89);
            this.btnNew_place.Name = "btnNew_place";
            this.btnNew_place.Size = new System.Drawing.Size(123, 44);
            this.btnNew_place.TabIndex = 3;
            this.btnNew_place.Text = "Przesunięcie do nowego miejsca";
            this.btnNew_place.UseVisualStyleBackColor = true;
            this.btnNew_place.Click += new System.EventHandler(this.btnNew_place_Click);
            // 
            // btnRandom_los
            // 
            this.btnRandom_los.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRandom_los.Location = new System.Drawing.Point(30, 139);
            this.btnRandom_los.Name = "btnRandom_los";
            this.btnRandom_los.Size = new System.Drawing.Size(123, 55);
            this.btnRandom_los.TabIndex = 4;
            this.btnRandom_los.Text = "Wylosuj nowe położenie oraz atrybuty";
            this.btnRandom_los.UseVisualStyleBackColor = true;
            this.btnRandom_los.Click += new System.EventHandler(this.btnRandom_los_Click);
            // 
            // stop
            // 
            this.stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stop.Location = new System.Drawing.Point(42, 200);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(100, 48);
            this.stop.TabIndex = 5;
            this.stop.Text = "Stop / Resetuj";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(699, 18);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(173, 39);
            this.label2.TabIndex = 6;
            this.label2.Text = "Zaznacz figury geometryczne,\r\nktóre mają być losowane \r\ni wyświetlane na planszy " +
    "graficznej ";
            // 
            // chlbFigury
            // 
            this.chlbFigury.FormattingEnabled = true;
            this.chlbFigury.Items.AddRange(new object[] {
            "Punkt ",
            "Linia ",
            "Elipsa",
            "Wypełniona elipsa",
            "Prostokąt",
            "Kwadrat\t",
            "Trójkąt",
            "Trójkąt prostokątny"});
            this.chlbFigury.Location = new System.Drawing.Point(693, 73);
            this.chlbFigury.Name = "chlbFigury";
            this.chlbFigury.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chlbFigury.Size = new System.Drawing.Size(179, 139);
            this.chlbFigury.TabIndex = 7;
            // 
            // imgPlansza
            // 
            this.imgPlansza.Location = new System.Drawing.Point(185, 33);
            this.imgPlansza.Name = "imgPlansza";
            this.imgPlansza.Size = new System.Drawing.Size(502, 438);
            this.imgPlansza.TabIndex = 8;
            this.imgPlansza.TabStop = false;
            // 
            // ERROR
            // 
            this.ERROR.ContainerControl = this;
            // 
            // btnLosowaFigura
            // 
            this.btnLosowaFigura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLosowaFigura.ForeColor = System.Drawing.Color.Blue;
            this.btnLosowaFigura.Location = new System.Drawing.Point(42, 254);
            this.btnLosowaFigura.Name = "btnLosowaFigura";
            this.btnLosowaFigura.Size = new System.Drawing.Size(100, 52);
            this.btnLosowaFigura.TabIndex = 9;
            this.btnLosowaFigura.Text = "Dodanie losowej figury";
            this.btnLosowaFigura.UseVisualStyleBackColor = true;
            this.btnLosowaFigura.Click += new System.EventHandler(this.btnLosowaFigura_Click);
            // 
            // LosoweFiguryGeometryczne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 483);
            this.Controls.Add(this.btnLosowaFigura);
            this.Controls.Add(this.imgPlansza);
            this.Controls.Add(this.chlbFigury);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.btnRandom_los);
            this.Controls.Add(this.btnNew_place);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtLiczbaFigur);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "LosoweFiguryGeometryczne";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Losowe figury geometryczne";
            ((System.ComponentModel.ISupportInitialize)(this.imgPlansza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ERROR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLiczbaFigur;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnNew_place;
        private System.Windows.Forms.Button btnRandom_los;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chlbFigury;
        private System.Windows.Forms.PictureBox imgPlansza;
        private System.Windows.Forms.ErrorProvider ERROR;
        private System.Windows.Forms.Button btnLosowaFigura;
    }
}

