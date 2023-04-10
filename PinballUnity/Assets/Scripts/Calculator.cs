namespace Count
{
    public class Calculator
    {
        float x;
        float y;
        char pointer;

        public Calculator(float x, float y, char pointer)
        {
            this.x = x;
            this.y = y;
            this.pointer = pointer;
        }

        public float ScoreCount()
        {
            float _value = 0;

            switch (pointer)
            {
                case '+':
                    _value = x + y;
                    break;
                case '-':
                    _value = x - y;
                    break;
                case '*':
                    _value = x * y;
                    break;
                case '/':
                    _value = (x / y);
                    break;

                default:
                    break;
            }


            return _value;
        }
    }
}
