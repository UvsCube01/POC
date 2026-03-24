namespace Test
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Fires only when the Calculate button is clicked
        private void OnCalculateClicked(object sender, EventArgs e)
        {
            // Determine which operation is selected
            string operation;
            if (AddRadio.IsChecked)
                operation = "Add";
            else if (SubtractRadio.IsChecked)
                operation = "Subtract";
            else if (MultiplyRadio.IsChecked)
                operation = "Multiply";
            else if (DivideRadio.IsChecked)
                operation = "Divide";
            else
            {
                ResultEntry.Text = "Please select an operation";
                return;
            }

            // Validate inputs
            if (!double.TryParse(FirstNumberEntry.Text, out double num1))
            {
                ResultEntry.Text = "Invalid first number";
                return;
            }

            if (!double.TryParse(SecondNumberEntry.Text, out double num2))
            {
                ResultEntry.Text = "Invalid second number";
                return;
            }

            double result;

            switch (operation)
            {
                case "Add":
                    result = num1 + num2;
                    break;
                case "Subtract":
                    result = num1 - num2;
                    break;
                case "Multiply":
                    result = num1 * num2;
                    break;
                case "Divide":
                    if (num2 == 0)
                    {
                        ResultEntry.Text = "Cannot divide by zero";
                        return;
                    }
                    result = num1 / num2;
                    break;
                default:
                    ResultEntry.Text = string.Empty;
                    return;
            }

            // Display the result, trimming unnecessary trailing zeros
            ResultEntry.Text = result.ToString("G10");
        }
    }
}
