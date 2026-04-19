namespace Fourier
{
    static class Program
    {
        public static void Main()
        {
            List<sbyte> test = new List<sbyte>();

            for (int i = 0; i < 1024; ++i)
            {
                var tmp = i / 10.0f;

                test.Add((sbyte)(MathF.Sin(tmp) * 120));
            }

            AudioFile file = new AudioFile(test.ToArray());
             
        }
    }
}