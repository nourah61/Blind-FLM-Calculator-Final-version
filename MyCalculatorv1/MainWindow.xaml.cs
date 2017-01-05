

using System;
using System.Windows;
using System.Windows.Controls;

namespace MyCalculatorv1
{
  
    public partial class MainWindow : Window
    {
        String ope = "";

        Double DT = 0;

      Double F = 0;

      Double M = 0;

      Double S = 0;

      Double T = 0;
        

        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button) sender;

            ope = b.Content.ToString();
            tb.Text += ope;
            switch(ope)
           {
                case"D":
                    DT += 0.62;
                break;
                case"F":
                    F += 0.12;
                break;
                case"M":
                    M += 1.35;
                break;
                case"S":
                    S += 0.17;
                break;
                case"T":
                    T += 0.31;
                break;

            }
           
        }

        private void Result_click(object sender, RoutedEventArgs e)
        {
            try
            {
                result();
            }
            catch (Exception exc)
            {
                tb.Text = "Error!";
            }
        }

        private void result()
        {

            Result.Text = "";
            DT= 0;

            F = 0;

            M = 0;

            S = 0;

            T = 0;

            int sequenceLength = tb.Text.Length;
            int counter = 0;
            String sequence = tb.Text;
            String MentalSequence = "";

            // The first case where the auto mental construction checkbox is not checked
    if (Auto.IsChecked == false) { 
                    while (sequenceLength > 0)
                    {
                        char operators = sequence[counter];
                        switch (operators)
                        {
                            case 'D':
                            DT+= 0.62;
                                break;
                            case 'F':
                                F += 0.12;
                                break;
                            case 'M':
                                M += 1.35;
                                break;
                            case 'S':
                                S += 0.17;
                                break;
                            case 'T':
                                T += 0.31;
                                break;

                        } //end of switch cluase
                        counter++;
                        sequenceLength--;
                    }  // end of while loop
                    Result.Text += " = " + (DT+ F + M + S + T) + " Sec.";
                } // end of if statement
           // The second case where the auto mental construction checkbox is  checked
     else
      {
                // Mental operator inerstion

                char[] a = sequence.ToCharArray();
                char[] b = new char[(a.Length * 2)];

                int bIndex = 1;
                b[0] = 'M';
                for (int i = 0; i < a.Length; i++)
                {

                    b[bIndex++] = a[i];
                    //Insert a white space after the char
                    if (i < (a.Length - 1))
                    {
                        b[bIndex++] = 'M';
                    }
                }
                // writting operators's sequence to the textbox
                string mentals = new string(b);
                tb.Text = "";
                tb.Text +=  mentals;
                Auto.IsChecked = false;       

            } //end of else cluase
               
                }

        private void Off_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        // Delete input textbox and output textbox
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
            Result.Text = "";
             DT = 0;

             F = 0;

             M = 0;

             S = 0;

             T = 0;
        }

        private void MentalDisable(object sender, RoutedEventArgs e)
        {
            Mental.IsEnabled = false;
        }

        private void MentalEnabled(object sender, RoutedEventArgs e)
        {
            Mental.IsEnabled = true;
        }



      
    }
}
