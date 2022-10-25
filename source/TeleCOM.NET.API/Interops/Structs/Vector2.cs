
namespace TeleCOM.NET.API.Interops.Structs
{
    //In the future there will be a proper vector implementation of operators and
    //overall vector functions
    internal sealed class Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2(int x, int y) 
        {
            X = x;
            Y = y;
        }
    }
}
