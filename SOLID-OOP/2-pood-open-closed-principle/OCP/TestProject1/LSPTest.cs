using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommerceProject
{
    [TestClass]
    public class LSPTest
    {
        [TestMethod]
        public void CalculateArea()
        {
            var myRectangle = new Rectangle {Height = 2, Width = 3};
            Assert.AreEqual(6, CalcArea(myRectangle));

            // TODO: Test with a square
        }

        public static int CalcArea(Rectangle r)
        {
            return r.Height*r.Width;
        }

        #region Nested type: Rectangle

        public class Rectangle
        {
            public virtual int Height { get; set; }
            public virtual int Width { get; set; }

            public bool IsSquare()
            {
                return Height == Width;
            }
        }

        #endregion

        #region Nested type: Square

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

        #endregion

        //[TestMethod]
        //public void CalculateArea()
        //{
        //    var myRectangle = new Rectangle() { Height = 2, Width = 3 };
        //    Assert.AreEqual(6, CalcArea(myRectangle));

        //    myRectangle = new Square();
        //    myRectangle.Height = 3;
        //    myRectangle.Width = 2;
        //    Assert.AreEqual(6, CalcArea(myRectangle));

        //}
    }
}