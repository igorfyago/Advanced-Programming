using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShapeTests
{
    [TestClass]
    public class TellDontAsk_ShapesShouldReturn
    {
        [TestMethod]
        public void SixFor2X3Rectangle()
        {
            var myRectangle = new Rectangle { Height = 2, Width = 3 };
            Assert.AreEqual(6, myRectangle.Area());
        }

        [TestMethod]
        public void NineFor3X3Square()
        {
            var mySquare = new Square() { SideLength = 3 };
            Assert.AreEqual(9, mySquare.Area());
        }

        [TestMethod]
        public void TwentyFor4X5ShapeFromRectangle()
        {
            Shape myShape = new Rectangle(){Height = 4, Width = 5};
            Assert.AreEqual(20, myShape.Area());
        }

        [TestMethod]
        public void TwentyFor4X5ShapeFromRectangleAnd9For3X3Square()
        {
            var shapes = new List<Shape>
                             {
                                 new Rectangle {Height = 4, Width = 5},
                                 new Square {SideLength = 3}
                             };
            var areas = new List<int>();
            foreach (Shape shape in shapes)
            {
                areas.Add(shape.Area());
            }
            Assert.AreEqual(20, areas[0]);
            Assert.AreEqual(9, areas[1]);
        }



        public abstract class Shape
        {
            public abstract int Area();
        }

        public class Rectangle : Shape
        {
            public int Height { get; set; }
            public int Width { get; set; }

            public override int Area()
            {
                return Height*Width;
            }
        }
        public class Square : Shape
        {
            public int SideLength;

            public override int Area()
            {
                return SideLength*SideLength;
            }
        }
    }


}