using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project02
{
    public partial class Form2 : Form
    {
        //The user's name will be stored in this variable
        string userName;

        //Create objects of the different menu items to save their different costs to
        MenuItem fruitSalad = new MenuItem();
        MenuItem pastaSalad = new MenuItem();
        MenuItem smoothie = new MenuItem();
        MenuItem fruitJuice = new MenuItem();
        MenuItem cupCake = new MenuItem();
        MenuItem shortCake = new MenuItem();

        public Form2(string form1Text)
        {
            InitializeComponent();

            //Set the username to be the text from the textbox in form 1
            userName = form1Text;

            //Set the cost of the menu items
            fruitSalad.Cost = 9.95;
            pastaSalad.Cost = 12.00;
            smoothie.Cost = 4.95;
            fruitJuice.Cost = 3.95;
            cupCake.Cost = 3.00;
            shortCake.Cost = 6.00;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Close the form when clicked
            Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //Set quantity boxes to be 0
            dessertQuantityTextBox.Text = "0";
            drinkQuantityTextBox.Text = "0";
            saladQuantityTextBox.Text = "0";

            //Set the radio buttons to false
            fruitSaladRadioButton.Checked = false;
            pastaSaladRadioButton.Checked = false;
            smoothieRadioButton.Checked = false;
            fruitJuiceRadioButton.Checked = false;
            cupCakeRadioButton.Checked = false;
            shortCakeRadioButton.Checked = false;

            //Set price boxes to be 0
            drinkPriceTextBox.Text = "0";
            saladPriceTextBox.Text = "0";
            dessertPriceTextBox.Text = "0";

            //Set the labels to be invisible
            drinksLabel.Visible = false;
            dessertsLabel.Visible = false;
            saladsLabel.Visible = false;

            //Set the message box to be empty
            messageBox.Text = "";
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            //The costs from the 3 sections will be added together in this variable
            double overallCost = 0;

            //Check to see if correct information was entered
            bool dataIsCorrect = false;
            dataIsCorrect = checkForInts(saladQuantityTextBox.Text, drinkQuantityTextBox.Text, dessertQuantityTextBox.Text);

            //If the data entered were ints, execute the calcualtion. Otherwise, prompt for correct data
            if (dataIsCorrect)
            {
                //Save the cost of the salads into a variable
                double totalSaladCost = 0;
                if (fruitSaladRadioButton.Checked == true)
                {
                    totalSaladCost = (Int32.Parse(saladQuantityTextBox.Text)) * fruitSalad.Cost;
                }
                else if (pastaSaladRadioButton.Checked == true)
                {
                    totalSaladCost = (Int32.Parse(saladQuantityTextBox.Text)) * pastaSalad.Cost;
                }

                //Save the costs of the drinks into a variable
                double totaldrinkCost = 0;
                if (smoothieRadioButton.Checked == true)
                {
                    totaldrinkCost = (Int32.Parse(drinkQuantityTextBox.Text)) * smoothie.Cost;
                }
                else if (fruitJuiceRadioButton.Checked == true)
                {
                    totaldrinkCost = (Int32.Parse(drinkQuantityTextBox.Text)) * fruitJuice.Cost;
                }

                //Save the costs of all the desserts into a variable
                double totalDessertCost = 0;
                if (cupCakeRadioButton.Checked == true)
                {
                    totalDessertCost = (Int32.Parse(dessertQuantityTextBox.Text)) * cupCake.Cost;
                }
                else if (shortCakeRadioButton.Checked == true)
                {
                    totalDessertCost = (Int32.Parse(dessertQuantityTextBox.Text)) * shortCake.Cost;
                }

                //Save the total cost of the purchase
                overallCost = totalDessertCost + totaldrinkCost + totalSaladCost;

                //Save the number of items bought
                int itemsBought = Convert.ToInt32(saladQuantityTextBox.Text) + Convert.ToInt32(drinkQuantityTextBox.Text) + Convert.ToInt32(dessertQuantityTextBox.Text);

                //Display the message
                messageBox.Text = ("The total sales was " + overallCost.ToString("C") + "\r\n" +
                    "The total items sold were " + itemsBought.ToString() + "\r\n \r\n" +
                    userName + ", Thank you for your purchase.");
            }
            else
            {
                messageBox.Text = ("Make sure to enter integers for your quantities");
            }
        }

        private void fruitSaladRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Display the label under the salad group box
            saladsLabel.Text = "Salads Selection: Fruit Salad";
            saladsLabel.Visible = true;
            saladPriceTextBox.Text = fruitSalad.Cost.ToString("C");

            //selects the quantity text box when the radio button is used for easy entry of data
            saladQuantityTextBox.Focus();
            saladQuantityTextBox.SelectAll();
        }

        private void pastaSaladRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Display the label under the salad group box
            saladsLabel.Text = "Salads Selection: Pasta Salad";
            saladsLabel.Visible = true;
            saladPriceTextBox.Text = pastaSalad.Cost.ToString("C");

            //selects the quantity text box when the radio button is used for easy entry of data
            saladQuantityTextBox.Focus();
            saladQuantityTextBox.SelectAll();
        }

        private void smoothieRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Display the label under the drink group box
            drinksLabel.Text = "Drinks Selection: Smoothie";
            drinksLabel.Visible = true;
            drinkPriceTextBox.Text = smoothie.Cost.ToString("C");

            //selects the quantity text box when the radio button is used for easy entry of data
            drinkQuantityTextBox.Focus();
            drinkQuantityTextBox.SelectAll();
        }

        private void fruitJuiceRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Display the label under the drink group box
            drinksLabel.Text = "Drinks Selection: Fruit Juice";
            drinksLabel.Visible = true;
            drinkPriceTextBox.Text = fruitJuice.Cost.ToString("C");

            //selects the quantity text box when the radio button is used for easy entry of data
            drinkQuantityTextBox.Focus();
            drinkQuantityTextBox.SelectAll();
        }

        private void cupCakeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Display the label under the dessert group box
            dessertsLabel.Text = "Desserts Selection: Cupcake";
            dessertsLabel.Visible = true;
            dessertPriceTextBox.Text = cupCake.Cost.ToString("C");

            //selects the quantity text box when the radio button is used for easy entry of data
            dessertQuantityTextBox.Focus();
            dessertQuantityTextBox.SelectAll();
        }

        private void shortCakeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Display the label under the dessert group box
            dessertsLabel.Text = "Desserts Selection: Shortcake";
            dessertsLabel.Visible = true;
            dessertPriceTextBox.Text = shortCake.Cost.ToString("C");

            //selects the quantity text box when the radio button is used for easy entry of data
            dessertQuantityTextBox.Focus();
            dessertQuantityTextBox.SelectAll();
        }

        private void saladQuantityTextBox_Click(object sender, EventArgs e)
        {
            //When the textbox is selected, this will highlight the data so you don't have to backspace to delete it
            saladQuantityTextBox.SelectAll();
        }

        private void drinkQuantityTextBox_Click(object sender, EventArgs e)
        {
            //When the textbox is selected, this will highlight the data so you don't have to backspace to delete it
            drinkQuantityTextBox.SelectAll();
        }

        private void dessertQuantityTextBox_Click(object sender, EventArgs e)
        {
            //When the textbox is selected, this will highlight the data so you don't have to backspace to delete it
            dessertQuantityTextBox.SelectAll();
        }

        //Method to ensure that data entered into the text boxes were ints
        private bool checkForInts(string salad, string drink, string dessert)
        {
            bool isInt = false;
            int result;
            bool isValidSalad = int.TryParse(salad, out result);
            bool isValidDrink = int.TryParse(drink, out result);
            bool isValidDessert = int.TryParse(dessert, out result);

            //If all 3 values are ints, set the bool to be true
            if (isValidSalad == true && isValidDrink == true && isValidDessert == true)
            {
                isInt = true;
            }
            else
            {
                isInt = false;
            }

            return isInt;
        }
    }

    //Create a class to make menue items from
    public class MenuItem
    {
        public double Cost { get; set; }

    }

}
