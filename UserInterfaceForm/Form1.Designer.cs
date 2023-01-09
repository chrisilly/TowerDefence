namespace UserInterfaceForm
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
            this.buyTowerButton = new System.Windows.Forms.Button();
            this.sellTowerButton = new System.Windows.Forms.Button();
            this.fireRateUpgradeButton = new System.Windows.Forms.Button();
            this.projectileSpeedUpgradeButton = new System.Windows.Forms.Button();
            this.damageUpgradeButton = new System.Windows.Forms.Button();
            this.wealthLabel = new System.Windows.Forms.Label();
            this.wealthAmountLabel = new System.Windows.Forms.Label();
            this.towerSelectionInstructionLabel = new System.Windows.Forms.Label();
            this.modifiersLabel = new System.Windows.Forms.Label();
            this.startGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buyTowerButton
            // 
            this.buyTowerButton.Location = new System.Drawing.Point(387, 125);
            this.buyTowerButton.Name = "buyTowerButton";
            this.buyTowerButton.Size = new System.Drawing.Size(75, 43);
            this.buyTowerButton.TabIndex = 0;
            this.buyTowerButton.Text = "Buy";
            this.buyTowerButton.UseVisualStyleBackColor = true;
            this.buyTowerButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // sellTowerButton
            // 
            this.sellTowerButton.Location = new System.Drawing.Point(681, 125);
            this.sellTowerButton.Name = "sellTowerButton";
            this.sellTowerButton.Size = new System.Drawing.Size(75, 43);
            this.sellTowerButton.TabIndex = 1;
            this.sellTowerButton.Text = "Sell";
            this.sellTowerButton.UseVisualStyleBackColor = true;
            // 
            // fireRateUpgradeButton
            // 
            this.fireRateUpgradeButton.Location = new System.Drawing.Point(387, 261);
            this.fireRateUpgradeButton.Name = "fireRateUpgradeButton";
            this.fireRateUpgradeButton.Size = new System.Drawing.Size(131, 43);
            this.fireRateUpgradeButton.TabIndex = 2;
            this.fireRateUpgradeButton.Text = "Fire rate";
            this.fireRateUpgradeButton.UseVisualStyleBackColor = true;
            // 
            // projectileSpeedUpgradeButton
            // 
            this.projectileSpeedUpgradeButton.Location = new System.Drawing.Point(387, 340);
            this.projectileSpeedUpgradeButton.Name = "projectileSpeedUpgradeButton";
            this.projectileSpeedUpgradeButton.Size = new System.Drawing.Size(369, 43);
            this.projectileSpeedUpgradeButton.TabIndex = 3;
            this.projectileSpeedUpgradeButton.Text = "Projectile Speed";
            this.projectileSpeedUpgradeButton.UseVisualStyleBackColor = true;
            // 
            // damageUpgradeButton
            // 
            this.damageUpgradeButton.Location = new System.Drawing.Point(625, 261);
            this.damageUpgradeButton.Name = "damageUpgradeButton";
            this.damageUpgradeButton.Size = new System.Drawing.Size(131, 43);
            this.damageUpgradeButton.TabIndex = 4;
            this.damageUpgradeButton.Text = "Damage";
            this.damageUpgradeButton.UseVisualStyleBackColor = true;
            // 
            // wealthLabel
            // 
            this.wealthLabel.AutoSize = true;
            this.wealthLabel.Location = new System.Drawing.Point(97, 203);
            this.wealthLabel.Name = "wealthLabel";
            this.wealthLabel.Size = new System.Drawing.Size(83, 32);
            this.wealthLabel.TabIndex = 5;
            this.wealthLabel.Text = "Gold:";
            this.wealthLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // wealthAmountLabel
            // 
            this.wealthAmountLabel.AutoSize = true;
            this.wealthAmountLabel.Location = new System.Drawing.Point(187, 202);
            this.wealthAmountLabel.Name = "wealthAmountLabel";
            this.wealthAmountLabel.Size = new System.Drawing.Size(60, 32);
            this.wealthAmountLabel.TabIndex = 6;
            this.wealthAmountLabel.Text = "null";
            // 
            // towerSelectionInstructionLabel
            // 
            this.towerSelectionInstructionLabel.AutoSize = true;
            this.towerSelectionInstructionLabel.Location = new System.Drawing.Point(381, 63);
            this.towerSelectionInstructionLabel.Name = "towerSelectionInstructionLabel";
            this.towerSelectionInstructionLabel.Size = new System.Drawing.Size(375, 32);
            this.towerSelectionInstructionLabel.TabIndex = 7;
            this.towerSelectionInstructionLabel.Text = "Select tower to sell or modify";
            this.towerSelectionInstructionLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // modifiersLabel
            // 
            this.modifiersLabel.AutoSize = true;
            this.modifiersLabel.Location = new System.Drawing.Point(450, 203);
            this.modifiersLabel.Name = "modifiersLabel";
            this.modifiersLabel.Size = new System.Drawing.Size(245, 32);
            this.modifiersLabel.TabIndex = 8;
            this.modifiersLabel.Text = "Increase Modifiers";
            // 
            // startGameButton
            // 
            this.startGameButton.Location = new System.Drawing.Point(83, 53);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(188, 50);
            this.startGameButton.TabIndex = 9;
            this.startGameButton.Text = "Start Game";
            this.startGameButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.modifiersLabel);
            this.Controls.Add(this.towerSelectionInstructionLabel);
            this.Controls.Add(this.wealthAmountLabel);
            this.Controls.Add(this.wealthLabel);
            this.Controls.Add(this.damageUpgradeButton);
            this.Controls.Add(this.projectileSpeedUpgradeButton);
            this.Controls.Add(this.fireRateUpgradeButton);
            this.Controls.Add(this.sellTowerButton);
            this.Controls.Add(this.buyTowerButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buyTowerButton;
        private System.Windows.Forms.Button sellTowerButton;
        private System.Windows.Forms.Button fireRateUpgradeButton;
        private System.Windows.Forms.Button projectileSpeedUpgradeButton;
        private System.Windows.Forms.Button damageUpgradeButton;
        private System.Windows.Forms.Label wealthLabel;
        private System.Windows.Forms.Label wealthAmountLabel;
        private System.Windows.Forms.Label towerSelectionInstructionLabel;
        private System.Windows.Forms.Label modifiersLabel;
        private System.Windows.Forms.Button startGameButton;
    }
}

