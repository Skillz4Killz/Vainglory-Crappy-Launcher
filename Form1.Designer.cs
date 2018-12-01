namespace Vainglory_Updater_Tool
{
  partial class Form1
  {
    /// <summary>
    /// Variable del diseñador necesaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpiar los recursos que se estén usando.
    /// </summary>
    /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    /// <summary>
    /// Método necesario para admitir el Diseñador. No se puede modificar
    /// el contenido de este método con el editor de código.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.playButton = new System.Windows.Forms.Button();
      this.releaseLabel = new System.Windows.Forms.Label();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.changeLogs = new System.Windows.Forms.RichTextBox();
      this.localLabel = new System.Windows.Forms.Label();
      this.downloadLabel = new System.Windows.Forms.Label();
      this.installButton = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // playButton
      // 
      this.playButton.BackColor = System.Drawing.SystemColors.Desktop;
      this.playButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.playButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.playButton.Location = new System.Drawing.Point(12, 358);
      this.playButton.Name = "playButton";
      this.playButton.Size = new System.Drawing.Size(314, 40);
      this.playButton.TabIndex = 0;
      this.playButton.Text = "Play";
      this.playButton.UseVisualStyleBackColor = false;
      this.playButton.Click += new System.EventHandler(this.playButton_Click);
      // 
      // releaseLabel
      // 
      this.releaseLabel.AutoSize = true;
      this.releaseLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.releaseLabel.Location = new System.Drawing.Point(12, 24);
      this.releaseLabel.Name = "releaseLabel";
      this.releaseLabel.Size = new System.Drawing.Size(135, 19);
      this.releaseLabel.TabIndex = 2;
      this.releaseLabel.Text = "releaseVersion";
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(333, 359);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(455, 79);
      this.progressBar.TabIndex = 4;
      // 
      // changeLogs
      // 
      this.changeLogs.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.changeLogs.Location = new System.Drawing.Point(12, 65);
      this.changeLogs.Name = "changeLogs";
      this.changeLogs.ReadOnly = true;
      this.changeLogs.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
      this.changeLogs.Size = new System.Drawing.Size(776, 288);
      this.changeLogs.TabIndex = 5;
      this.changeLogs.Text = "";
      // 
      // localLabel
      // 
      this.localLabel.AutoSize = true;
      this.localLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.localLabel.Location = new System.Drawing.Point(12, 43);
      this.localLabel.Name = "localLabel";
      this.localLabel.Size = new System.Drawing.Size(117, 19);
      this.localLabel.TabIndex = 6;
      this.localLabel.Text = "localVersion";
      // 
      // downloadLabel
      // 
      this.downloadLabel.AutoSize = true;
      this.downloadLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.downloadLabel.ForeColor = System.Drawing.SystemColors.ControlText;
      this.downloadLabel.Location = new System.Drawing.Point(333, 359);
      this.downloadLabel.Name = "downloadLabel";
      this.downloadLabel.Size = new System.Drawing.Size(40, 22);
      this.downloadLabel.TabIndex = 7;
      this.downloadLabel.Text = "100";
      // 
      // installButton
      // 
      this.installButton.BackColor = System.Drawing.SystemColors.Desktop;
      this.installButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.installButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.installButton.Location = new System.Drawing.Point(12, 398);
      this.installButton.Name = "installButton";
      this.installButton.Size = new System.Drawing.Size(314, 40);
      this.installButton.TabIndex = 8;
      this.installButton.Text = "Install";
      this.installButton.UseVisualStyleBackColor = false;
      this.installButton.Click += new System.EventHandler(this.installButton_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(800, 24);
      this.menuStrip1.TabIndex = 9;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
      this.aboutToolStripMenuItem.Text = "About";
      // 
      // aboutToolStripMenuItem1
      // 
      this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
      this.aboutToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
      this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
      this.aboutToolStripMenuItem1.Text = "About...";
      this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.installButton);
      this.Controls.Add(this.downloadLabel);
      this.Controls.Add(this.localLabel);
      this.Controls.Add(this.changeLogs);
      this.Controls.Add(this.progressBar);
      this.Controls.Add(this.releaseLabel);
      this.Controls.Add(this.playButton);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.Text = "Vainglory Crappy Launcher";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button playButton;
    private System.Windows.Forms.Label releaseLabel;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.RichTextBox changeLogs;
    private System.Windows.Forms.Label localLabel;
    private System.Windows.Forms.Label downloadLabel;
    private System.Windows.Forms.Button installButton;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
  }
}

