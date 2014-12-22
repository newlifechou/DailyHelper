using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DailyHelper
{
    public class WindowValid
    {
        public bool IsValid(DependencyObject node)
        {
            if (node != null)
            {
                bool isValide = !System.Windows.Controls.Validation.GetHasError(node);
                if (!isValide)
                {
                    if (node is IInputElement)
                    {
                        Keyboard.Focus((IInputElement)node);
                    }
                    return false;
                }
            }
            foreach (object subnode in LogicalTreeHelper.GetChildren(node))
            {
                if (subnode is DependencyObject)
                {
                    if (IsValid((DependencyObject)subnode)==false)
                    {
                        return false;
                    }
                }
            }
            return true;

        }
    }
}
