using System;
using System.Collections.Generic;

namespace MagicHamster.GrocerySamurai.NavigationHelper
{
    /// <summary>
    /// Store navigation history smartly, so that a validation error doesn't duplicate the history.
    /// 
    /// Only instantiate once per session.
    /// </summary>
    public sealed class NavigationHelper : INavigationHelper
    {
        private Stack<Uri> navigationStack { get; }

        /// <inheritdoc />
        public int Count => navigationStack.Count;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NavigationHelper()
        {
            navigationStack = new Stack<Uri>();
        }

        /// <inheritdoc />
        public void Add(string referralAddress, string currentAddress, AddOptions addOptions = AddOptions.DoNotMatchQueryParameters)
        {
            if (String.IsNullOrWhiteSpace(referralAddress) || String.IsNullOrWhiteSpace(currentAddress))
            {
                return;
            }

            Add(new Uri(referralAddress), new Uri(currentAddress), addOptions);
        }

        /// <inheritdoc />
        public void Add(Uri referralUri, Uri currentUri, AddOptions addOptions = AddOptions.DoNotMatchQueryParameters)
        {
            if (referralUri == null || currentUri == null)
            {
                return;
            }

            var current = Current();
            var isStackDuplicate = false;
            var isCurrentDuplicate = false;

            if (current != null)
            {
                switch (addOptions)
                {
                    case AddOptions.MatchQueryParameters:
                        isStackDuplicate = current.AbsoluteUri.Equals(referralUri.AbsoluteUri);
                        isCurrentDuplicate = currentUri.AbsoluteUri.Equals(referralUri.AbsoluteUri);
                        break;

                    case AddOptions.DoNotMatchQueryParameters:
                        isStackDuplicate = current.GetLeftPart(UriPartial.Path).Equals(referralUri.GetLeftPart(UriPartial.Path));
                        isCurrentDuplicate = currentUri.GetLeftPart(UriPartial.Path).Equals(referralUri.GetLeftPart(UriPartial.Path));
                        break;

                    default:
                        throw new NotImplementedException($"Unsupported option {nameof(addOptions)}");
                }
            }

            if (isCurrentDuplicate && isStackDuplicate)
            {
                navigationStack.Pop();
                navigationStack.Push(referralUri);
            }
            else if (!isCurrentDuplicate && !isStackDuplicate)
            {
                navigationStack.Push(referralUri);
            }
        }

        /// <inheritdoc />
        public Uri Current()
        {
            return Count == 0 ? null : navigationStack.Peek();
        }

        /// <inheritdoc />
        public Uri Remove()
        {
            return Count == 0 ? null : navigationStack.Pop();
        }
    }
}
