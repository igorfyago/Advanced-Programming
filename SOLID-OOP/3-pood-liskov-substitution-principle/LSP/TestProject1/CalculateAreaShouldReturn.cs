using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShapeTests
{
    [TestClass]
    public class CalculateAreaShouldReturn
    {
        [TestMethod]
        public void SixFor2X3Rectangle()
        {
            var myRectangle = new Rectangle { Height = 2, Width = 3 };
            Assert.AreEqual(6, AreaCalculator.CalculateArea(myRectangle));
        }

        [TestMethod]
        public void NineFor3X3Square()
        {
            var mySquare = new Square() { Height = 3 };
            Assert.AreEqual(9, AreaCalculator.CalculateArea(mySquare));
        }

        [TestMethod]
        public void TwentyFor4X5RectangleFromSquare()
        {
            Rectangle newRectangle = new Square();
            newRectangle.Width = 4;
            newRectangle.Height = 5;
            Assert.AreEqual(20, AreaCalculator.CalculateArea(newRectangle));
        }
    }
    
    public class AreaCalculator
    {
        public static int CalculateArea(Rectangle r)
        {
            return r.Height * r.Width;
        }

        public static int CalculateArea(Square s)
        {
            return s.Height * s.Height;
        }
    }

    public class Rectangle
    {
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
    }

    public class Square : Rectangle
    {
        private int _height;
        private int _width;

        public override int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                _height = value;
            }
        }

        public override int Height
        {
            get { return _height; }
            set
            {
                _width = value;
                _height = value;
            }
        }
    }

}

#region Later

//public class Rectangle
//{
//    public virtual int Height { get; set; }
//    public virtual int Width { get; set; }

//    public bool IsSquare()
//    {
//        return Height == Width;
//    }
//}


#endregion