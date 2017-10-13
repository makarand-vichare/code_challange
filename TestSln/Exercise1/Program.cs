namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stairCase = UserInput.GetValidUserInput();
            var result = UserInput.CalculateStepsForTop(stairCase);
            UserInput.DisplayResult(result);
        }
    }
}
