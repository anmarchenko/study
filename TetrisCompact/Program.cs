﻿using System;
using System.Windows.Forms;

namespace TetrisCompact
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[MTAThread]
		static void Main() {
			Application.Run(new MainForm());
		}
	}
}