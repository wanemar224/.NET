namespace AppTagger
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ChargeeImages = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.supprimer = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.AjouterTag = new System.Windows.Forms.Button();
            this.SupprimerTag = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chaineTag = new System.Windows.Forms.Label();
            this.AjouterTagAImage = new System.Windows.Forms.Button();
            this.TableauDeControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SupprimerTagImage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ModifierTag = new System.Windows.Forms.Button();
            this.TextModifierTag = new System.Windows.Forms.TextBox();
            this.TextAjouterTag = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TableauDeControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(263, 518);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(50, 50);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ChargeeImages
            // 
            this.ChargeeImages.Location = new System.Drawing.Point(6, 10);
            this.ChargeeImages.Name = "ChargeeImages";
            this.ChargeeImages.Size = new System.Drawing.Size(99, 31);
            this.ChargeeImages.TabIndex = 1;
            this.ChargeeImages.Text = "Ouvrir";
            this.ChargeeImages.UseVisualStyleBackColor = true;
            this.ChargeeImages.Click += new System.EventHandler(this.ChargeeImages_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(281, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(594, 518);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // supprimer
            // 
            this.supprimer.Location = new System.Drawing.Point(234, 10);
            this.supprimer.Name = "supprimer";
            this.supprimer.Size = new System.Drawing.Size(102, 35);
            this.supprimer.TabIndex = 3;
            this.supprimer.Text = "supprimer";
            this.supprimer.UseVisualStyleBackColor = true;
            this.supprimer.Click += new System.EventHandler(this.supprimer_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(6, 107);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(342, 244);
            this.checkedListBox1.TabIndex = 5;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownHeight = 200;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.ItemHeight = 13;
            this.comboBox1.Location = new System.Drawing.Point(11, 74);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(304, 21);
            this.comboBox1.TabIndex = 28;
            // 
            // AjouterTag
            // 
            this.AjouterTag.Location = new System.Drawing.Point(259, 382);
            this.AjouterTag.Name = "AjouterTag";
            this.AjouterTag.Size = new System.Drawing.Size(89, 23);
            this.AjouterTag.TabIndex = 6;
            this.AjouterTag.Text = "Ajouter";
            this.AjouterTag.UseVisualStyleBackColor = true;
            this.AjouterTag.Click += new System.EventHandler(this.AjouterTag_Click);
            // 
            // SupprimerTag
            // 
            this.SupprimerTag.Location = new System.Drawing.Point(259, 440);
            this.SupprimerTag.Name = "SupprimerTag";
            this.SupprimerTag.Size = new System.Drawing.Size(89, 23);
            this.SupprimerTag.TabIndex = 7;
            this.SupprimerTag.Text = "supprimer";
            this.SupprimerTag.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 50;
            this.label1.Text = "Filtrer";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            // 
            // chaineTag
            // 
            this.chaineTag.AutoSize = true;
            this.chaineTag.Location = new System.Drawing.Point(289, 545);
            this.chaineTag.Name = "chaineTag";
            this.chaineTag.Size = new System.Drawing.Size(0, 13);
            this.chaineTag.TabIndex = 15;
            // 
            // AjouterTagAImage
            // 
            this.AjouterTagAImage.Location = new System.Drawing.Point(11, 113);
            this.AjouterTagAImage.Name = "AjouterTagAImage";
            this.AjouterTagAImage.Size = new System.Drawing.Size(100, 40);
            this.AjouterTagAImage.TabIndex = 26;
            this.AjouterTagAImage.Text = "Ajouter";
            this.AjouterTagAImage.UseVisualStyleBackColor = true;
            this.AjouterTagAImage.Click += new System.EventHandler(this.AjouterTagAImage_Click);
            // 
            // TableauDeControl
            // 
            this.TableauDeControl.Controls.Add(this.tabPage1);
            this.TableauDeControl.Controls.Add(this.tabPage2);
            this.TableauDeControl.Controls.Add(this.tabPage3);
            this.TableauDeControl.Location = new System.Drawing.Point(894, 12);
            this.TableauDeControl.Name = "TableauDeControl";
            this.TableauDeControl.Padding = new System.Drawing.Point(15, 10);
            this.TableauDeControl.SelectedIndex = 0;
            this.TableauDeControl.Size = new System.Drawing.Size(362, 518);
            this.TableauDeControl.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ChargeeImages);
            this.tabPage1.Controls.Add(this.supprimer);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.checkedListBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(354, 478);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Accueil";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.SupprimerTagImage);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.AjouterTagAImage);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 36);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(354, 478);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gestion Images";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SupprimerTagImage
            // 
            this.SupprimerTagImage.Location = new System.Drawing.Point(227, 113);
            this.SupprimerTagImage.Name = "SupprimerTagImage";
            this.SupprimerTagImage.Size = new System.Drawing.Size(88, 40);
            this.SupprimerTagImage.TabIndex = 29;
            this.SupprimerTagImage.Text = "Supprimer";
            this.SupprimerTagImage.UseVisualStyleBackColor = true;
            this.SupprimerTagImage.Click += new System.EventHandler(this.SupprimerTagImage_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(320, 24);
            this.label4.TabIndex = 27;
            this.label4.Text = "Ajouter un tag à l\'image selectionnée";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ModifierTag);
            this.tabPage3.Controls.Add(this.TextModifierTag);
            this.tabPage3.Controls.Add(this.TextAjouterTag);
            this.tabPage3.Controls.Add(this.treeView1);
            this.tabPage3.Controls.Add(this.AjouterTag);
            this.tabPage3.Controls.Add(this.SupprimerTag);
            this.tabPage3.Location = new System.Drawing.Point(4, 36);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(354, 478);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Gestion Tags";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ModifierTag
            // 
            this.ModifierTag.Location = new System.Drawing.Point(259, 411);
            this.ModifierTag.Name = "ModifierTag";
            this.ModifierTag.Size = new System.Drawing.Size(89, 23);
            this.ModifierTag.TabIndex = 31;
            this.ModifierTag.Text = "Modifier";
            this.ModifierTag.UseVisualStyleBackColor = true;
            this.ModifierTag.Click += new System.EventHandler(this.ModifierTag_Click);
            // 
            // TextModifierTag
            // 
            this.TextModifierTag.Location = new System.Drawing.Point(6, 408);
            this.TextModifierTag.Name = "TextModifierTag";
            this.TextModifierTag.Size = new System.Drawing.Size(235, 20);
            this.TextModifierTag.TabIndex = 30;
            // 
            // TextAjouterTag
            // 
            this.TextAjouterTag.Location = new System.Drawing.Point(6, 382);
            this.TextAjouterTag.Name = "TextAjouterTag";
            this.TextAjouterTag.Size = new System.Drawing.Size(235, 20);
            this.TextAjouterTag.TabIndex = 29;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 6);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(342, 370);
            this.treeView1.TabIndex = 28;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1259, 667);
            this.Controls.Add(this.TableauDeControl);
            this.Controls.Add(this.chaineTag);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TableauDeControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button ChargeeImages;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button supprimer;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button AjouterTag;
        private System.Windows.Forms.Button SupprimerTag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label chaineTag;
        private System.Windows.Forms.Button AjouterTagAImage;
        private System.Windows.Forms.TabControl TableauDeControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button ModifierTag;
        private System.Windows.Forms.TextBox TextModifierTag;
        private System.Windows.Forms.TextBox TextAjouterTag;
        private System.Windows.Forms.Button SupprimerTagImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

