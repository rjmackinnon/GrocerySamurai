using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicHamster.GrocerySamurai.NavigationHelper
{
    /// <summary>
    /// Store navigation history smartly, so that a validation error doesn't duplicate the history.
    /// 
    /// Only instantiate once per session.
    /// </summary>
    public sealed class NavigationHelper : INavigationHelper
    {
        private Stack<string> navigationStack { get; set; }

        /// <inheritdoc />
        public int Count => navigationStack.Count;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NavigationHelper()
        {
            navigationStack = new Stack<string>();
        }

        /// <inheritdoc />
        public void Add(string referral, string current, AddOptions addOptions = AddOptions.DoNotMatchQueryParameters)
        {
            if (referral == null || current == null)
            {
                return;
            }

            var isStackDuplicate = false;
            var isCurrentDuplicate = false;

            if (Current() != null)
            {
                var stackTop = new Uri(Current());
                var referralUri = new Uri(referral);
                var currentUri = new Uri(current);

                switch (addOptions)
                {
                    case AddOptions.MatchQueryParameters:
                        isStackDuplicate = stackTop.AbsoluteUri.Equals(referralUri.AbsoluteUri);
                        isCurrentDuplicate = currentUri.AbsoluteUri.Equals(referralUri.AbsoluteUri);
                        break;

                    case AddOptions.DoNotMatchQueryParameters:
                        isStackDuplicate = stackTop.GetLeftPart(UriPartial.Path).Equals(referralUri.GetLeftPart(UriPartial.Path));
                        isCurrentDuplicate = currentUri.GetLeftPart(UriPartial.Path).Equals(referralUri.GetLeftPart(UriPartial.Path));
                        break;

                    default:
                        throw new NotImplementedException($"Unsupported option {nameof(addOptions)}");
                }
            }

            if (isCurrentDuplicate && isStackDuplicate)
            {
                navigationStack.Pop();
                navigationStack.Push(referral);
            }
            else if (!isCurrentDuplicate && !isStackDuplicate)
            {
                navigationStack.Push(referral);
            }
        }

        /// <inheritdoc />
        public string Current()
        {
            return Count == 0 ? null : navigationStack.Peek();
        }

        /// <inheritdoc />
        public string Remove()
        {
            return Count == 0 ? null : navigationStack.Pop();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(navigationStack.ToList());
        }

        public static INavigationHelper FromJson(string json)
        {
            var list = JsonConvert.DeserializeObject<List<string>>(json);
            list.Reverse();
            var result = new NavigationHelper {navigationStack = new Stack<string>(list)};
            return result;
        }
    }
}
