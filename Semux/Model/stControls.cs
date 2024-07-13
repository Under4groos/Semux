using Avalonia;
using Avalonia.Controls;
using Avalonia.VisualTree;

namespace Semux.Model
{
    public static class stControls
    {
        public static T? FindControlNoName<T>(this UserControl control) where T : class
        {

            foreach (Visual item in control.GetVisualChildren())
            {
                if (item.GetType() == typeof(T))
                    return item as T;

                return FindControlNoName<T>(control);
            }
            return null;
            // this.GetVisualChildren()
        }
    }
}
