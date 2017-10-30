using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalculator
{
    public partial class Form1 : Form
    {
        float fPrviBroj;
        float fDrugiBroj;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fPrviBroj = Convert.ToSingle(inptFirstNumber.Value);
            fDrugiBroj = Convert.ToSingle(inptSecondNumber.Value);
            inptResult.Text = Convert.ToString(fPrviBroj + fDrugiBroj);
        }

        private void btnSubstract_Click(object sender, EventArgs e)
        {
            fPrviBroj = Convert.ToSingle(inptFirstNumber.Value);
            fDrugiBroj = Convert.ToSingle(inptSecondNumber.Value);
            inptResult.Text = Convert.ToString(fPrviBroj - fDrugiBroj);
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            fPrviBroj = Convert.ToSingle(inptFirstNumber.Value);
            fDrugiBroj = Convert.ToSingle(inptSecondNumber.Value);
            inptResult.Text = Convert.ToString(fPrviBroj * fDrugiBroj);
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            fPrviBroj = Convert.ToSingle(inptFirstNumber.Value);
            fDrugiBroj = Convert.ToSingle(inptSecondNumber.Value);
            inptResult.Text = Convert.ToString(fPrviBroj / fDrugiBroj);
        }
    }
}
