﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
         Account[] ac = new Account[3];
        private Account activeAccount = null;
        public Form1()
        {
            InitializeComponent();
            createKeypad();
            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);
        }

        private Account findAccount(int input)
        {

            for (int i = 0; i < this.ac.Length; i++)
            {
                if (ac[i].getAccountNum() == input)
                {
                    return ac[i];
                }
            }

            return null;
        }

        public bool promptForPin(int pin)
        {
            return activeAccount.checkPin(pin);
        }

        public void dispOptions(int input)
        {
            
            if (input == 1)
            {
                dispWithdraw();
            }
            else if (input == 2)
            {
                dispBalance();
            }
            else if (input == 3)
            {


            }
            else
            {

            }

        }
        
        public void dispWithdraw()
        {
            Console.WriteLine("1> 10");
            Console.WriteLine("2> 50");
            Console.WriteLine("3> 500");

            int input = 1;// = Convert.ToInt32(Console.ReadLine());

            if (input > 0 && input < 4)
            {

                //opiton one is entered by the user
                if (input == 1)
                {

                    //attempt to decrement account by 10 punds
                    if (activeAccount.decrementBalance(10))
                    {
                        //if this is possible display new balance and await key press
                        Console.WriteLine("new balance " + activeAccount.getBalance());
                        Console.WriteLine(" (prese enter to continue)");
                        //Console.ReadLine();
                    }
                    else {
                        //if this is not possible inform user and await key press
                        Console.WriteLine("insufficent funds");
                        Console.WriteLine(" (prese enter to continue)");
                        //Console.ReadLine();
                    }
                }
                else if (input == 2)
                {
                    if (activeAccount.decrementBalance(50))
                    {
                        Console.WriteLine("new balance " + activeAccount.getBalance());
                        Console.WriteLine(" (prese enter to continue)");
                        //Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("insufficent funds");
                        Console.WriteLine(" (prese enter to continue)");
                        //Console.ReadLine();
                    }
                }
                else if (input == 3)
                {
                    if (activeAccount.decrementBalance(500))
                    {
                        Console.WriteLine("new balance " + activeAccount.getBalance());
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("insufficent funds");
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                }
            }
        }
        
        public int dispBalance()
        {
            if (this.activeAccount != null)
            {
                int bal = activeAccount.getBalance();
                return bal;
            } else { return -111; };
        }

        private void createKeypad()
        {
            keypadArea.Controls.Clear();


            Button[, ] keypad = new Button[3, 3];
            int startXPos = 25;
            int startYPos = 225;
            int buttonWidth = 20;
            int buttonHeight = 20;

            BackColor = Color.DarkGray;
            displayArea.BackColor = Color.FromArgb(153, 204, 255);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    keypad[i, j] = new Button();
                    keypad[i, j].SetBounds((startXPos + (25 * i)), (startYPos + (25 * j)), buttonWidth, buttonHeight);
                    keypad[i, j].BackColor = Color.Black;
                    keypad[i, j].Visible = true;
                    keypad[i, j].TabStop = false;
                    keypad[i, j].FlatStyle = FlatStyle.Popup;
                    keypad[i, j].FlatAppearance.BorderColor = Color.Black;
                    keypad[i, j].FlatAppearance.BorderSize = 0;
                    keypad[i, j].Show();
                    keypadArea.Controls.Add(keypad[i, j]);


                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label1.Text = "enter your account number..";
            //bool submit = false;
            //while (submit == false){}
            activeAccount = findAccount(222222);
            label1.Text = "enter pin:";
            if (promptForPin(2222) == false) { label1.Text = "incorrect Pin"; }
            label1.Text="1> take out cash";
            label1.Text="2> balance";
            label1.Text="3> exit";
            dispOptions(1);

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private class Account
        {

            //the attributes for the account
            private int balance;
            private int pin;
            private int accountNum;

            // a constructor that takes initial values for each of the attributes (balance, pin, accountNumber)
            public Account(int balance, int pin, int accountNum)
            {
                this.balance = balance;
                this.pin = pin;
                this.accountNum = accountNum;
            }

            //getter and setter functions for balance
            public int getBalance()
            {
                return balance;
            }
            public void setBalance(int newBalance)
            {
                this.balance = newBalance;
            }

            /*
             *   This funciton allows us to decrement the balance of an account
             *   it perfomes a simple check to ensure the balance is greater tha
             *   the amount being debeted
             *   
             *   reurns:
             *   true if the transactions if possible
             *   false if there are insufficent funds in the account
             */
            public Boolean decrementBalance(int amount)
            {
                if (this.balance > amount)
                {
                    balance -= amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /*
             * This funciton check the account pin against the argument passed to it
             *
             * returns:
             * true if they match
             * false if they do not
             */
            public Boolean checkPin(int pinEntered)
            {
                if (pinEntered == pin)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public int getAccountNum()
            {
                return accountNum;
            }

        }

        
    }
}
