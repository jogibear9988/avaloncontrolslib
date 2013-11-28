using System;
using System.Windows;

namespace AvalonUnitTesting
{
    /// <summary>
    /// Helper class that creates the instances of the objects
    /// </summary>
    internal static class AvalonActivatorHelper
    {
        /// <summary>
        /// wrapps a control in a window so that it can be unit tested
        /// </summary>
        private class ControlWrapper : Window
        {
            /// <summary>
            /// constructor to wrap a control inside a window
            /// </summary>
            /// <param name="controlToWrap">The control to wrap in the window</param>
            public ControlWrapper(object controlToWrap)
            {
                Content = controlToWrap;
            }
        }

        /// <summary>
        /// Creates the instance of the Type that is passed
        /// </summary>
        /// <param name="type">The type to cretae instance of</param>
        /// <param name="parameters">The constructor parameters if any</param>
        /// <returns>An object of the specified type. if the object is not a window it will be wrapped in a window</returns>
        /// <exception cref="ArgumentNullException">The type parameter is passed as null</exception>
        internal static Window CreateInstance(Type type, params object[] parameters)
        {
            if (type == null)
                throw new ArgumentNullException("type", "Type was passed as null");

            object instance;
            if (parameters != null && parameters.Length != 0)
                instance = Activator.CreateInstance(type, parameters);
            else
                instance = Activator.CreateInstance(type);

            return VerifyObjectType(instance);
        }

        /// <summary>
        /// Checks if the object is of type window
        /// If not it creates a wrapper window
        /// </summary>
        /// <param name="instance">The instance of the object to check</param>
        /// <returns>Returns a window instance</returns>
        public static Window VerifyObjectType(object instance)
        {
            Window returnValue = instance as Window;
            //return the value if it is alread a window
            if (returnValue != null)
                return returnValue;

            //wrap the control in a window and return it
            ControlWrapper wrapper = new ControlWrapper(instance);
            return wrapper;
        }
    }
}
