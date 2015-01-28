using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrianglePuzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //define some variables
            int maximumSum = 0; //our answer
            int position = 0; //the position of the number chosen from each line for our sum
            int lineCounter = 0; //which line of the triangle are we working with
            int numberCount = 0; //which number in a line are we working
            int[][] triangleArray = new int[100][]; //an array to hold each our lines
            string filename = "";

            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open Triangle File";
            fDialog.Filter = "TXT Files|*.txt";
            fDialog.InitialDirectory = @"C:\";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                filename = fDialog.FileName.ToString();
            }

            if (filename != null)
            {
                foreach (string line in File.ReadLines(filename))
                {

                    int[] tempArray = new int[lineCounter + 1]; //if we start counting with line zero, then each line contains one more number than it's designation

                    string[] numbers = line.Trim().Split(' '); //split the line into its component numbers so we can work with them

                    numberCount = 0;
                    foreach (string number in numbers) //read the numbers into an array
                    {
                        tempArray[numberCount] = Convert.ToInt32(number);
                    }

                    triangleArray[lineCounter] = tempArray; //add our array for this line into our array for the entire triangle
                    lineCounter++; //keep track of which line we're reading
                }

                foreach (int[] lineArray in triangleArray)
                {
                    if ((position > 0) && (lineArray[position] < lineArray[position + 1]))
                    {
                        maximumSum = maximumSum + lineArray[position + 1];
                    }
                    else
                    {
                        maximumSum = maximumSum + lineArray[position];
                    }


                }

                MessageBox.Show(maximumSum.ToString(), "Maximum Possible Sum");

            }

        }


    }
}
