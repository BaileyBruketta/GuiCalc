using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuiCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string InputText       ;
        public int    currentOperator ;
        public double firstNumber     ;
        public double secondNumber    ;
        public double outputNumber    ;
        public bool   operatorClicked ;
        public MainWindow()
        {
            InitializeComponent()     ;
            InputText       = ""      ;
            operatorClicked = false   ;
        }

        //retreive keyboard input
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if      (e.Key == Key.D0)       { Button_Click         (sender, e)  ; }
            else if (e.Key == Key.NumPad0)  { Button_Click         (sender, e)  ; }
            else if (e.Key == Key.D1)       { Bt1_Click            (sender, e)  ; }
            else if (e.Key == Key.NumPad1)  { Bt1_Click            (sender, e)  ; }
            else if (e.Key == Key.D2)       { Bt2_Click            (sender, e)  ; }
            else if (e.Key == Key.NumPad2)  { Bt2_Click            (sender, e)  ; }
            else if (e.Key == Key.D3)       { Bt3_Click            (sender, e)  ; }
            else if (e.Key == Key.NumPad3)  { Bt3_Click            (sender, e)  ; }
            else if (e.Key == Key.D4)       { Bt4_Click            (sender, e)  ; }
            else if (e.Key == Key.NumPad4)  { Bt4_Click            (sender, e)  ; }
            else if (e.Key == Key.D5)       { Bt5_Click            (sender, e)  ; }
            else if (e.Key == Key.NumPad5)  { Bt5_Click            (sender, e)  ; }
            else if (e.Key == Key.D6)       { Bt6_Click            (sender, e)  ; }
            else if (e.Key == Key.NumPad6)  { Bt6_Click            (sender, e)  ; }
            else if (e.Key == Key.D7)       { Bt7_Click            (sender, e)  ; }
            else if (e.Key == Key.NumPad7)  { Bt7_Click            (sender, e)  ; }
            else if (e.Key == Key.D8)       { Bt8_Click            (sender, e)  ; }
            else if (e.Key == Key.NumPad8)  { Bt8_Click            (sender, e)  ; }
            else if (e.Key == Key.D9)       { Bt9_Click            (sender, e)  ; }
            else if (e.Key == Key.NumPad9)  { Bt9_Click            (sender, e)  ; }
            else if (e.Key == Key.Add)      { PlusButton_Click     (sender, e)  ; }
            else if (e.Key == Key.Subtract) { MinusButton_Click    (sender, e)  ; }
            else if (e.Key == Key.Divide)   { DivButton_Click      (sender, e)  ; }
            else if (e.Key == Key.Multiply) { MultButton_Click     (sender, e)  ; }
            else if (e.Key == Key.Enter)    { EqualButton_Click    (sender, e)  ; }
            else if (e.Key == Key.N)        { Negativebutton_Click (sender, e)  ; }
            else if (e.Key == Key.C)        { ClearButton_Click    (sender, e)  ; }

        }
        //*********************************************************************

        
        //*** *** *** *** *** numbers *** *** *** *** *** *** *** ***          ---   --- 
        private void Button_Click(object sender, RoutedEventArgs e) {InputText += "0";ChangeText();}
        private void Bt1_Click(object sender, RoutedEventArgs e)    {InputText += "1";ChangeText();}
        private void Bt2_Click(object sender, RoutedEventArgs e)    {InputText += "2";ChangeText();}
        private void Bt3_Click(object sender, RoutedEventArgs e)    {InputText += "3";ChangeText();}
        private void Bt4_Click(object sender, RoutedEventArgs e)    {InputText += "4";ChangeText();}
        private void Bt5_Click(object sender, RoutedEventArgs e)    {InputText += "5";ChangeText();}
        private void Bt6_Click(object sender, RoutedEventArgs e)    {InputText += "6";ChangeText();}
        private void Bt7_Click(object sender, RoutedEventArgs e)    {InputText += "7";ChangeText();}
        private void Bt8_Click(object sender, RoutedEventArgs e)    {InputText += "8";ChangeText();}
        private void Bt9_Click(object sender, RoutedEventArgs e)    {InputText += "9";ChangeText();}
        // decimal button
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            if (InputText.Contains('.') == false) { InputText += "."; ChangeText(); }
        }
        //*** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearText();
        }
        //************************** operators ********************************

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            currentOperator = 0; modeBox.Text = "Addition"       ; ClickOperator();
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            currentOperator = 1; modeBox.Text = "Subtraction"    ; ClickOperator();           
        }

        private void MultButton_Click(object sender, RoutedEventArgs e)
        {
            currentOperator = 2; modeBox.Text = "Multiplication" ; ClickOperator();
        }

        private void DivButton_Click(object sender, RoutedEventArgs e)
        {
            currentOperator = 3; modeBox.Text = "Division"       ; ClickOperator();
        }

        private void ClickOperator() {if (operatorClicked == false) { DisplayInput_PrepCalculation(); } operatorClicked = true;}
        //******************************* equals ***********************************
        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            if (operatorClicked == true)
            {
                if (InputText != "")
                {
                    secondNumber = System.Convert.ToDouble(InputText);
                    if (currentOperator == 0) { outputNumber = firstNumber + secondNumber; }
                    else if (currentOperator == 1) { outputNumber = firstNumber - secondNumber; }
                    else if (currentOperator == 2) { outputNumber = firstNumber * secondNumber; }
                    else if (currentOperator == 3) { outputNumber = firstNumber / secondNumber; }

                    ClearText();
                    DisplayOutput();
                }
            }
            else { outputNumber = System.Convert.ToDouble(InputText); DisplayOutput(); }
        }
        // **********************************************************
        private void ChangeText() {entryBox.Text = InputText;}
        private void ClearText()  {entryBox.Text = ""; InputText = "";}

        private void DisplayInput_PrepCalculation()
        {
            firstNumber = System.Convert.ToDouble(InputText);
            answerBox.Text = InputText;
            ClearText();
        }

        private void DisplayOutput()
        {
            answerBox.Text  = System.Convert.ToString(outputNumber);
            InputText       = answerBox.Text;
            entryBox.Text   = InputText;
            operatorClicked = false;
            modeBox.Text    = "";
        }

        private void Negativebutton_Click(object sender, RoutedEventArgs e)
        {
            if      (InputText.Contains('-') == false) { InputText = "-" + InputText          ; }
            else if (InputText.Contains("-") == true ) { InputText = InputText.Replace("-",""); }
            ChangeText();
            HideWindow();
            
        }

        private void HideWindow() { textBlock1.Visibility = Visibility.Hidden; }
    }
}
