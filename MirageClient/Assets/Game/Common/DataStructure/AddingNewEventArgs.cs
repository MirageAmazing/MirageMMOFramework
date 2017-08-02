using System;
using System.Security.Permissions;

namespace Mirage.DataStructure
{ 
    [HostProtection(SharedState = true)]
    public class AddingNewEventArgs : EventArgs
    {
        private object newObject = null;

        /// <devdoc>
        ///     Initializes a new instance of the <see cref='System.ComponentModel.AddingNewEventArgs'/> class,
        ///     with no new object defined.
        /// </devdoc>
        public AddingNewEventArgs() : base()
        {
        }

        /// <devdoc>
        ///     Initializes a new instance of the <see cref='System.ComponentModel.AddingNewEventArgs'/> class,
        ///     with the specified object defined as the default new object.
        /// </devdoc>
        public AddingNewEventArgs(object newObject) : base()
        {
            this.newObject = newObject;
        }

        /// <devdoc>
        ///     Gets or sets the new object that will be added to the list.
        /// </devdoc>
        public object NewObject
        {
            get
            {
                return newObject;
            }

            set
            {
                newObject = value;
            }
        }
    }
}