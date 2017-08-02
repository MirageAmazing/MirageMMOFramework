using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirage.DataStructure
{
    public interface ICancelAddNew
    {
        /// <devdoc>
        ///     If a new item has been added to the list, and <paramref name="itemIndex"/> is the position of that item,
        ///     then this method should remove it from the list and cancel the add operation.
        /// </devdoc>
        void CancelNew(int itemIndex);

        /// <devdoc>
        ///     If a new item has been added to the list, and <paramref name="itemIndex"/> is the position of that item,
        ///     then this method should leave it in the list and complete the add operation.
        /// </devdoc>
        void EndNew(int itemIndex);
    }
}