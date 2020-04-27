namespace NamespaceSQ
{
    public class SQ
    {
        protected double[] array;
        protected int max;

        public SQ()
        {
            max = 100;
            array = new double[max];
        }
        public SQ(int max)
        {
            this.max = max;
            array = new double[max];
        }

        public bool IsFull()
        {
            return false;
        }
        public bool IsEmpty()
        {
            return false;
        }

        public void Push(double number) 
        { 

        }
        public double Pop()
        {
            return 0;
        }
        public double Top()
        {
            return 0;
        }
    }
}
