﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tab_pascal
{
    public partial class Form1 : Form
    {
        public int numberOfTable;
        public Form1()
        {
            InitializeComponent();
           
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            for (int i = 0; i < numberOfTable; i++)
            {
                dataGridView1.Rows[i].Height = 20;



            }
            for (int i = 0; i < 2 * numberOfTable - 1; i++)
            {

                dataGridView1.Columns[i].Width = 20;

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            numberOfTable = Convert.ToInt32(textBox1.Text);
            dataGridView1.ColumnCount = 2*numberOfTable-1;
            dataGridView1.RowCount = numberOfTable;
            int[,] mass = new int[2*numberOfTable-1, numberOfTable];

           
            
            dataGridView1.Rows[0].Cells[numberOfTable-1].Value = mass[numberOfTable-1,0]=1;
            for (int i = 1; i < numberOfTable; i++)
            {
                for (int j = 0; j < 2*numberOfTable-1; j++)
                {
                    if (j >0&&j<2*numberOfTable-2)
                        {
                        if ((mass[j+1,i-1] != 0) || (mass[j-1,i-1] != 0))
                        {
                            if ((mass[j + 1, i - 1] != 0) && (mass[j - 1, i - 1] != 0))
                            {
                                mass[j,i] = mass[j + 1, i - 1] + mass[j - 1, i - 1];
                            }
                            else 
                                {
                               mass[j,i] = 1;
                            }
                        }
                        
                    }
                    else
                    {
                        mass[0,numberOfTable-1] = 1;
                        mass[2*numberOfTable-2,numberOfTable-1] = 1;
                       
                    }
                    if (mass[j, i] != 0)
                    {
                        
                    
                   dataGridView1.Rows[i].Cells[j].Value = mass[j, i];
                        }
                }
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i =0;i< numberOfTable;i++)
            {
                for(int j=0;j<2*numberOfTable-1;j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = null;
                    
                }
            }
        }
    }
}
