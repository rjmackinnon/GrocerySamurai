using System;

namespace MagicHamster.GrocerySamurai.NavigationHelper
{
    public interface INavigationHelper
    {
        /// <summary>
        /// Get the current count in the navigation stack.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Add a URI to the stack. Will not add if the last address is the same or the input is blank.
        /// </summary>
        /// <param name="referralAddress">Address of the referral</param>
        /// <param name="currentAddress">Current address</param>
        /// <param name="addOptions">How to process duplicates</param>
        void Add(string referralAddress, string currentAddress, AddOptions addOptions = AddOptions.DoNotMatchQueryParameters);

        /// <summary>
        /// Add a URI to the stack. Will not add if the last address is the same or the input is blank.
        /// </summary>
        /// <param name="referralUri">URI of the referral</param>
        /// <param name="currentUri">Current URI</param>
        /// <param name="addOptions">How to process duplicates</param>
        void Add(Uri referralUri, Uri currentUri, AddOptions addOptions = AddOptions.DoNotMatchQueryParameters);

        /// <summary>
        /// Get the latest address on the stack.
        /// </summary>
        /// <returns>Uri of the current address.</returns>
        Uri Current();

        /// <summary>
        /// Remove the latest address on the stack.
        /// </summary>
        /// <returns>The removed URI.</returns>
        Uri Remove();
    }
}