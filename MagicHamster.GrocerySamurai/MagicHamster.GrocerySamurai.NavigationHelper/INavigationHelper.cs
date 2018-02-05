namespace MagicHamster.GrocerySamurai.NavigationHelper
{
    public interface INavigationHelper
    {
        /// <summary>
        /// Gets the current count in the navigation stack.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Add a URI to the stack. Will not add if the last address is the same or the input is blank.
        /// </summary>
        /// <param name="referralAddress">Address of the referral</param>
        /// <param name="currentAddress">Current address</param>
        /// <param name="addOptions">How to process duplicates</param>
        void Add(string referralAddress, string currentAddress, AddOption addOptions = AddOption.DoNotMatchQueryParameters);

        /// <summary>
        /// Get the latest address on the stack.
        /// </summary>
        /// <returns>Uri of the current address.</returns>
        string Current();

        /// <summary>
        /// Remove the latest address on the stack.
        /// </summary>
        /// <returns>The removed URI.</returns>
        string Remove();

        string ToJson();
    }
}