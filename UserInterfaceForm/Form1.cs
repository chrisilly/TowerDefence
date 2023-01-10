using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UserInterfaceForm
{
    public partial class Form1 : Form
    {
        public bool startButtonPressed;
        public bool buyTowerPressed;
        public bool sellTowerPressed;
        public bool fireRateUpgradePressed;
        public bool damageUpgradePressed;
        public bool projectileSpeedUpgradePressed;

        public string goldAmountLabel;

        public Form1()
        {
            InitializeComponent();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            startButtonPressed = true;
        }

        private void buyTowerButton_Click(object sender, EventArgs e)
        {
            buyTowerPressed = true;
        }

        private void sellTowerButton_Click(object sender, EventArgs e)
        {
            sellTowerPressed = true;
        }

        private void fireRateUpgradeButton_Click(object sender, EventArgs e)
        {
            fireRateUpgradePressed = true;
        }

        private void damageUpgradeButton_Click(object sender, EventArgs e)
        {
            damageUpgradePressed = true;
        }

        private void projectileSpeedUpgradeButton_Click(object sender, EventArgs e)
        {
            projectileSpeedUpgradePressed = true;
        }

        private void wealthAmountLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
