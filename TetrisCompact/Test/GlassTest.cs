﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;

namespace Test
{
	/// <summary>
	/// Summary description for GlassTest
	/// </summary>
	[TestClass]
	public class GlassTest
	{
		public GlassTest() {
			//
			// TODO: Add constructor logic here
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion
		
		[TestMethod]
		public void TestCanFit(){
			var arr = new []{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,0,1,1}
			                    };

			Assert.IsTrue ( arr.Length == 10 );
			Assert.IsTrue ( arr[0].Length == 20);

			var glass = Glass.createTestGlass (arr);

			AbstractFigure fig = new FigureL();

			// #.
			// #.
			// ##
			Assert.IsTrue(glass.checkFit(fig, 7, 17));
			Assert.IsTrue(glass.checkFit(fig, 1, 11));
			Assert.IsTrue(glass.checkFit(fig, 6, 13));
			Assert.IsFalse(glass.checkFit(fig, 6, 17));
			Assert.IsFalse(glass.checkFit(fig, 9, 11));
			Assert.IsFalse(glass.checkFit(fig, 2, 18));

			fig.Rotate();

			// ###
			// #..
			Assert.IsTrue(glass.checkFit(fig, 3, 15));
			Assert.IsTrue(glass.checkFit(fig, 1, 17));
			Assert.IsTrue(glass.checkFit(fig, 5, 11));
			Assert.IsFalse(glass.checkFit(fig, 3, 16));
			Assert.IsFalse(glass.checkFit(fig, 1, 18));
			Assert.IsFalse(glass.checkFit(fig, 5, 12));

			fig = new FigureI();

			// #
			// #
			// #
			// #
			Assert.IsTrue(glass.checkFit(fig, 2, 16));
			Assert.IsTrue(glass.checkFit(fig, 7, 16));
			Assert.IsTrue(glass.checkFit(fig, 0, 13));
			Assert.IsFalse(glass.checkFit(fig, 2, 17));
			Assert.IsFalse(glass.checkFit(fig, 6, 16));
			Assert.IsFalse(glass.checkFit(fig, 0, 14));

			fig = new FigureZ();

			// ".#" 
			// "##" 
			// "#."
			Assert.IsTrue(glass.checkFit(fig, 2, 17));
			Assert.IsTrue(glass.checkFit(fig, 1, 16));
			Assert.IsTrue(glass.checkFit(fig, 5, 10));
			Assert.IsFalse(glass.checkFit(fig, 7, 17));
			Assert.IsFalse(glass.checkFit(fig, 3, 15));
			Assert.IsFalse(glass.checkFit(fig, 1, 17));

			fig.Rotate();

			// "##." 
			// ".##"
			Assert.IsTrue(glass.checkFit(fig, 1, 18));
			Assert.IsTrue(glass.checkFit(fig, 0, 16));
			Assert.IsTrue(glass.checkFit(fig, 4, 15));
			Assert.IsFalse(glass.checkFit(fig, 0, 18));
			Assert.IsFalse(glass.checkFit(fig, 0, 19));
			Assert.IsFalse(glass.checkFit(fig, 5, 17));
		}

		[TestMethod]
		public void TestAddFigure(){
			var glass = new Glass();
			var arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue ( glass.AddFigure ( new FigureI() ) );
			Assert.IsTrue ( glass.compareFields ( arr ));
			Assert.IsTrue ( glass.IsRunning() );
			Assert.IsFalse( glass.IsFull());

			glass = new Glass();
			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.AddFigure(new FigureT()));
			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsTrue(glass.IsRunning());
			Assert.IsFalse(glass.IsFull());

			glass = new Glass();
			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.AddFigure(new FigureL()));
			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsTrue(glass.IsRunning());
			Assert.IsFalse(glass.IsFull());

			glass = new Glass();
			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.AddFigure(new FigureO()));
			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsTrue(glass.IsRunning());
			Assert.IsFalse(glass.IsFull());

			glass = new Glass();
			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.AddFigure(new FigureS()));
			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsTrue(glass.IsRunning());
			Assert.IsFalse(glass.IsFull());
			// добавить вторую фигуру подряд
			Assert.IsFalse(glass.AddFigure(new FigureS()));
			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsTrue(glass.IsRunning());
			Assert.IsFalse(glass.IsFull());

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };
			glass = Glass.createTestGlass(arr);

			Assert.IsFalse(glass.AddFigure(new FigureS()));
			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsFalse(glass.IsRunning());
			Assert.IsTrue(glass.IsFull());
		}

		[TestMethod]
		public void TestRotate(){
			var glass = new Glass();
			Assert.IsTrue(glass.AddFigure(new FigureL()));

			glass.Rotate();

			var arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));

			glass.Rotate();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));

			glass = new Glass();
			Assert.IsTrue(glass.AddFigure(new FigureS()));

			glass.Rotate();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));

			glass.Rotate();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			glass = Glass.createTestGlass(arr);

			Assert.IsTrue(glass.AddFigure(new FigureT()));

			glass.Rotate();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));
		}

		[TestMethod]
		public void TestStepRight(){
			var glass = new Glass();
			Assert.IsTrue(glass.AddFigure(new FigureO()));

			glass.StepRight();

			var arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));

			glass.StepRight();
			glass.StepRight();
			glass.StepRight();
			glass.StepRight();
			glass.StepRight();
			glass.StepRight();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			glass = Glass.createTestGlass ( arr );

			Assert.IsTrue(glass.AddFigure(new FigureJ()));

			glass.StepRight();
			glass.StepRight();
			glass.StepRight();
			glass.StepRight();
			glass.StepRight();
			glass.StepRight();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));
		}

		[TestMethod]
		public void TestStepLeft() {
			var glass = new Glass();
			Assert.IsTrue(glass.AddFigure(new FigureO()));

			glass.StepLeft();

			var arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));

			glass.StepLeft();
			glass.StepLeft();
			glass.StepLeft();
			glass.StepLeft();
			glass.StepLeft();
			glass.StepLeft();

			arr = new[]{
			                    	new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			glass = Glass.createTestGlass(arr);

			Assert.IsTrue(glass.AddFigure(new FigureJ()));

			glass.StepLeft();
			glass.StepLeft();
			glass.StepLeft();
			glass.StepLeft();
			glass.StepLeft();
			glass.StepLeft();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));
		}

		[TestMethod]
		public void TestStepDown() {
			var glass = new Glass();
			Assert.IsTrue(glass.AddFigure(new FigureI()));

			glass.StepDown();

			var arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));

			for(int i = 0; i < 20; ++i)
				glass.StepDown();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsFalse ( glass.IsRunning() );

			Assert.IsTrue(glass.AddFigure(new FigureS()));
			Assert.IsTrue(glass.IsRunning());

			for(int i = 0; i < 20; ++i)
				glass.StepDown();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsFalse(glass.IsRunning());
		}

		[TestMethod]
		public void TestFallDown() {
			var glass = new Glass();

			Assert.IsTrue(glass.AddFigure(new FigureZ()));

			glass.FallDown();

			var arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsFalse(glass.IsRunning());

			Assert.IsTrue(glass.AddFigure(new FigureT()));

			glass.FallDown();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsFalse(glass.IsRunning());

			Assert.IsTrue(glass.AddFigure(new FigureS()));

			glass.FallDown();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsFalse(glass.IsRunning());

			Assert.IsTrue(glass.AddFigure(new FigureO()));

			glass.FallDown();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,1,1,1,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsFalse(glass.IsRunning());

			Assert.IsTrue(glass.AddFigure(new FigureL()));

			glass.FallDown();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,1,1,1,0,1,1,1,1,1,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsFalse(glass.IsRunning());

			Assert.IsTrue(glass.AddFigure(new FigureJ()));

			glass.FallDown();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1},
									new[]{0,0,0,0,0,1,1,1,0,0,1,1,1,0,1,1,1,1,1,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsFalse(glass.IsRunning());

			Assert.IsTrue(glass.AddFigure(new FigureI()));

			glass.FallDown();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
									new[]{0,0,0,0,0,1,1,1,0,0,1,1,1,0,1,1,1,1,1,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsFalse(glass.IsRunning());

			Assert.IsFalse(glass.AddFigure(new FigureI()));

			glass.FallDown();

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
									new[]{0,0,0,0,0,1,1,1,0,0,1,1,1,0,1,1,1,1,1,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue(glass.compareFields(arr));
			Assert.IsFalse(glass.IsRunning());
			Assert.IsTrue(glass.IsFull());
		}

		[TestMethod]
		public void TestEatRows(){

			var arr = new[]{
			                    	new[]{0,0,0,0,0,1,0,0,0,0,0,0,1,1,0,1,1,0,0,1},
									new[]{0,0,0,0,0,1,0,0,0,0,0,0,1,0,1,1,1,1,1,1},
									new[]{0,0,0,0,0,1,0,0,0,0,0,0,1,1,0,1,1,1,0,1},
									new[]{0,0,0,0,0,1,0,0,0,0,0,0,1,0,1,1,1,0,0,1},
									new[]{0,0,0,0,0,1,0,0,0,0,0,0,1,1,1,1,1,0,1,1},
									new[]{0,0,0,0,0,1,0,0,0,0,0,0,1,0,1,1,1,1,1,1},
									new[]{0,0,0,0,0,1,0,0,0,0,0,0,1,1,0,1,1,0,0,1},
									new[]{0,0,0,0,0,1,0,0,0,0,0,0,1,0,1,1,1,1,1,1},
									new[]{0,0,0,0,0,1,0,0,0,0,0,0,1,1,0,1,1,0,1,1},
									new[]{0,0,0,0,0,1,0,0,0,0,0,0,1,0,1,1,1,0,0,1}
			                    };

			var glass = Glass.createTestGlass ( arr );

			Assert.AreEqual ( 5, glass.EatRows() );

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0}
			                    };

			Assert.IsTrue ( glass.compareFields ( arr ) );

			glass = new Glass();
			int score = 0;

			Assert.IsTrue( glass.AddFigure(new FigureI()) );
            glass.Rotate();
			for (int i = 0; i < 10; ++i)
				glass.StepRight();
			glass.FallDown();
			score += glass.EatRows();

			Assert.IsTrue ( glass.AddFigure(new FigureI()) );
			glass.Rotate();
			for(int i = 0; i < 10; ++i)
				glass.StepLeft();
			glass.FallDown();
			score += glass.EatRows();

			Assert.IsTrue ( glass.AddFigure(new FigureL()) );
			glass.FallDown();
			score += glass.EatRows();
			
			Assert.AreEqual ( 1, score );

			arr = new[]{
			                    	new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
									new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
			                    };

			Assert.IsTrue ( glass.compareFields ( arr ) );
		}
	}
}
