namespace JPS
{
    internal static class Fruits
    {


        internal static string GetFruit(int fruitId)
        {
            switch (fruitId)
            {
                case 0:
                    return "Apple";

                case 1:
                    return "Banana";

                case 2:
                    return "Cherry";

                case 3:
                    return "Date";

                default:
                    return "Pineapple";

            }
        }


    }
}
