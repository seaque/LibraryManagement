
namespace LibraryApp
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btn_student = new MaterialSkin.Controls.MaterialButton();
            this.btn_book = new MaterialSkin.Controls.MaterialButton();
            this.btn_lendhand = new MaterialSkin.Controls.MaterialButton();
            this.btn_graph = new MaterialSkin.Controls.MaterialButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_student
            // 
            this.btn_student.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_student.AutoEllipsis = true;
            this.btn_student.AutoSize = false;
            this.btn_student.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_student.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_student.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn_student.Depth = 0;
            this.btn_student.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_student.HighEmphasis = true;
            this.btn_student.Icon = null;
            this.btn_student.Location = new System.Drawing.Point(90, 117);
            this.btn_student.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_student.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_student.Name = "btn_student";
            this.btn_student.Size = new System.Drawing.Size(252, 48);
            this.btn_student.TabIndex = 0;
            this.btn_student.Text = "STUDENTS";
            this.btn_student.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_student.UseAccentColor = false;
            this.btn_student.UseVisualStyleBackColor = true;
            this.btn_student.Click += new System.EventHandler(this.btn_student_Click);
            // 
            // btn_book
            // 
            this.btn_book.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_book.AutoEllipsis = true;
            this.btn_book.AutoSize = false;
            this.btn_book.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_book.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_book.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn_book.Depth = 0;
            this.btn_book.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_book.HighEmphasis = true;
            this.btn_book.Icon = null;
            this.btn_book.Location = new System.Drawing.Point(90, 176);
            this.btn_book.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_book.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_book.Name = "btn_book";
            this.btn_book.Size = new System.Drawing.Size(252, 45);
            this.btn_book.TabIndex = 1;
            this.btn_book.Text = "BOOKS";
            this.btn_book.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_book.UseAccentColor = false;
            this.btn_book.UseVisualStyleBackColor = true;
            this.btn_book.Click += new System.EventHandler(this.btn_book_Click);
            // 
            // btn_lendhand
            // 
            this.btn_lendhand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_lendhand.AutoEllipsis = true;
            this.btn_lendhand.AutoSize = false;
            this.btn_lendhand.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_lendhand.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_lendhand.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn_lendhand.Depth = 0;
            this.btn_lendhand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_lendhand.HighEmphasis = true;
            this.btn_lendhand.Icon = null;
            this.btn_lendhand.Location = new System.Drawing.Point(90, 232);
            this.btn_lendhand.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_lendhand.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_lendhand.Name = "btn_lendhand";
            this.btn_lendhand.Size = new System.Drawing.Size(252, 46);
            this.btn_lendhand.TabIndex = 2;
            this.btn_lendhand.Text = "LEND / HAND";
            this.btn_lendhand.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_lendhand.UseAccentColor = false;
            this.btn_lendhand.UseVisualStyleBackColor = true;
            this.btn_lendhand.Click += new System.EventHandler(this.btn_lendhand_Click);
            // 
            // btn_graph
            // 
            this.btn_graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_graph.AutoEllipsis = true;
            this.btn_graph.AutoSize = false;
            this.btn_graph.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_graph.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_graph.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn_graph.Depth = 0;
            this.btn_graph.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_graph.HighEmphasis = true;
            this.btn_graph.Icon = null;
            this.btn_graph.Location = new System.Drawing.Point(90, 290);
            this.btn_graph.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_graph.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_graph.Name = "btn_graph";
            this.btn_graph.Size = new System.Drawing.Size(252, 42);
            this.btn_graph.TabIndex = 3;
            this.btn_graph.Text = "GRAPH";
            this.btn_graph.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_graph.UseAccentColor = false;
            this.btn_graph.UseVisualStyleBackColor = true;
            this.btn_graph.Click += new System.EventHandler(this.btn_graph_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(42, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(42, 176);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(42, 232);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(41, 45);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(42, 290);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(41, 42);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_graph);
            this.Controls.Add(this.btn_lendhand);
            this.Controls.Add(this.btn_book);
            this.Controls.Add(this.btn_student);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIBRARY MANAGEMENT";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btn_student;
        private MaterialSkin.Controls.MaterialButton btn_book;
        private MaterialSkin.Controls.MaterialButton btn_lendhand;
        private MaterialSkin.Controls.MaterialButton btn_graph;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}