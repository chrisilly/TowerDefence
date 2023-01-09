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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buyTowerButton
            // 
            this.buyTowerButton.Location = new System.Drawing.Point(140, 58);
            this.buyTowerButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buyTowerButton.Name = "buyTowerButton";
            this.buyTowerButton.Size = new System.Drawing.Size(28, 18);
            this.buyTowerButton.TabIndex = 0;
            this.buyTowerButton.Text = "Buy";
            this.buyTowerButton.UseVisualStyleBackColor = true;
            this.buyTowerButton.Click += new System.EventHandler(this.buyTowerButton_Click);
            // 
            // sellTowerButton
            // 
            this.sellTowerButton.Location = new System.Drawing.Point(250, 58);
            this.sellTowerButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.sellTowerButton.Name = "sellTowerButton";
            this.sellTowerButton.Size = new System.Drawing.Size(28, 18);
            this.sellTowerButton.TabIndex = 1;
            this.sellTowerButton.Text = "Sell";
            this.sellTowerButton.UseVisualStyleBackColor = true;
            this.sellTowerButton.Click += new System.EventHandler(this.sellTowerButton_Click);
            // 
            // fireRateUpgradeButton
            // 
            this.fireRateUpgradeButton.Location = new System.Drawing.Point(140, 115);
            this.fireRateUpgradeButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.fireRateUpgradeButton.Name = "fireRateUpgradeButton";
            this.fireRateUpgradeButton.Size = new System.Drawing.Size(49, 18);
            this.fireRateUpgradeButton.TabIndex = 2;
            this.fireRateUpgradeButton.Text = "Fire rate";
            this.fireRateUpgradeButton.UseVisualStyleBackColor = true;
            this.fireRateUpgradeButton.Click += new System.EventHandler(this.fireRateUpgradeButton_Click);
            // 
            // projectileSpeedUpgradeButton
            // 
            this.projectileSpeedUpgradeButton.Location = new System.Drawing.Point(140, 148);
            this.projectileSpeedUpgradeButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.projectileSpeedUpgradeButton.Name = "projectileSpeedUpgradeButton";
            this.projectileSpeedUpgradeButton.Size = new System.Drawing.Size(138, 18);
            this.projectileSpeedUpgradeButton.TabIndex = 3;
            this.projectileSpeedUpgradeButton.Text = "Projectile Speed";
            this.projectileSpeedUpgradeButton.UseVisualStyleBackColor = true;
            this.projectileSpeedUpgradeButton.Click += new System.EventHandler(this.projectileSpeedUpgradeButton_Click);
            // 
            // damageUpgradeButton
            // 
            this.damageUpgradeButton.Location = new System.Drawing.Point(229, 115);
            this.damageUpgradeButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.damageUpgradeButton.Name = "damageUpgradeButton";
            this.damageUpgradeButton.Size = new System.Drawing.Size(49, 18);
            this.damageUpgradeButton.TabIndex = 4;
            this.damageUpgradeButton.Text = "Damage";
            this.damageUpgradeButton.UseVisualStyleBackColor = true;
            this.damageUpgradeButton.Click += new System.EventHandler(this.damageUpgradeButton_Click);
            // 
            // wealthLabel
            // 
            this.wealthLabel.AutoSize = true;
            this.wealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wealthLabel.Location = new System.Drawing.Point(12, 47);
            this.wealthLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.wealthLabel.Name = "wealthLabel";
            this.wealthLabel.Size = new System.Drawing.Size(71, 29);
            this.wealthLabel.TabIndex = 5;
            this.wealthLabel.Text = "Gold:";
            // 
            // wealthAmountLabel
            // 
            this.wealthAmountLabel.AutoSize = true;
            this.wealthAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wealthAmountLabel.Location = new System.Drawing.Point(79, 47);
            this.wealthAmountLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.wealthAmountLabel.Name = "wealthAmountLabel";
            this.wealthAmountLabel.Size = new System.Drawing.Size(51, 29);
            this.wealthAmountLabel.TabIndex = 6;
            this.wealthAmountLabel.Text = "null";
            // 
            // towerSelectionInstructionLabel
            // 
            this.towerSelectionInstructionLabel.AutoSize = true;
            this.towerSelectionInstructionLabel.Location = new System.Drawing.Point(137, 36);
            this.towerSelectionInstructionLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.towerSelectionInstructionLabel.Name = "towerSelectionInstructionLabel";
            this.towerSelectionInstructionLabel.Size = new System.Drawing.Size(147, 13);
            this.towerSelectionInstructionLabel.TabIndex = 7;
            this.towerSelectionInstructionLabel.Text = "(Select tower to sell or modify)";
            // 
            // modifiersLabel
            // 
            this.modifiersLabel.AutoSize = true;
            this.modifiersLabel.Location = new System.Drawing.Point(163, 91);
            this.modifiersLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.modifiersLabel.Name = "modifiersLabel";
            this.modifiersLabel.Size = new System.Drawing.Size(93, 13);
            this.modifiersLabel.TabIndex = 8;
            this.modifiersLabel.Text = "Increase Modifiers";
            // 
            // startGameButton
            // 
            this.startGameButton.Location = new System.Drawing.Point(32, 18);
            this.startGameButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(70, 21);
            this.startGameButton.TabIndex = 9;
            this.startGameButton.Text = "Start Game";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tower";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 205);
            this.Controls.Add(this.label1);
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
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
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
        private System.Windows.Forms.Label label1;
    }
}

