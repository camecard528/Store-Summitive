using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Store_Summitive
{
    public partial class Form1 : Form
    {   const double TACO = 2.99;
        const double QUESADILLA= 5.99;
        const double BURGER = 4.99;
        const double MILK = 2.50;
        const double POP = 0.99;
        const double TAX = 0.13;
        int taco;
        int quesadilla;
        int burger;
        int milk;
        int pop;
        double tendered;
        double totalPrice;

        public Form1()
        {
            InitializeComponent();
        }

        private void totalButton_Click(object sender, EventArgs e)
        {
            Graphics formgraphics = this.CreateGraphics();
            SolidBrush textBrush = new SolidBrush(Color.Black);
            Font receiptFont = new Font("Arial", 7, FontStyle.Bold);

            try
            {
                taco = Convert.ToInt32(tacoText.Text);
                quesadilla = Convert.ToInt32(lambText.Text);
                burger = Convert.ToInt32(turkeyText.Text);
                milk = Convert.ToInt32(milkText.Text);
                pop = Convert.ToInt32(popText.Text);


                //calculate cost 
                double subtotalPrice = taco * TACO + quesadilla * QUESADILLA + burger * BURGER
                    + milk * MILK + pop * POP;
                double totalTax = subtotalPrice * TAX;
                totalPrice = subtotalPrice + totalTax;

                // print prices
                subresLabel.Text = subtotalPrice.ToString("C");
                totalresLabel.Text = totalPrice.ToString("C");
                taxresLabel.Text = totalTax.ToString("C");
            }

            catch
            {
                formgraphics.DrawString("use numbers only and enter 0 if customer doesn't order",
                    receiptFont, textBrush, 305, 15);
            }
            
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            // change 
            tendered = Convert.ToDouble(tenderedText.Text);
            double change = tendered - totalPrice;
            changeresLabel.Text = change.ToString("C");


        }

        private void receiptButton_Click(object sender, EventArgs e)
        {
            SoundPlayer soundregister = new SoundPlayer(Properties.Resources.register);
            

            taco = Convert.ToInt32(tacoText.Text);
            quesadilla = Convert.ToInt32(lambText.Text);
            burger = Convert.ToInt32(turkeyText.Text);
            milk = Convert.ToInt32(milkText.Text);
            pop = Convert.ToInt32(popText.Text);

            Graphics formgraphics = this.CreateGraphics();
            SolidBrush receiptBrush = new SolidBrush(Color.White);
            SolidBrush textBrush = new SolidBrush(Color.Black);
            Font receiptFont = new Font("Arial", 7, FontStyle.Bold);
            formgraphics.FillRectangle(receiptBrush, 295, 10, 240, 365);

            formgraphics.DrawString("INDIAN GUYS BURGERS AND TACOS CO-OP", receiptFont,textBrush ,305, 15);
            formgraphics.DrawString("Tacos x" + taco, receiptFont, textBrush, 305, 25);
            formgraphics.DrawString("Quesadillas x"+  quesadilla, receiptFont, textBrush, 305, 35);
            formgraphics.DrawString("Burgers x" + burger, receiptFont, textBrush, 305, 45);
            formgraphics.DrawString("Milk x"+ milk, receiptFont, textBrush, 305, 55);
            formgraphics.DrawString("Pop x"+ pop, receiptFont, textBrush, 305, 65);
            soundregister.Play();



        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            subresLabel.Text = "";
            totalresLabel.Text = "";
            taxresLabel.Text = "";
            changeresLabel.Text = "";


        }
    }
}
