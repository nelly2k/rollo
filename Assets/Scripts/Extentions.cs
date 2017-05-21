using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class Extentions
    {
        public static string GetFigureResourceName(this FigureType figureType)
        {
            if (!FigureTypeResource.ContainsKey(figureType))
            {
                throw new Exception("Don't have information about figure resource");
            }
            return FigureTypeResource[figureType];
        }

        public static Dictionary<FigureType, string> FigureTypeResource
        {
            get
            {
                return new Dictionary<FigureType, string>()
                {
                    {FigureType.Red, "RedFigure" },
                    {FigureType.Green, "GreenFigure" },
                };
            }
        }
    }
}