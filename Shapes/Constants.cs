﻿using System.Web.UI;

namespace Shapes
{
    public static class Constants
    {

        #region Shapes Constants
        public static string SHAPE_CIRCLE = "circle";
        public static string SHAPE_RECTANGLE = "rectangle";
        public static string SHAPE_SQUARE = "sqaure";
        public static string SHAPE_OCTAGON = "octagon";
        public static string SHAPE_ISOCELES_TRIANGLE = "isoceles triangle";
        public static string SHAPE_SCALENE_TRIANGLE = "scalene triangle";
        public static string SHAPE_EQUILATERAL_TRIANGLE = "equilateral triangle";
        public static string SHAPE_OVAL = "oval";
        #endregion

        #region Intent Constants
        public static string INTENT_DRAW = "draw";


        #endregion


        #region HTML STRINGS
        public static string HTML_CIRCLE = "<svg style='display: block; margin: auto; width: 400px;height: 400px'><circle cx='150' cy='150' r='100' stroke='green' stroke-width='4' fill='yellow' /></svg>";

        #endregion
    }
}