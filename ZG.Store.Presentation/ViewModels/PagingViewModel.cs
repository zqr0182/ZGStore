using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Common.DTO;

namespace ZG.Store.Presentation.ViewModels
{
    public class PagingViewModel
    {
        protected List<PagingLinkProperties> _links = new List<PagingLinkProperties>();
        private int _currentPageNumber;
        private int _totalPageCount;
        private string _previousPageUrl = "";
        private string _nextPageUrl = "";
        private UrlHelper _urlHelper;
        private string _action;
        private string _controller;
        private string _currentCategory;

        /// <summary>
        /// disabled
        /// </summary>
        protected string Disabled
        {
            get { return "disabled"; }
        }

        /// <summary>
        /// active
        /// </summary>
        protected string Active
        {
            get { return "active"; }
        }

        /// <summary>
        /// current-page
        /// </summary>
        protected string CurrentPage
        {
            get { return "current-page"; }
        }

        public PagingLinkProperties PrevLink
        {
            get { return _links.FirstOrDefault(); }
        }

        public PagingLinkProperties NextLink
        {
            get { return _links.LastOrDefault(); }
        }

        public IEnumerable<PagingLinkProperties> MiddleLinks
        {
            get { return _links.Skip(1).Take(_links.Count - 2); }
        }

        public PagingViewModel(string action, string controller, string currentCategory,  int currentPageNumber, int totalPageCount, UrlHelper urlHelper)
        {
            _currentPageNumber = currentPageNumber;
            _totalPageCount = totalPageCount;
            _urlHelper = urlHelper;
            _action = action;
            _controller = controller;
            _currentCategory = currentCategory;

            BuildLinks();
        }

        protected void BuildLinks()
        {
            _previousPageUrl = GetPreviousPageUrl(_currentPageNumber);
            _nextPageUrl = GetNextPageUrl(_currentPageNumber, _totalPageCount);

            _links.Add(GetPreviousPageLinkProperties(_previousPageUrl));

            _links.AddRange(GetLinksBetweenCurrentAndFirstPage());
            _links.AddRange(GetLinksAfterCurrentPage());

            _links.Add(GetNextPageLinkProperties(_nextPageUrl));
        }

        private IEnumerable<PagingLinkProperties> GetLinksBetweenCurrentAndFirstPage()
        {
            var links = new List<PagingLinkProperties>();
            if (_currentPageNumber - 1 <= 3)
            {
                for (int i = 1; i <= _currentPageNumber; i++)
                {
                    if (i == _currentPageNumber)
                    {
                        links.Add(new PagingLinkProperties { CSSClass = CurrentPage, HRef = "", Text = i.ToString() });
                    }
                    else
                    {
                        links.Add(new PagingLinkProperties { CSSClass = Active, HRef = GetPageUrl(i), Text = i.ToString() });
                    }
                }
            }
            else
            {
                links.Add(new PagingLinkProperties { CSSClass = Active, HRef = GetPageUrl(1), Text = "1" });
                links.Add(new PagingLinkProperties { CSSClass = Disabled, HRef = "", Text = "..." });

                if (_currentPageNumber == _totalPageCount)
                {
                    int thirdLastPageNumber = _currentPageNumber - 2;
                    links.Add(new PagingLinkProperties { CSSClass = Active, HRef = GetPageUrl(thirdLastPageNumber), Text = thirdLastPageNumber.ToString() });
                }

                int previousPageNumber = _currentPageNumber - 1;
                links.Add(new PagingLinkProperties { CSSClass = Active, HRef = GetPageUrl(previousPageNumber), Text = previousPageNumber.ToString() });
                links.Add(new PagingLinkProperties { CSSClass = CurrentPage, HRef = "", Text = _currentPageNumber.ToString() });
            }

            return links;
        }

        private IEnumerable<PagingLinkProperties> GetLinksAfterCurrentPage()
        {
            var links = new List<PagingLinkProperties>();
            if (_totalPageCount - _currentPageNumber <= 3)
            {
                for (int i = _currentPageNumber + 1; i <= _totalPageCount; i++)
                {
                    links.Add(new PagingLinkProperties { CSSClass = Active, HRef = GetPageUrl(i), Text = i.ToString() });
                }
            }
            else
            {
                int nextPageNumber = _currentPageNumber + 1;
                links.Add(new PagingLinkProperties { CSSClass = Active, HRef = GetPageUrl(nextPageNumber), Text = nextPageNumber.ToString() });
                if (_currentPageNumber == 1)
                {
                    int thirdPage = nextPageNumber + 1;
                    links.Add(new PagingLinkProperties { CSSClass = Active, HRef = GetPageUrl(thirdPage), Text = thirdPage.ToString() });
                }
                links.Add(new PagingLinkProperties { CSSClass = Disabled, HRef = "", Text = "..." });
                links.Add(new PagingLinkProperties { CSSClass = Active, HRef = GetPageUrl(_totalPageCount), Text = _totalPageCount.ToString() });
            }

            return links;
        }

        /// <summary>
        /// Returns true if the url is not null or empty string.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool IsUrlActive(string url)
        {
            return !string.IsNullOrWhiteSpace(url);
        }

        private PagingLinkProperties GetPreviousPageLinkProperties(string previousPageUrl)
        {
            return new PagingLinkProperties
            {
                CSSClass = IsUrlActive(previousPageUrl) ? Active : Disabled,
                HRef = previousPageUrl,
                Text = "Prev"
            };
        }

        private PagingLinkProperties GetNextPageLinkProperties(string nextPageUrl)
        {
            return new PagingLinkProperties
            {
                CSSClass = IsUrlActive(nextPageUrl) ? Active : Disabled,
                HRef = nextPageUrl,
                Text = "Next"
            };
        }

        protected string GetPreviousPageUrl(int currentPageNum)
        {
            string previousPageUrl = "";

            if (currentPageNum >= 2)
            {
                int previousPageNum = currentPageNum - 1;
                previousPageUrl = GetPageUrl(previousPageNum);
            }

            return previousPageUrl;
        }

        protected string GetNextPageUrl(int currentPageNum, int totalPageCount)
        {
            string nextPageUrl = "";

            if (currentPageNum < totalPageCount)
            {
                int nextPageNum = currentPageNum + 1;
                nextPageUrl = GetPageUrl(nextPageNum);
            }

            return nextPageUrl;
        }

        private string GetPageUrl(int pageNumber)
        {
            return _urlHelper.Action(_action, _controller, new { category = _currentCategory, page = pageNumber });
        }
    }
}
