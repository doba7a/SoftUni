using Logger.Models.Layouts.Contracts;
using System;

namespace Logger.Models.Layouts.Factory
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout = null;

            switch (type)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout = new XmlLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid layout type!");
            }

            return layout;
        }
    }
}
