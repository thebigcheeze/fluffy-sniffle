using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using fluffy_sniffle_logic;
using System.Collections.Generic;

namespace fluffy_sniffle_test
{
    [TestClass]
    public class TriangleLogicTest
    {
        [TestMethod]
        public void CanFindVertexesForA1()
        {
            const char row = 'A';
            const int column = 1;

            HashSet<Vertex> expectedResponse = new HashSet<Vertex>(new[]
            {
                new Vertex{ X = 0, Y = 0},
                new Vertex{ X = 10, Y = 10},
                new Vertex{ X = 0, Y = 10},
            });
            
            HashSet<Vertex> actualResponse = new HashSet<Vertex>(TriangleLogic.FindVerticiesOfTriangle(row, column));
            
            Assert.IsTrue(expectedResponse.SetEquals(actualResponse));
        }

        [TestMethod]
        public void CanFindVertexesForD6()
        {
            const char row = 'D';
            const int column = 6;

            var expectedVerticies = new[]
            {
                new Vertex{ X = 20, Y = 30},
                new Vertex{ X = 30, Y = 30},
                new Vertex{ X = 30, Y = 40},
            };

            HashSet<Vertex> expectedResponse = new HashSet<Vertex>(expectedVerticies);

            var actualVertexes = TriangleLogic.FindVerticiesOfTriangle(row, column);

            HashSet<Vertex> actualResponse = new HashSet<Vertex>(actualVertexes);

            Assert.IsTrue(expectedResponse.SetEquals(actualResponse));
        }

        [TestMethod]
        public void CanFindD6FromVertexes()
        {
            const char expectedRow = 'D';
            const int expectedColumn = 6;

            var verticies = new[]
            {
                new Vertex{ X = 20, Y = 30},
                new Vertex{ X = 30, Y = 30},
                new Vertex{ X = 30, Y = 40},
            };

            var response = TriangleLogic.FindTriangleFromVerticies(verticies);

            Assert.AreEqual(response.Item1, expectedRow);
            Assert.AreEqual(response.Item2, expectedColumn);
        }

        [TestMethod]
        public void CanFindA1FromVertexes()
        {
            const char expectedRow = 'A';
            const int expectedColumn = 1;

            var verticies = new[]
            {
                new Vertex{ X = 0, Y = 0},
                new Vertex{ X = 10, Y = 10},
                new Vertex{ X = 0, Y = 10},
            };

            var response = TriangleLogic.FindTriangleFromVerticies(verticies);

            Assert.AreEqual(response.Item1, expectedRow);
            Assert.AreEqual(response.Item2, expectedColumn);
        }
    }
}
