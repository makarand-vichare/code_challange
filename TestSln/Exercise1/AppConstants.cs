namespace Exercise1
{
    public class AppConstants
    {
        public const int TURN_AROUND_STEPS = 2;
        public const int MAX_FLIGHTS_ALLOWED = 50;

        public const int MAX_FLIGHTS_OF_STAIRS = 30;
        public const int MIN_FLIGHTS_OF_STAIRS = 5;

        public const int MIN_STEP_PER_STRIDE = 2;
        public const int MAX_STEP_PER_STRIDE = 5;

        public const string FLIGHTS_INPUT_INVALID = "Flights are not valid";
        public const string FLIGHTS_INPUT_NOT_INTEGER = "Flights must be number without decimal values";
        public const string FLIGHTS_INPUT_EXCEEDED_MAX_FLIGHTS_ALLOWED = "Only {0} are allowed.";
        public const string FLIGHTS_INPUT_EXCEEDED_MAX_FLIGHTS_OF_STAIRS_ALLOWED = "Flight of stairs must be between {0} and {1}.";

        public const string STEPPERSTRIDE_INPUT_INVALID = "Steps per stride is not valid";
        public const string STEPPERSTRIDE_INPUT_NOT_INTEGER = "Steps per stride must be number without decimal values";
        public const string STEPPERSTRIDE_INPUT_EXCEEDED_MAX_STEP_PER_STRIDE_ALLOWED = "Steps per stride must be between {0} and {1}.";
    }
}
